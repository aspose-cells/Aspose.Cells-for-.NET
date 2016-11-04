<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="UsingCommonSubmitButton.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.UsingCommonSubmitButton" %>
<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <acw:GridWeb runat="server" ID="GridWeb1"></acw:GridWeb>
    <br />
    <asp:Button ID="SubmitButton" runat="server" Text="Submit Grid Data to Server" />
</asp:Content>
