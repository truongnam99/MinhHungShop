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
        public static async Task<ExcelPackage> CreateFileExcel(List<Product> data)
        {
            var excelPagkage = new ExcelPackage(new FileInfo("Excel\\template.xlsx"));
            var worksheet = excelPagkage.Workbook.Worksheets[1];
            int start = 2;
            for (int i = 0; i< data.Count; i++)
            {
                worksheet.Cells["A" + (i + start)].Value = data[i].Name;
                worksheet.Cells["B" + (i + start)].Value = data[i].Description;
                worksheet.Cells["C" + (i + start)].Value = data[i].Image;
                worksheet.Cells["D" + (i + start)].Value = data[i].Price;
                worksheet.Cells["E" + (i + start)].Value = data[i].Producer.Name;
                worksheet.Cells["F" + (i + start)].Value = data[i].ProducerId;
                worksheet.Cells["G" + (i + start)].Value = data[i].Category.Name;
                worksheet.Cells["H" + (i + start)].Value = data[i].CategoryId;
                worksheet.Cells["I" + (i + start)].Value = data[i].Detail;

            }

            return excelPagkage;
        }
    }
}
