using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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


        public async Task<long> Add(Orders orders)
        {
            // handle 
            try
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                List<Orders> list = await _context.Orders.FromSql("exec sp_SelectLastIdOrder").ToListAsync();
                long orderId = list[0].Id;
                return orderId;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public async Task<Utils.Status> AddOrderDetail(OrderDetail orderDetail)
        {
            // handle 
            try
            {
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                // return the status of handle: success or failed or...
                return Utils.Status.Success;
            }
            catch (Exception e)
            {
                return Utils.Status.Failed;
            }
        }
    }
}
