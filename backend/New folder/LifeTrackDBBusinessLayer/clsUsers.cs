
            using System;
            using System.Data;
            using System.Data.SqlClient;
            
             namespace LifeTrackDB_Business
             {
                 public  class clsUsers
                 {
                           
                          
            public enum enMode {AddNew = 0,Update = 1}
            public static enMode Mode = enMode.AddNew;
            
                          public UsersDTO usersDTO
{
    get
    {
        return new UsersDTO(
	  this.UserID, 
	  this.FullName, 
	  this.Email, 
	  this.Password, 
	  this.IsActive, 
       );
    }
}

                          	 public int UserID  {get; set;}
	 public string FullName  {get; set;}
	 public string Email  {get; set;}
	 public string Password  {get; set;}
	 public bool IsActive  {get; set;}

                          
public clsUsers() { 	
 this.UserID = -1;
	
 this.FullName = "";
	
 this.Email = "";
	
 this.Password = "";
	
 this.IsActive = false;

    Mode = enMode.AddNew;
}
                          
            public clsUsers(UsersDTO users, enMode mode = enMode.AddNew ){

this.UserID = users.UserID ;

this.FullName = users.FullName ;

this.Email = users.Email ;

this.Password = users.Password ;

this.IsActive = users.IsActive ;

Mode = mode;
}
                          public static List<UsersDTO> GetAllUsers()
{
return clsUsersData.GetAllUsers();
 
}

                          
             public static clsUsers GetUsersInfoByID(int UserID)
                    {
                   UsersDTO usersDTO = clsUsersData.GetUsersInfoByID(UserID);

                    if (usersDTO != null)
                    {
                        return new clsUsers(usersDTO, enMode.Update);
                    }
                    else
                    {
                        return null;
                    }
            }
                
                          private  bool _AddNewUsers()
{

this.UserID = (int)clsUsersData.AddNewUsers(  this.usersDTO);
            return (this.UserID != -1);
             
}

                          private  bool _UpdateUsers()
{

                return (clsUsersData.UpdateUsers(this.usersDTO));
}

                          public  bool Save()
{

if (Mode == enMode.AddNew)
    {
        if (_AddNewUsers())
        {
            Mode = enMode.Update;
            return true;
        }
        else
            return false;
    }
    else
    {
        return _UpdateUsers();
    }

}

                          public static bool DeleteUsers(int UserID)
{
return clsUsersData.DeleteUsers(UserID);
 
}


                        
                 }
             } 
                
            
             