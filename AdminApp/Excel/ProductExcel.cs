using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Drawing;
using DataAccess.Entities;

namespace AdminApp.Controllers
{
    public class ProductExcel
    {
        public static async Task<ExcelPackage> CreateFileExcel(List<Product> products
            , List<Producer> producers, List<ProductCategory> categories)
        {
            var excelPagkage = new ExcelPackage(new FileInfo("Excel\\template.xlsx"));
            var worksheet = excelPagkage.Workbook.Worksheets[1];
            int start = 2;
            for (int i = 0; i< products.Count; i++)
            {
                worksheet.Cells["A" + (i + start)].Value = products[i].Name;
                worksheet.Cells["B" + (i + start)].Value = products[i].Description;
                worksheet.Cells["C" + (i + start)].Value = products[i].Image;
                worksheet.Cells["D" + (i + start)].Value = products[i].Price;
                worksheet.Cells["E" + (i + start)].Value = products[i].Producer.Name;
                worksheet.Cells["F" + (i + start)].Value = products[i].ProducerId;
                worksheet.Cells["G" + (i + start)].Value = products[i].Category.Name;
                worksheet.Cells["H" + (i + start)].Value = products[i].CategoryId;
                worksheet.Cells["I" + (i + start)].Value = products[i].Detail;
            }
            worksheet = excelPagkage.Workbook.Worksheets[2];
            for (int i = 0; i < categories.Count; i++)
            {
                worksheet.Cells["A" + (i + start)].Value = categories[i].Id;
                worksheet.Cells["B" + (i + start)].Value = categories[i].Name;
                worksheet.Cells["C" + (i + start)].Value = categories[i].DisplayOrder;
                worksheet.Cells["D" + (i + start)].Value = categories[i].ShowOnHome;
            }
            worksheet = excelPagkage.Workbook.Worksheets[3];
            for (int i = 0; i < products.Count; i++)
            {
                worksheet.Cells["A" + (i + start)].Value = products[i].Id;
                worksheet.Cells["B" + (i + start)].Value = products[i].Name;
                worksheet.Cells["C" + (i + start)].Value = products[i].Description;
            }

            return excelPagkage;
        }
    }
}
