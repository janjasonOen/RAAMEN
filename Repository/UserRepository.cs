using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Factory;
using Final_Project.Model;

namespace Final_Project.Repository
{
    public class UserRepository
    {
        public static Database1Entities1 db = new Database1Entities1();

        public static string newUser(string roleid, string username, string email, string gender, string password)
        {
            User newU = UserFactory.CreateUser(roleid, username, email, gender, password);
            db.Users.Add(newU);
            db.SaveChanges();

            return "Create User Success!";
        }


        public static User userLogin(string name, string pw)
        {
            User x = (from i in db.Users where i.Username == name && i.Password == pw select i).FirstOrDefault();
            return x;
        }

        public static List<User> getMember()
        {
            List<User> member = (from x in db.Users where x.Roleid == 3 select x).ToList();

            return member;
        }

        public static List<User> getStaff()
        {
            List<User> staff = (from x in db.Users where x.Roleid == 2 select x).ToList();

            return staff;
        }

        public static string updateUser(int id, string username, string email, string gender, string password)
        {
            User user = db.Users.Find(id);
            if(user != null)
            {
                user.Username = username;
                user.Email = email;
                user.Gender = gender;
                user.Password = password;

                db.SaveChanges();
                return "Update Success!";
            }
            else
            {
                return user.id.ToString();
            }
        }
    }
}