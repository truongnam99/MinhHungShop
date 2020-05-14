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
        MinhHungShopContext _context = new MinhHungShopContext();
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
                _context.Add(product);
                await _context.SaveChangesAsync();
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
            List<Product> products = await _context.Product.Include(c => c.Category).Include(p => p.Producer).ToListAsync();



            return products;
        }

        public async Task<Utils.Status> Update(Product product)
        {
            try
            {
                Product iProduct = GetProduct(product.Id);
                iProduct.Name = product.Name;
                iProduct.Price = product.Price;
                iProduct.ProducerId = product.ProducerId;
                iProduct.CategoryId = product.CategoryId;
                iProduct.Image = product.Image;
                iProduct.Description = product.Description;
                iProduct.Detail = product.Detail;

                _context.Product.Update(iProduct);
                await _context.SaveChangesAsync();
                return Utils.Status.Success;
            }
            catch (Exception e)
            {
                return Utils.Status.Failed;
            }
        }

        public async Task<Utils.Status> Remove(long id)
        {
            try
            {
                var product = await _context.Product.FindAsync(id);
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
                return Utils.Status.Success;
            }
            catch (Exception e)
            {
                return Utils.Status.Failed;
            }
        }

        public async Task<List<Product>> GetTop()
        {
            List<Product> top = await _context.Product.FromSql("exec sp_SelectTopProduct").ToListAsync();
            return top;
        }

        public async Task<List<Product>> GetProductByCategory(long id)
        {
            List<Product> products = await _context.Product.FromSql("exec sp_SelectProductByCategoryID @id={0}",id).ToListAsync();
            return products;
        }

        public Product GetProduct(long? id)
        {
            return _context.Product.Find(id);
        }
        public async Task<List<ProductCategory>> GetCategory()
        {
            List<ProductCategory> categories  = await _context.ProductCategory.ToListAsync();

            return categories;
        }
    }
}
