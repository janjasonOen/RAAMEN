using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Model;

namespace Final_Project.Factory
{
    public class TransactionFactory
    {
        public static Detail createDetail(int headerId, int ramenId, int quantity)
        {
            Detail det = new Detail
            {
                Headerid = headerId,
                Ramenid = ramenId,
                Quantity = quantity,
            };

            return det;
        }

        public static Header createHeader(int custId)
        {
            Header h = new Header
            {
                Customerid = custId,
                staffid = 0,
                Date = DateTime.Now,
            };
            return h;
        }
    }
}