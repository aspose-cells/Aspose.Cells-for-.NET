// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSpreadSheetWithOptions
{
    class Program
    {
        static void Main(string[] args)
        {
            SetPrintArea();
            SetPrintTitles();
            SetPrintArea();
            SetOtherPrintOptions();
        }
        public static void SetPrintArea()
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Obtaining the reference of the PageSetup of the worksheet
            PageSetup pageSetup = workbook.Worksheets[0].PageSetup;

            //Specifying the cells range (from A1 cell to T35 cell) of the print area
            pageSetup.PrintArea = "A1:T35";

        }
        public static void SetPrintTitles()
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Obtaining the reference of the PageSetup of the worksheet
            Aspose.Cells.PageSetup pageSetup = workbook.Worksheets[0].PageSetup;

            //Defining column numbers A & B as title columns
            pageSetup.PrintTitleColumns = "$A:$B";

            //Defining row numbers 1 & 2 as title rows
            pageSetup.PrintTitleRows = "$1:$2";
        }
        public static void SetOtherPrintOptions()
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Obtaining the reference of the PageSetup of the worksheet
            PageSetup pageSetup = workbook.Worksheets[0].PageSetup;

            //Allowing to print gridlines
            pageSetup.PrintGridlines = true;

            //Allowing to print row/column headings
            pageSetup.PrintHeadings = true;

            //Allowing to print worksheet in black & white mode
            pageSetup.BlackAndWhite = true;

            //Allowing to print comments as displayed on worksheet
            pageSetup.PrintComments = PrintCommentsType.PrintInPlace;

            //Allowing to print worksheet with draft quality
            pageSetup.PrintDraft = true;

            //Allowing to print cell errors as N/A
            pageSetup.PrintErrors = PrintErrorsType.PrintErrorsNA;
        }
        public static void SetPageOrder()
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Obtaining the reference of the PageSetup of the worksheet
            PageSetup pageSetup = workbook.Worksheets[0].PageSetup;

            //Setting the printing order of the pages to over then down
            pageSetup.Order = PrintOrderType.OverThenDown;
 
        }
    }
}
