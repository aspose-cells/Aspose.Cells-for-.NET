using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class LoadWorkbookWithSpecificCultureInfoNumberFormat
    {
        public static void Run()
        {
            // ExStart:LoadWorkbookWithSpecificCultureInfoNumberFormat
            using (var inputStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(inputStream))
                {
                    writer.WriteLine("<html><head><title>Test Culture</title></head><body><table><tr><td>1234,56</td></tr></table></body></html>");
                    writer.Flush();

                    var culture = new CultureInfo("en-GB");
                    culture.NumberFormat.NumberDecimalSeparator = ",";
                    culture.DateTimeFormat.DateSeparator = "-";
                    culture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

                    LoadOptions options = new LoadOptions(LoadFormat.Html);
                    options.CultureInfo = culture;

                    using (var workbook = new Workbook(inputStream, options))
                    {
                        var cell = workbook.Worksheets[0].Cells["A1"];
                        Assert.AreEqual(CellValueType.IsNumeric, cell.Type);
                        Assert.AreEqual(1234.56, cell.DoubleValue);
                    }
                }
            }
            // ExEnd:LoadWorkbookWithSpecificCultureInfo
        }
    }
}
