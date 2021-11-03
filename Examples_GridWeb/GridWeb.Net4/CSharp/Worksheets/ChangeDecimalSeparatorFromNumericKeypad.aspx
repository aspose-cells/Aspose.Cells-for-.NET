<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeDecimalSeparatorFromNumericKeypad.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.ChangeDecimalSeparatorFromNumericKeypad" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="/Scripts/jquery-ui.css" />
    <script src="/Scripts/jquery-2.1.1.js"></script>
    <script src="/Scripts/jquery-ui.js"></script>
    <title>Change Decimal Separator From Numeric Keypad</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <b>GridWeb Version:</b> <%=Aspose.Cells.GridWeb.GridWeb.GetVersion()%>
            <br />
            <acw:GridWeb ID="GridWeb1" runat="server" ShowLoading="true" XhtmlMode="true" EnableAJAX="true" EnableAsync="true">
            </acw:GridWeb>
        </div>
    </form>
</body>
</html>
