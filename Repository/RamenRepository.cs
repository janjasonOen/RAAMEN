using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Model;
using Final_Project.Factory;

namespace Final_Project.Repository
{
    public class RamenRepository
    {
        public static Database1Entities1 db = new Database1Entities1();

        public static List<RamenRes> GetRamen()
        {
            List<RamenRes> res = (from x in db.Ramen join y in db.Meats on x.Meatid equals y.id select new RamenRes
            {
                id = x.id,
                meatName = x.Meat.meatName,
                name = x.Name,
                broth = x.Broth,
                price = x.Price,
            }).ToList();

            return res;
        }

        public static Ramen GetSingleRamen(int id)
        {
            return (from x in db.Ramen where x.id == id select x).FirstOrDefault();
        }

        public static string CreateRamen(int meatid, string name, string broth, string price)
        {
            Ramen ramen = RamenFactory.createRamen(meatid, name, broth, price);

            db.Ramen.Add(ramen);
            db.SaveChanges();

            return "Successfuly created ramen!";
        }
        
        public static string UpdateRamen(int id, int meatid, string name, string broth, string price)
        {
            Ramen ramen = db.Ramen.Find(id);
            if(ramen != null)
            {
                ramen.Meatid = meatid;
                ramen.Name = name;
                ramen.Broth = broth;
                ramen.Price = price;

                db.SaveChanges();
                return "Update Ramen Success!";
            }
            //This position should never be reached ini bisa dihapus nanti cuman buat testing purposes aja
            else
            {
                return ramen.id.ToString();
            }
        }

        public static void DeleteRamen(int id)
        {
            db.Ramen.Remove(db.Ramen.Find(id));
            db.SaveChanges();
        }
    }
} 