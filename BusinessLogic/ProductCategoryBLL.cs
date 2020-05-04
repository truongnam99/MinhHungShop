using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ProductCategoryBLL
    {
        DBContextIns dBContext = DBContextIns.getIns();
        private static ProductCategoryBLL Ins;

        private ProductCategoryBLL()
        {

        }

        public static ProductCategoryBLL getIns()
        {
            if (Ins == null)
            {
                Ins = new ProductCategoryBLL();
            }
            return Ins;
        }

        public async Task<Utils.Status> Create(ProductCategory productCategory)
        {
            // handle 
            try
            {
                dBContext.Add(productCategory);
                await dBContext.SaveChangesAsync();
                // return the status of handle: success or failed or...
                return Utils.Status.Success;
            }
            catch (Exception e)
            {
                return Utils.Status.Failed;
            }
        }

        public async Task<List<ProductCategory>> GetProductCategories()
        {
            List<ProductCategory> productCategories = await dBContext.ProductCategory.ToListAsync();

            return productCategories;
        }

        public async Task<Utils.Status> Delete(long id)
        {
            // handle 
            try
            {
                var productCategory = await dBContext.ProductCategory.FindAsync(id);
                dBContext.ProductCategory.Remove(productCategory);
                await dBContext.SaveChangesAsync();
                //dBContext.ProductCategory.FromSql("exec sp_DeleteProductCategoryById", new SqlParameter("@ID",id));
                return Utils.Status.Success;
            }
            catch (Exception e)
            {
                return Utils.Status.Failed;
            }
        }

        public async Task<Utils.Status> Update(ProductCategory productCategory)
        {
            try
            {
                ProductCategory iProductCategory = await GetProductCategory(productCategory.Id);
                iProductCategory.MetaTitle = productCategory.MetaTitle;
                iProductCategory.ShowOnHome = productCategory.ShowOnHome;
                iProductCategory.Name = productCategory.Name;
                iProductCategory.DisplayOrder = productCategory.DisplayOrder;
                dBContext.ProductCategory.Update(iProductCategory);
                await dBContext.SaveChangesAsync();
                return Utils.Status.Success;
            }
            catch(Exception e)
            {
                return Utils.Status.Failed;
            }
        }

        public async Task<ProductCategory> GetProductCategory(long? id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }
                //ProductCategory productCategory = (await dBContext.ProductCategory.FromSql("exec sp_FindProductCategoryById @ID", id).ToListAsync())[0];
                
                return dBContext.ProductCategory.Find(id);
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
