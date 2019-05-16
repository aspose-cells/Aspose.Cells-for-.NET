using Aspose.Cells.WebExtensions;
using System;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    public class AccessWebExtensionInformation
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Load sample Excel file
            Workbook workbook = new Workbook(sourceDir + "WebExtensionsSample.xlsx");

            WebExtensionTaskPaneCollection taskPanes = workbook.Worksheets.WebExtensionTaskPanes;

            foreach (WebExtensionTaskPane taskPane in taskPanes)
            {
                Console.WriteLine("Width: " + taskPane.Width);
                Console.WriteLine("IsVisible: " + taskPane.IsVisible);
                Console.WriteLine("IsLocked: " + taskPane.IsLocked);
                Console.WriteLine("DockState: " + taskPane.DockState);
                Console.WriteLine("StoreName: " + taskPane.WebExtension.Reference.StoreName);
                Console.WriteLine("StoreType: " + taskPane.WebExtension.Reference.StoreType);
                Console.WriteLine("WebExtension.Id: " + taskPane.WebExtension.Id);
            }
            // ExEnd:1

            Console.WriteLine("AccessWebExtensionInformation executed successfully.");
        }
    }
}
