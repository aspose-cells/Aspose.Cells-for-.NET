<%@ Page Title="Aspose.Cells Known Issues" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="HTTPSSSLIssue.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.KnowledgeBase.KnownIssues.HTTPSSSLIssue" %>

<%@ Register assembly="Aspose.Cells.GridWeb" namespace="Aspose.Cells.GridWeb" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Button ID="btnDownload" runat="server" Text="Download Excel File" OnClick="btnDownload_Click" />
        <cc1:GridWeb ID="GridWeb1" runat="server" EnableAsync="True">
        </cc1:GridWeb>
    </div>
</asp:Content>
