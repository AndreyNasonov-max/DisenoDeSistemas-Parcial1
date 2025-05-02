using OfficeOpenXml;
using SistemaMarketing.Models;
using System.Collections.Generic;

namespace SistemaMarketing.Services
{
    public class ExcelService
    {
        public byte[] Generar(List<Cliente> datos)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Clientes");
                
                // Headers
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Nombre";
                worksheet.Cells[1, 3].Value = "Email";
                
                // Data
                for (int i = 0; i < datos.Count; i++)
                {
                    worksheet.Cells[i+2, 1].Value = datos[i].Id;
                    worksheet.Cells[i+2, 2].Value = datos[i].Nombre;
                    worksheet.Cells[i+2, 3].Value = datos[i].Email;
                }
                
                worksheet.Cells.AutoFitColumns();
                return package.GetAsByteArray();
            }
        }
    }
}