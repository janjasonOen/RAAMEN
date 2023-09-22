using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Repository;
using Final_Project.Model;

namespace Final_Project.Handler
{
    public class RamenHandler
    {
        public static List<RamenRes> GetRamen()
        {
            return RamenRepository.GetRamen();
        }

        public static Ramen GetSingleRamen(int id)
        {
            return RamenRepository.GetSingleRamen(id);
        }
        public static string CreateRamen(int meatid, string name, string broth, string price)
        {
            return RamenRepository.CreateRamen(meatid, name, broth, price);
        }

        public static string UpdateRamen(int id, int meatid, string name, string broth, string price)
        {
            return RamenRepository.UpdateRamen(id, meatid, name, broth, price);
        }

        public static void DeleteRamen(int id)
        {
            RamenRepository.DeleteRamen(id);
        }
    }
}