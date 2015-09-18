<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="Aspose.Excel.GridViewExport.Website.Default" %>

<%@ Register TagPrefix="aspose" Namespace="Aspose.Excel.GridViewExport" Assembly="Aspose.Excel.GridViewExport" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .myClass
        {
            clear: both;
        }
        
        .myClass input
        {
            float: right;
        }
    </style>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css" />
    <!-- Optional theme -->
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap-theme.min.css" />
    <!-- Latest compiled and minified JavaScript -->
    <script type="text/javascript" src="http://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <aspose:ExportGridViewToExcel Width="800px" ID="ExportGridViewToExcel1" ExportButtonText="Export to Excel"
            CssClass="table table-hover table-bordered" ExportButtonCssClass="myClass" ExcelOutputFormat="xlsx"
            ExportOutputPathOnServer="c:\\temp" ExportFileHeading="<h1>Example Report</h1>"
            OnPageIndexChanging="ExportGridViewToExcel1_PageIndexChanging" PageSize="5" AllowPaging="True"
            LicenseFilePath="c:\inetpub\Aspose.Total.lic" runat="server" CellPadding="4"
            ForeColor="#333333" GridLines="Both">
        </aspose:ExportGridViewToExcel>
    </div>
    </form>
</body>
</html>
