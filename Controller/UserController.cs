using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Handler;
using Final_Project.Model;

namespace Final_Project.Controller
{
    public class UserController
    {
        public static string validateUser(
            string roleid,
            string username,
            string email,
            string gender,
            string password,
            string passwordC)
        {
            //validate that all fields are filled
            if(username.Length == 0 || email.Length == 0 || gender.Length == 0
                || password.Length == 0 || passwordC.Length == 0 || roleid.Length == 0)
            {
                return "Please fill all fields";
            }
            else if(username.Length < 5 || username.Length > 15)
            {
                return "Username must be 5 - 15 characters long";
            }
            //validate email
            else if(email.EndsWith(".com") == false)
            {
                return "email must end with .com";
            }
            //validate password
            else if(password != passwordC)
            {
                return "password does not match";
            }
            //validate username alphabet
            else
            {
                for(int i = 0; i < username.Length; i++)
                {
                    if (char.IsPunctuation(username[i]))
                    {
                        return "Username must be an alphabet member or whitespace";
                    }
                }
                return UserHandler.newUser(roleid, username, email, gender, password);

            }
        }

        public static User userLogin(string name, string pw)
        {
            return UserHandler.userLogin(name, pw);
        }

        public static string validateUpdate(
            string id,
            string username,
            string email,
            string gender,
            string password,
            string passwordC)
        {
            //validate that all fields are filled
            if (username.Length == 0 || email.Length == 0 || gender.Length == 0
                || password.Length == 0 || passwordC.Length == 0 || id.Length == 0)
            {
                return "Please fill all fields";
            }
            else if (username.Length < 5 || username.Length > 15)
            {
                return "Username must be 5 - 15 characters long";
            }
            //validate email
            else if (email.EndsWith(".com") == false)
            {
                return "email must end with .com";
            }
            //validate password
            else if (password != passwordC)
            {
                return "password does not match";
            }
            else if(!gender.Equals("Female") && !gender.Equals("Male"))
            {
                return "Gender must be Male/Female";
            }
            //validate username alphabet
            else
            {
                for (int i = 0; i < username.Length; i++)
                {
                    if (char.IsPunctuation(username[i]))
                    {
                        return "Username must be an alphabet member or whitespace";
                    }
                }
                return UserHandler.updateUser(id.ToString(), username, email, gender, password);

            }
        }
    }
}