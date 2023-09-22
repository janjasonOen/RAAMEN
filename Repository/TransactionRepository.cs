using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Factory;
using Final_Project.Model;


namespace Final_Project.Repository
{
    public class TransactionRepository
    {
        public static Database1Entities1 db = new Database1Entities1();
        public static int createHeader(int customerId)
        {
            Header h = TransactionFactory.createHeader(customerId);
            db.Headers.Add(h);
            db.SaveChanges();
            return h.id;
        }

        public static string createDetails(int headerId, int ramenId, int quantity)
        {
            Detail det = TransactionFactory.createDetail(headerId, ramenId, quantity);
            db.Details.Add(det);
            db.SaveChanges();
            return "New Details Added Succesfully";
        }

        public static List<Header> getHeader(int customerId)
        {
            if(customerId != 0)
            {
                return (from x in db.Headers where x.Customerid == customerId select x).ToList();
            }
            //Custid of 0 indicates that an admin is requesting all transactions
            else
            {
                return db.Headers.ToList();
            }
        }

        public static List<Header> getStaffHeaders(int mode)
        {
            //0 Indicates unhandled
            if (mode == 0)
            {
                return (from x in db.Headers where x.staffid == 0 select x).ToList();
            }
            //other than 0 indicates handled
            else
            {
                return (from x in db.Headers where x.staffid != 0 select x).ToList();
            }
        }

        public static List<DetailRes> getDetail(int headerId)
        {
            List<DetailRes> details = (from x in db.Ramen
                                       join y in db.Details on x.id equals y.Ramenid
                                       where y.Headerid == headerId
                                       select new DetailRes
                                       {
                                           id = x.id,
                                           ramenName = x.Name,
                                           broth = x.Broth,
                                           quantity = y.Quantity,
                                           price = x.Price,
                                       }).ToList();
            return details;
        }

        public static string updateHeaders(int headerId, int staffId)
        {
            Header header = db.Headers.Find(headerId);
            if(header == null)
            {
                return "Update failed!";
            }

            header.staffid = staffId;
            db.SaveChanges();
            return "Update Success!";
        }
    }
}