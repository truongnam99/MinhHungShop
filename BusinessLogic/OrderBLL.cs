using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class OrderBLL
    {
        MinhHungShopContext _context = new MinhHungShopContext();
        private static OrderBLL Ins;

        private OrderBLL()
        {

        }

        public static OrderBLL getIns()
        {
            if (Ins == null)
            {
                Ins = new OrderBLL();
            }
            return Ins;
        }


        public List<string> Add(Orders orders, Customer cus, OrderDetail orderDetail)
        {
            // handle 
            try
            {
                _context.Add(cus);
                _context.SaveChangesAsync();
                var cusId =Convert.ToString(_context.Customer.FromSql("SELECT IDENT_CURRENT('Customer')"));
              
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
