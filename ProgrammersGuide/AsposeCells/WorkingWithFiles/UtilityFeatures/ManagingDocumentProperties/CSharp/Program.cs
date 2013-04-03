//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace ManagingDocumentProperties
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Instantiate a Workbook object
            //Open an Excel file
            Workbook workbook = new Workbook(dataDir + "Book1.xls");

            //Retrieve a list of all custom document properties of the Excel file
            Aspose.Cells.Properties.DocumentPropertyCollection customProperties = workbook.Worksheets.CustomDocumentProperties;

            //Accessing a custom document property by using the property index
            Aspose.Cells.Properties.DocumentProperty customProperty1 = customProperties[3];

            //Accessing a custom document property by using the property name
            Aspose.Cells.Properties.DocumentProperty customProperty2 = customProperties["Owner"];

            System.Console.WriteLine(customProperty1.Name + " -> " + customProperty1.Value);
            System.Console.WriteLine(customProperty2.Name + " -> " + customProperty2.Value);

            //Retrieve a list of all custom document properties of the Excel file
            Aspose.Cells.Properties.CustomDocumentPropertyCollection customPropertiesCollection = workbook.Worksheets.CustomDocumentProperties;

            //Adding a custom document property to the Excel file
            Aspose.Cells.Properties.DocumentProperty publisher = customPropertiesCollection.Add("Publisher", "Aspose");

            //Add link to content.
            customPropertiesCollection.AddLinkToContent("Owner", "MyRange");
            //Accessing the custom document property by using the property name
            Aspose.Cells.Properties.DocumentProperty customProperty3 = customPropertiesCollection["Owner"];
            //Check whether the property is lined to content
            bool islinkedtocontent = customProperty3.IsLinkedToContent;
            //Get the source for the property
            string source = customProperty3.Source;

            //Save the file with added properties
            workbook.Save(dataDir + "Test_Workbook.xls");

            //Removing a custom document property
            customProperties.Remove("Publisher");

            //Save the file with added properties
            workbook.Save(dataDir + "Test_Workbook_RemovedProperty.xls");

        }
    }
}