using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Cells;

namespace InsertHyperlinksInWorksheet
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------------------------------------------------
            //  NPOI
            //----------------------------------------------------  
            //IWorkbook workbook = new XSSFWorkbook();
            //////cell style for hyperlinks
            //////by default hyperlinks are blue and underlined
            //ICellStyle hlink_style = workbook.CreateCellStyle();
            //IFont hlink_font = workbook.CreateFont();
            //hlink_font.Underline = FontUnderlineType.Single;
            //hlink_font.Color = HSSFColor.Blue.Index;
            //hlink_style.SetFont(hlink_font);

            //ICell cell;
            //ISheet sheet = workbook.CreateSheet("Hyperlinks");

            ////URL
            //cell = sheet.CreateRow(0).CreateCell(0);
            //cell.SetCellValue("URL Link");
            //XSSFHyperlink link = new XSSFHyperlink(HyperlinkType.Url);
            //link.Address = ("http://poi.apache.org/");
            //cell.Hyperlink = (link);
            //cell.CellStyle = (hlink_style);

            ////link to a file in the current directory
            //cell = sheet.CreateRow(1).CreateCell(0);
            //cell.SetCellValue("File Link");
            //link = new XSSFHyperlink(HyperlinkType.File);
            //link.Address = ("link1.xls");
            //cell.Hyperlink = (link);
            //cell.CellStyle = (hlink_style);

            ////e-mail link
            //cell = sheet.CreateRow(2).CreateCell(0);
            //cell.SetCellValue("Email Link");
            //link = new XSSFHyperlink(HyperlinkType.Email);
            ////note, if subject contains white spaces, make sure they are url-encoded
            //link.Address = ("mailto:poi@apache.org?subject=Hyperlinks");
            //cell.Hyperlink = (link);
            //cell.CellStyle = (hlink_style);

            ////link to a place in this workbook

            ////Create a target sheet and cell
            //ISheet sheet2 = workbook.CreateSheet("Target ISheet");
            //sheet2.CreateRow(0).CreateCell(0).SetCellValue("Target ICell");

            //cell = sheet.CreateRow(3).CreateCell(0);
            //cell.SetCellValue("Worksheet Link");
            //link = new XSSFHyperlink(HyperlinkType.Document);
            //link.Address = ("'Target ISheet'!A1");
            //cell.Hyperlink = (link);
            //cell.CellStyle = (hlink_style);

            //FileStream sw = File.Create("test.xlsx");
            //workbook.Write(sw);
            //sw.Close();

            //----------------------------------------------------
            //  Aspose.Cells
            //----------------------------------------------------
            Workbook workbook = new Workbook(); // Creating a Workbook object
            Worksheet sheet = workbook.Worksheets.Add("Hyperlinks");
            HyperlinkCollection hyperlinks = sheet.Hyperlinks;
            
            Style style = new Style();
            style.Font.Underline = FontUnderlineType.Single;
            style.Font.Color = System.Drawing.Color.Blue;

            sheet.Cells[0, 0].Value = "URL Link";
            hyperlinks.Add(0, 0, 1, 1, "http://www.aspose.com");
            sheet.Cells[0, 0].SetStyle(style);

            //link to a file in the current directory
            sheet.Cells[1, 0].Value = "File Link";
            hyperlinks.Add(1, 0, 1, 1, "book1.xls");
            sheet.Cells[1, 0].SetStyle(style);

            //e-mail link
            sheet.Cells[2, 0].Value = "Email Link";
            hyperlinks.Add(2, 0, 1, 1, "mailto:marketplace@aspose.com?subject=Hyperlinks");
            sheet.Cells[2, 0].SetStyle(style);
            
            //link to a place in this workbook
            Worksheet sheet2 = workbook.Worksheets.Add("Target ISheet");
            HyperlinkCollection hyperlinks2 = sheet2.Hyperlinks;
            sheet2.Cells[3, 0].Value = "Worksheet Link";
            hyperlinks2.Add(3, 0, 1, 1, "Target ISheet!A4");
            sheet2.Cells[3, 0].SetStyle(style);
            
            workbook.Save("test.xlsx");
        }
    }
}
