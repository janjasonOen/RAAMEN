using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Repository;
using Final_Project.Model;

namespace Final_Project.Handler
{
    public class UserHandler
    {
        public static string newUser(string roleid, string username, string email, string gender, string password)
        {
            return UserRepository.newUser(roleid, username, email, gender, password);
        }

        public static User userLogin(string name, string pw)
        {
            User x = UserRepository.userLogin(name, pw);
            return x;
        }

        public static List<User> getMember()
        {
            return UserRepository.getMember();
        }

        public static List<User> getStaff()
        {
            return UserRepository.getStaff();
        }

        public static string updateUser(string id, string username, string email, string gender, string password)
        {
            return UserRepository.updateUser(Convert.ToInt32(id), username, email, gender, password);
        }
    }
}