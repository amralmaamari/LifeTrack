namespace LifeTrackDL.Model
{
    public class AuthDTOS
    {
        public class LoginDTO
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class SignUpDTO
        {

            public string FullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }



        }
    }
}
