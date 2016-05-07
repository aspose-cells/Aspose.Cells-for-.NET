<html>
<head>
  <title>Aspose.Cells classical ASP - JavaScript Example</title>
</head>
<body>

   <h3>Aspose.Cells classical ASP - JavaScript Example</h3>
      //Create a Workbook object
      var xls;
      xls = new ActiveXObject("Aspose.Cells.Workbook");
      
      //Open a designer file (template)
      xls.Open_5("f:\\test\\Book1.xls");
      
      //Put data into the workbook
      var sheet;
      
      //Get the first worksheet (default worksheet)
      sheet = xls.worksheets.item(0);
      var cells;
      cells = sheet.cells;
      var cell;
      cell = cells.item_3("A1");
      cell.PutValue_5("Hello World!");
      
      //Save the document to disk.
      xls.Save_4("f:\\test\\testfile.xls");

</body>
</html> 
