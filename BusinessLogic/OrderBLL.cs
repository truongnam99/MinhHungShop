using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
                orders.Status = false;
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

        public async Task<List<OrderView>> Get()
        {
            List<OrderView> list = new List<OrderView>();
            var query = _context.Customer
                           .Join(
                                _context.Orders,
                           customer => customer.Id,
                           order => order.CustomerId,
                        (customer, order) => new
                        {
                            OrderId = order.Id,
                            CustomerName = customer.Name,
                            CustomerAddress = customer.Address,
                            CustomerEmail = customer.Email,
                            CustomerPhone = customer.Phone,
                            Status = order.Status
                        }
                        ).ToList();

            foreach (var or in query)
            {
                OrderView order = new OrderView();
                order.OrderId = or.OrderId;
                order.CustomerName = or.CustomerName;
                order.CustomerEmail = or.CustomerEmail;
                order.CustomerPhone = or.CustomerPhone;
                order.CustomerAddress = or.CustomerAddress;
                order.Status = or.Status;
                list.Add(order);
            }
            return list;
        }
        public async Task<List<Product>> GetOrderDetail(long? id)
        {
            List<Product> list = new List<Product>();
            var query = _context.OrderDetail
                           .Join(
                                _context.Product,
                           od => od.ProductId,
                           pro => pro.Id,
                        (od, pro) => new
                        {
                            OrderId = od.OrderId,
                            Quantity = od.Quantity,
                            ProductName = pro.Name,
                            ProductImage = pro.Image,
                            ProductPrice = pro.Price
                        }
                        ).ToList();

            foreach (var item in query)
            {
                OrderView order = new OrderView();
               
                if(item.OrderId==id)
                {
                    Product product = new Product();
                    product.Name = item.ProductName;
                    product.Image = item.ProductImage;
                    product.Quantity = item.Quantity;
                    product.Price = item.ProductPrice;
                    list.Add(product);
                }
            }
            return list;
        }
        public async Task<Utils.Status> Remove(long? id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return Utils.Status.Success;
            }
            catch (Exception e)
            {
                return Utils.Status.Failed;
            }
        }
        public async Task<Utils.Status> UpdateStatus(long? id)
        {
            try
            {
                var entity = _context.Orders.FirstOrDefault(item => item.Id == id);

                // Validate entity is not null
                if (entity != null)
                {
                    // Answer for question #2

                    // Make changes on entity
                    if (entity.Status == false)
                        entity.Status = true;
                    // Update entity in DbSet
                    _context.Orders.Update(entity);

                    // Save changes in database
                    _context.SaveChanges();
                   
                }
                return Utils.Status.Success;
            }
            catch (Exception e)
            {
                return Utils.Status.Failed;
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
