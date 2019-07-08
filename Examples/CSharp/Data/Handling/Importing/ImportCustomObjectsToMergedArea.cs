using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Cells.Examples.CSharp.Data.Handling.Importing
{
    // ExStart: 1
    public class ImportCustomObjectsToMergedArea
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(sourceDir + "sampleMergedTemplate.xlsx");
            List<Product> productList = new List<Product>();

            //Creating collection of test items
            for (int i = 0; i < 3; i++)
            {
                Product product = new Product
                {
                    ProductId = i,
                    ProductName = "Test Product - " + i
                };
                productList.Add(product);
            }
            ImportTableOptions tableOptions = new ImportTableOptions();
            tableOptions.CheckMergedCells = true;
            tableOptions.IsFieldNameShown = false;

            //Insert data to excel template
            workbook.Worksheets[0].Cells.ImportCustomObjects((ICollection)productList, 1, 0, tableOptions);
            workbook.Save(outputDir + "sampleMergedTemplate_out.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("ImportCustomObjectsToMergedArea executed successfully.\r\n");
        }
    }

    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
    }
    // ExEnd: 1
}