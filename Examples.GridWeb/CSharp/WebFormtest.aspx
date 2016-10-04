<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormtest.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.WebFormtest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div> 
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    <asp:Label ID="Label1" runat="server" Text="Label_hello"></asp:Label>
    <asp:ListBox ID="ListBox1" runat="server" 
        onselectedindexchanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
    </form>
</body>
</html>
