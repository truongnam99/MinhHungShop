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

        public async Task<List<object>> OrderByMonths()
        {
            try
            {
                string query = @"select Top 6 FORMAT(CreatedDate, 'yyyy_MM') AS CreatedMonth, COUNT(FORMAT(CreatedDate, 'yyyy_MM')) as count from Orders
                group by FORMAT(CreatedDate, 'yyyy_MM')
                order by CreatedMonth";
                List<object> result = new List<object>();
                SqlConnection connection = new SqlConnection("Server=DESKTOP-1GUJ3IL\\SQLEXPRESS;Database=MinhHungShop;Trusted_Connection=True;");
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Add(new
                            {
                                CreatedMonth = reader[0].ToString(),
                                Count = reader[1].ToString()
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
