<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsingCommonSubmitButton.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Articles.UsingCommonSubmitButton" %>
<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <acw:GridWeb runat="server" ID="GridWeb1"></acw:GridWeb>
    <br />
    <asp:Button ID="SubmitButton" runat="server" Text="Submit Grid Data to Server" />
</asp:Content>
