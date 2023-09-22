using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Model;

namespace Final_Project.Factory
{
    public class UserFactory
    {
        public static User CreateUser(string roleid, string username, string email, string gender, string password)
        {
            User newUser = new User
            {
                Roleid = Convert.ToInt32(roleid),
                Username = username,
                Email = email,
                Gender = gender,
                Password = password
            };
            return newUser;
        }
    }
}