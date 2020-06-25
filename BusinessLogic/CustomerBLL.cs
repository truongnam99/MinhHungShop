using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CustomerBLL
    {
        MinhHungShopContext _context = new MinhHungShopContext();
        private static CustomerBLL Ins;
        private CustomerBLL()
        {

        }

        public static CustomerBLL getIns()
        {
            if (Ins == null)
            {
                Ins = new CustomerBLL();
            }
            return Ins;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = await _context.Customer.ToListAsync();

            return customers;
        }
    }
}
