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



        public async Task<long> Add(Customer cus)
        {
            // handle 
            try
            {
                _context.Add(cus);
                await _context.SaveChangesAsync();
                List<Customer> list = await _context.Customer.FromSql("exec sp_SelectLastIdCus").ToListAsync();
                long cusId = list[0].Id;
                return cusId;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = await _context.Customer.ToListAsync();

            return customers;

        }
    }
}
