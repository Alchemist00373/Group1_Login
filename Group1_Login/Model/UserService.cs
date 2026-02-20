using System;
using System.Collections.Generic;
using System.Text;

namespace Group1_Login.Model
{
    public static class UserService
    {
        public static List<UserModel> Users { get; } = new List<UserModel> {
            new UserModel { Username = "Christian", Password = "Christian", FirstName = "Christian", MiddleName = "Barriento", LastName = "Barawid", Address = "Maluid, Victoria, Tarlac", Religion = "Catholic" },
            new UserModel { Username = "Mark", Password = "Mark", FirstName = "Mark", MiddleName = "Aquino", LastName = "Melchor", Address = "Baculong Victoria, Tarlac", Religion = "Catholic" },
            new UserModel { Username = "Michael", Password = "Michael", FirstName = "Michael", MiddleName = "Gamido", LastName = "Rufino", Address = "San Fernando Victoria Tarlac", Religion = "Muslim" },
            new UserModel { Username = "Simon", Password = "Simon", FirstName = "Simon", MiddleName = "Naungayan", LastName = "Mariano", Address = "Sta Barbara", Religion = "Born Again" },
            new UserModel { Username = "Jennica", Password = "Jennica", FirstName = "Jennica", MiddleName = "Valdoz", LastName = "Miguel", Address = "Lapaz, Tarlac", Religion = "Born Again" },
            new UserModel { Username = "Jhomari", Password = "Jhomari", FirstName = "Jhomari Ivan", MiddleName = "Domingo", LastName = "Velasco", Address = "San Nicolas Victoria, Tarlac", Religion = "Born Again" }
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
