using System;
using System.Collections.Generic;
using System.Text;


namespace Group1_Login.Model
{
    public class UserModel
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String Religion { get; set; }

    }

    
    public static class UserService
    {
        public static List<UserModel> Users { get; } = new List<UserModel> { 
            new UserModel { Username = "user1", Password = "pass1", FirstName = "John", MiddleName = "Castro", LastName = "Doe", Address = "123 Main St", Religion = "NA" },
            new UserModel { Username = "user2", Password = "pass2", FirstName = "Jane", MiddleName = "Smith", LastName = "Doe", Address = "456 Elm St", Religion = "NA" },
            new UserModel { Username = "user3", Password = "pass3", FirstName = "Alice", MiddleName = "Johnson", LastName = "Smith", Address = "789 Oak St", Religion = "NA" },
            new UserModel { Username = "user4", Password = "pass4", FirstName = "Bob", MiddleName = "Brown", LastName = "Johnson", Address = "321 Pine St", Religion = "NA" },
            new UserModel { Username = "user5", Password = "pass5", FirstName = "Charlie", MiddleName = "Davis", LastName = "Brown", Address = "654 Cedar St", Religion = "NA" },
            new UserModel { Username = "user6", Password = "pass6", FirstName = "David", MiddleName = "Wilson", LastName = "Davis", Address = "987 Spruce St", Religion = "NA" }
        };

        public static bool ValidateUser(string username, string password)
        {
            foreach (var user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

    }

}
