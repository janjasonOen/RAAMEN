using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Repository;
using Final_Project.Model;

namespace Final_Project.Handler
{
    public class TransactionHandler
    {
        public static string createTransaction(int customerId, Dictionary<int, int> ramenData)
        {
            int headerId = TransactionRepository.createHeader(customerId);

            if(headerId.ToString() != "")
            {
                foreach (var x in ramenData)
                {
                    TransactionRepository.createDetails(headerId, x.Key, x.Value);
                }
                return "Transaction Completed";
            }
            else
            {
                return "Transaction Failed!";
            }
        }
        public static List<Header> getHeader(int customerId)
        {
            return TransactionRepository.getHeader(customerId);
        }

        public static List<DetailRes> getDetail(int headerId)
        {
            return TransactionRepository.getDetail(headerId);
        }

        public static List<Header> getStaffHeader(int mode)
        {
            return (TransactionRepository.getStaffHeaders(mode));
        }

        public static string updateHeaders(int headerId, int staffId)
        {
            return TransactionRepository.updateHeaders(headerId, staffId);
        }
    }

   
}