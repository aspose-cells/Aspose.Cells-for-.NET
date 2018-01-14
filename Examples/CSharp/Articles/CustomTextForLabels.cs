using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Charts;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class CustomTextForLabels
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Loads an existing spreadsheet containing a pie chart
            Workbook book = new Workbook(sourceDir + "sampleCustomTextForLabels.xlsx");

            // Assigns the GlobalizationSettings property of the WorkbookSettings class to the class created in first step
            book.Settings.GlobalizationSettings = new CustomSettings();

            // Accesses the 1st worksheet from the collection which contains pie chart
            Worksheet sheet = book.Worksheets[0];

            // Accesses the 1st chart from the collection
            Chart chart = sheet.Charts[0];

            // Refreshes the chart
            chart.Calculate();

            // Renders the chart to image
            chart.ToImage(outputDir + "outputCustomTextForLabels.png", new ImageOrPrintOptions());

            Console.WriteLine("CustomTextForLabels executed successfully.");
        }

        // Defines a custom class inherited by GlobalizationSettings class
        class CustomSettings : GlobalizationSettings
        {
            // Overrides the GetOtherName method
            public override string GetOtherName()
            {
                // Gets the culture identifier for the current system
                int lcid = System.Globalization.CultureInfo.CurrentCulture.LCID;
                switch (lcid)
                {
                    // Handles case for English
                    case 1033:
                        return "Other";
                    // Handles case for French
                    case 1036:
                        return "Autre";
                    // Handles case for German
                    case 1031:
                        return "Andere";
                    // Handle other cases
                    default:
                        return base.GetOtherName();
                }
            }
        }//GlobalizationSettings
    }
}
