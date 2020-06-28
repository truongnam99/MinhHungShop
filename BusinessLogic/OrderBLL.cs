using BLL.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public async Task<List<OrderByMonth>> OrderByMonths()
        {
            try
            {
                string query = @"select Top 6 FORMAT(CreatedDate, 'yyyy_MM') AS CreatedMonth, COUNT(FORMAT(CreatedDate, 'yyyy_MM')) as count from Orders
                group by FORMAT(CreatedDate, 'yyyy_MM')
                order by CreatedMonth";
                List<OrderByMonth> result = new List<OrderByMonth>();
                SqlConnection connection = new SqlConnection("Server=DESKTOP-1GUJ3IL\\SQLEXPRESS;Database=MinhHungShop;Trusted_Connection=True;");
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Add(new OrderByMonth()
                            {
                                month = reader[0].ToString(),
                                quantity = reader[1].ToString()
                            });
                        }
                    }
                    connection.Close();
                
                return result;

            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
