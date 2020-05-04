using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ProductBLL
    {
        DBContextIns dBContext = DBContextIns.getIns();
        private static ProductBLL Ins;

        private ProductBLL()
        {

        }

        public static ProductBLL getIns()
        {
            if (Ins == null)
            {
                Ins = new ProductBLL();
            }
            return Ins;
        }


        public async Task<Utils.Status> Add(Product product)
        {
            // handle 
            try
            {
                dBContext.Add(product);
                await dBContext.SaveChangesAsync();
                // return the status of handle: success or failed or...
                return Utils.Status.Success;
            }
            catch(Exception e)
            {
                return Utils.Status.Failed;
            }
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = await dBContext.Product.ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetTop()
        {
            List<Product> top = await dBContext.Product.FromSql("exec sp_SelectTopProduct").ToListAsync();
            return top;
        }

        public async Task<List<Product>> GetProductByCategory(long id)
        {
            //List<Product> products = await dBContext.Product.FindAsync()
            return null;
        }

        public Product GetProduct(long id)
        {
            return dBContext.Product.Find(id);
        }
    }
}
