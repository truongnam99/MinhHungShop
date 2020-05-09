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
        MinhHungShopContext dBContext = new MinhHungShopContext();
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

        public async Task<Utils.Status> Update(Product product)
        {
            try
            {
                Product iProduct = GetProduct(product.Id);
                iProduct.Producer = product.Producer;
                iProduct.Category = product.Category;
                iProduct.Name = product.Name;
                iProduct.Price = product.Price;
                iProduct.ProducerId = product.ProducerId;
                iProduct.CategoryId = product.CategoryId;
                iProduct.Image = product.Image;
                iProduct.Description = product.Description;
                iProduct.Detail = product.Detail;
                dBContext.Product.Update(iProduct);
                await dBContext.SaveChangesAsync();
                return Utils.Status.Success;
            }
            catch (Exception e)
            {
                return Utils.Status.Failed;
            }
        }

        public async Task<List<Product>> GetTop()
        {
            List<Product> top = await dBContext.Product.FromSql("exec sp_SelectTopProduct").ToListAsync();
            return top;
        }

        public async Task<List<Product>> GetProductByCategory(long id)
        {
            List<Product> products = await dBContext.Product.FromSql("exec sp_SelectProductByCategoryID @id=1").ToListAsync();
            return products;
        }

        public Product GetProduct(long? id)
        {
            return dBContext.Product.Find(id);
        }
        public async Task<List<ProductCategory>> GetCategory()
        {
            List<ProductCategory> categories  = await dBContext.ProductCategory.ToListAsync();

            return categories;
        }
    }
}
