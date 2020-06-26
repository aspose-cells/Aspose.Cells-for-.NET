# Aspose.Cells for .NET

[Aspose.Cells for .NET](https://products.aspose.com/cells/net) is an Excel Spreadsheet Programming API allowing software developers to manipulate and convert spreadsheet files from within their applications. A combination of APIs and GUI controls - Aspose.Cells for .NET speeds up Microsoft Excel programming and conversion.

<p align="center">
  <a title="Download ZIP" href="https://github.com/aspose-cells/Aspose.Cells-for-.NET/archive/master.zip">
    <img src="http://i.imgur.com/hwNhrGZ.png" />
  </a>
</p>

This repository contains [Demos](Demos), [Examples](Examples), [Plugins](Plugins) and Showcases for [Aspose.Cells for .NET](https://products.aspose.com/cells/net) to help you learn and write your applications. 

Directory | Description
--------- | -----------
[Demos](Demos)  | Aspose.Cells for .NET Live Demos Source Code
[Examples](Examples)  | A collection of .NET examples that help you learn and explore the API features
[Examples_GridDesktop](Examples_GridDesktop)  | A collection of .NET examples that help you learn and use Aspose.Cells.GridDesktop
[Examples_GridWeb](Examples_GridWeb)  | A collection of .NET examples that help you learn and use Aspose.Cells.GridWeb
[Plugins](Plugins)  | Plugins that will demonstrate one or more features of Aspose.Cells for .NET

# .NET API for Excel File Formats

[Aspose.Cells for .NET](https://products.aspose.com/cells/net) is an Excel Spreadsheet Programming API to speed up spreadsheet management and processing tasks. Excel .NET API supports to build cross-platform applications having the ability to generate, modify, convert, render and print spreadsheets. It allows developers to manage worksheets, rows, columns & cells, create spreadsheet contents and styles from scratch, import data onto the worksheets from different data sources, add common and complex mathematical, financial and text formulas, create & manipulate pivot tables, charts, hyperlinks, comments, drawing objects and much more.

Aspose.Cells for .NET provides Grid solution with two GUI based .NET controls. [Aspose.Cells.GridDesktop](https://docs.aspose.com/display/cellsnet/Aspose.Cells.GridDesktop) supports desktop applications and [Aspose.Cells.GridWeb](https://docs.aspose.com/display/cellsnet/Aspose.Cells.GridWeb) is specifically designed for .NET based web applications. Both Gird controls allow to import/export Excel files, manipulate data & formatting, customize grid design and layout, manage multiple worksheets, create and calculate Excel formulas and numerous other Excel-like operations.

## Excel File Processing Features

- Spreadsheet generation & manipulation via API.
- High quality file format conversion & rendering.
- Print Microsoft Excel files to physical or virtual printers.
- Combine, modify, protect or parse Excel sheets.
- Apply worksheet formatting.
- Configure and apply page setup for the worksheets.
- Create & customize [Excel charts](https://docs.aspose.com/display/cellsnet/Creating+and+Customizing+Charts), [Pivot Tables](https://docs.aspose.com/display/cellsnet/Pivot+Tables), conditional formatting rules, [slicers](https://docs.aspose.com/display/cellsnet/Slicers), [tables](https://docs.aspose.com/display/cellsnet/Tables) & spark-lines.
- Convert Excel charts to images & PDF.
- Convert Excel files to various other formats.
- [Formula calculation engine](https://docs.aspose.com/display/cellsnet/Supported+Formula+Functions) that supports all basic and advanced Excel functions.

## Read & Write Spreadsheet Formats

**Microsoft Excel:** XLS, XLSX, XLSB, XLT, XLTX, XLTM, XLSM, XML\
**OpenOffice:** ODS\
**Text:** CSV, TSV\
**Web:** HTML, MHTML\
**Numbers:** Apple's iWork office suite Numbers app documents

## Save Excel Files As

**Fixed Layout:** PDF, PDF/A, XPS\
**Data Interchange:** DIF\
**Images:** JPEG, PNG, BMP, SVG, TIFF, EMF, GIF

## Platform Independence

Aspose.Cells for .NET can be used to build ASP.NET, Web Services, WinForms or other .NET applications for framework 2.0 or later on 32-bit and 64-bit operating systems. It also provides dedicated assemblies for Xamarin.Android (for native Android apps), Xamarin.iOS (for native iOS apps), COM (for pre-.NET technologies), Mono, and Windows Azure.

## Getting Started with Aspose.Cells for .NET

Are you ready to give Aspose.Cells for .NET a try? Simply execute `Install-Package Aspose.Cells` from Package Manager Console in Visual Studio to fetch the NuGet package. If you already have Aspose.Cells for .NET and want to upgrade the version, please execute `Update-Package Aspose.Cells` to get the latest version.

## Create XLSX Excel File from Scratch via C#

You can execute below code snippet to see how Aspose.Cells API performs in your environment or check the [GitHub Repository](https://github.com/aspose-cells/Aspose.Cells-for-.NET) for other common usage scenarios.

```csharp
// initiate an instance of Workbook
var book = new Aspose.Cells.Workbook();
// access first (default) worksheet
var sheet = book.Worksheets[0];
// access CellsCollection of first worksheet
var cells = sheet.Cells;
// write HelloWorld to cells A1
cells["A1"].Value = "Hello World";
// save spreadsheet to disc
book.Save("output.xlsx", SaveFormat.Xlsx);
```

## Convert Excel Files to PDF, XPS & HTML

Aspose.Cells for .NET is capable of converting spreadsheets to numerous other popular formats including PDF, XPS & HTML formats while maintaining the highest visual fidelity. The conversion process is simple, configurable and reliable.

```csharp
// load file to be converted
var workbook = new Aspose.Cells.Workbook(dir + "template.xlsx");
// save in different formats
workbook.Save(dir + "output.pdf", Aspose.Cells.SaveFormat.Pdf);
workbook.Save(dir + "output.xps", Aspose.Cells.SaveFormat.XPS);
workbook.Save(dir + "output.html", Aspose.Cells.SaveFormat.Html);
```

## Encrypt Excel File with C# Code

```csharp
var workbook = new Aspose.Cells.Workbook(dir+ "template.xls");

// specify XOR encryption type
workbook.SetEncryptionOptions(EncryptionType.XOR, 40);

// specify strong encryption type (RC4,Microsoft Strong Cryptographic Provider)
workbook.SetEncryptionOptions(EncryptionType.StrongCryptographicProvider, 128);

// protect the file
workbook.Settings.Password = "1234";

// save the file
workbook.Save(dir+ "output.xls");
```

## Use C# to Create an Excel Line Chart

```csharp
var workbook = new Aspose.Cells.Workbook();

// add a new worksheet to the Excel object
int sheetIndex = workbook.Worksheets.Add();

// obtain the reference of the newly added worksheet by passing its sheet index
Worksheet worksheet = workbook.Worksheets[sheetIndex];

// add sample values to cells
worksheet.Cells["A1"].PutValue(50);
worksheet.Cells["A2"].PutValue(100);
worksheet.Cells["A3"].PutValue(150);
worksheet.Cells["B1"].PutValue(4);
worksheet.Cells["B2"].PutValue(20);
worksheet.Cells["B3"].PutValue(50);

// add a chart to the worksheet
int chartIndex = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Line, 5, 0, 15, 5);

// access the instance of the newly added chart
var chart = worksheet.Charts[chartIndex];

// add chart data source from "A1" to "B3"
chart.NSeries.Add("A1:B3", true);

// save the Excel file
workbook.Save( dir + "output.xls");
```

### Examples_GridDesktop

* Aspose.Cells.GridDesktop examples are also included in Aspose.Cells GitHub repository and will be available as part of the ZIP file downloadable from here.
* All examples are located in the Examples_GridDesktop folder.
* Similar to Aspose.Cells examples, GridDesktop examples solution file name is **Aspose.Cells.GridDesktop.Examples.CSharp.sln**.
* Open the solution file in Visual Studio and build the project.
* All dependencies are included as part of the examples project. You may also download the DLLs separately from [here](https://downloads.aspose.com/cells/net)
* The Data folder at the root folder of Examples_GridDesktop contains input files used in the examples. It is mandatory that you download the Data folder along with the examples project.
* Open and run the project.
* Click on the example in the menu that you want to run from within the form.

### Examples_GridWeb

* Aspose.Cells.GridWeb examples are also included in Aspose.Cells GitHub repository and will be available as part of the ZIP file downloadable from here.
* All examples are located in the Examples_GridWeb folder.
* Similar to Aspose.Cells examples, GridWeb examples solution file name is **Aspose.Cells.GridWeb.Examples.CSharp.sln**.
* Open the solution file in Visual Studio and build the project.
* All dependencies are included as part of the examples project. You may also download the DLLs separately from [here](https://downloads.aspose.com/cells/net)
* The Data folder at the root folder of Examples_GridWeb contains input files used in the examples. It is mandatory that you download the Data folder along with the examples project.
* Open and run **Examples.aspx** in the examples project.
* Click on the example in the browser that you want to run from within the project.

Please find more details on how to run the examples [here](https://docs.aspose.com/display/cellsnet/How+to+Run+the+Examples).

[Product Page](https://products.aspose.com/cells/net) | [Docs](https://docs.aspose.com/display/cellsnet/Home) | [Demos](https://products.aspose.app/cells/family) | [API Reference](https://apireference.aspose.com/cells/net) | [Examples](https://github.com/aspose-cells/Aspose.Cells-for-.NET) | [Blog](https://blog.aspose.com/category/cells/) | [Free Support](https://forum.aspose.com/c/cells) |  [Temporary License](https://purchase.aspose.com/temporary-license)
