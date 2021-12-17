using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExcelToEditCore.Models;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.Collections.Generic;

namespace ExcelToEditCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public HomeController(IHostingEnvironment _hostingEnvironment)
        {
            hostingEnvironment = _hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Import()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "UploadExcel";
            string webRootPath = hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            StringBuilder sb = new StringBuilder();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    //to set new column in header row
                    headerRow.CreateCell(headerRow.LastCellNum + 1).SetCellValue("Total Marks");
                    headerRow.CreateCell(headerRow.LastCellNum + 1).SetCellValue("Percentage");
                    headerRow.CreateCell(headerRow.LastCellNum + 1).SetCellValue("Rank");
                    headerRow.CreateCell(headerRow.LastCellNum + 1).SetCellValue("Percentile");
                    //end here 
                    int cellCount = headerRow.LastCellNum;
                    sb.Append("<table class='table table-bordered'border='1'><tr>");
                    for (int j = 0; j < cellCount; j++)
                    {
                        NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                        {
                            continue;
                        }
                        sb.Append("<th>" + cell.ToString() + "</th>");
                    }
                    sb.Append("</tr>");
                    sb.AppendLine("<tr>");
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null)
                        {
                            continue;
                        }
                        //calculate here 
                        row.CreateCell(5, CellType.Numeric).SetCellValue(Convert.ToDouble(row.Cells[1].ToString()) + Convert.ToDouble(row.Cells[2].ToString()) + Convert.ToDouble(row.Cells[3].ToString()));
                        row.CreateCell(6, CellType.String).SetCellValue(((Convert.ToDouble(row.Cells[4].ToString()) * 100) / 300).ToString("#.00") + "%");
                        row.CreateCell(7, CellType.String).SetCellValue(getpercentile(sheet, Convert.ToDouble(row.Cells[4].ToString()))[0]);
                        row.CreateCell(8, CellType.String).SetCellValue(getpercentile(sheet, Convert.ToDouble(row.Cells[4].ToString()))[1] );

                        //end here
                        if (row.Cells.All(d => d.CellType == CellType.Blank))
                        {
                            continue;
                        }
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                sb.Append("<td>" + row.GetCell(j).ToString() + "</td>");
                        }
                        sb.AppendLine("</tr>");
                    }
                    sb.Append("</table>");
                }
            }
            return this.Content(sb.ToString());
        }
        private string[] getpercentile(ISheet sheet, double total)
        {
            string[] strrankandpercentile = new string[2];
            List<double> lsttotal = new List<double>();
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
            {
                IRow row = sheet.GetRow(i);
                if (row == null)
                {
                    continue;
                }
                //calculate rank here here 
                var totalmarks = (Convert.ToDouble(row.Cells[1].ToString()) + Convert.ToDouble(row.Cells[2].ToString()) + Convert.ToDouble(row.Cells[3].ToString()));
                lsttotal.Add(totalmarks);
            }
            lsttotal.Sort();
            lsttotal.Reverse();
            //to get index as rank 
            strrankandpercentile[0] = (lsttotal.FindIndex(x => x.Equals(total)) + 1).ToString();
            //to get percentile
            int less = 0;
            int equal = 0;
            int count = 0;
            foreach (var item in lsttotal)
            {
                if (total > item)
                {
                    less++;
                }
                else if (total == item)
                {
                    equal++;
                }
                count++;
            }
            double percentile = ((less + (0.5 * equal)) / count) * 100;
            strrankandpercentile[1] = percentile.ToString();
            return strrankandpercentile;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
