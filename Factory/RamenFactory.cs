using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Model;

namespace Final_Project.Factory
{
    public class RamenFactory
    {
        public static Ramen createRamen(int meatid, string name, string broth, string price)
        {
            Ramen newRamen = new Ramen()
            {
                Meatid = meatid,
                Name = name,
                Broth = broth,
                Price = price,
            };

            return newRamen;
        }
    }
}