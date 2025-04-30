using System.Security.Claims;
using LifeTrackDB_Business;
using LifeTrackDL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LifeTrackDL.Model.AuthDTOS;

namespace LifeTrackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly clsJwtTokenService _jwtTokenService;
        public AuthController(clsJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("register", Name = "register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult RegisterUser([FromBody] SignUpDTO newUserDTO)
        {

            if (newUserDTO == null)
            {
                return BadRequest(new { success = false, message = "Invalid User data." });
            }
            clsUsers user = new clsUsers { FullName = newUserDTO.FullName, Email = newUserDTO.Email, Password = newUserDTO.Password };
            user.Save();

            if (user.UserID <= 0)
            {
                return BadRequest(new { success = false, message = "User could not be created." });
            }

            var token = _jwtTokenService.GenerateToken(user.Email);
            Response.Cookies.Append("token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });

            // return CreatedAtRoute("RegisterPerson", new { success = true, token });
            //return CreatedAtRoute("GetPersonById", new { id = user.UserID }, user);
            return Ok(new
            {
                success = true,
                data = new
                {
                    user.FullName,
                    user.Email
                }
            });


        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO)
        {

            if (loginDTO == null)
            {
                return BadRequest(new { success = false, message = "Invalid User data." });
            }

            // Validate user credentials against the database
            //the below use http  


            if (await clsUsers.IsUserExists(loginDTO))
            {
                UsersDTO user = clsUsers.GetUsersInfoByEmail(loginDTO.Email);
                var token = _jwtTokenService.GenerateToken(loginDTO.Email);
                Response.Cookies.Append("token", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict
                });
                return Ok(new
                {
                    success = true,
                    data = new
                    {
                        user.FullName,
                        user.Email
                    }
                });

                //return Ok(new { success = true, login= loginDTO });
            }

            return Unauthorized(new { success = false, message = "User not found!" });

        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("token");
            return Ok();
        }


        [HttpGet("me")]
        [Authorize]
        public IActionResult GetMe()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var name = "from-db-based-on-email"; // fetch full name
            return Ok(new { fullName = name, email = email });
        }

    }
}
