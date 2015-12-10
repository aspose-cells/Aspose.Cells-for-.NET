<%-- Copyright (c) Aspose Pty Limited. 2002-2015. All Rights Reserved.--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UmbracoDatabaseDataExporterToExcel.ascx.cs"
    Inherits="Aspose.UmbracoDatabaseDataExporterToExcel.UmbracoDatabaseDataExporterToExcel" %>
<link href="/UserControls/Aspose.UmbracoDatabaseDataExporterToExcel/Css/UmbracoDatabaseDataExporterToExcel.css"
    rel="stylesheet" type="text/css" media="all" />
<script type="text/javascript">
    function sourceChanged() {
        var objSource = document.getElementById("<%=ddlSource.ClientID%>");
        var objTables = document.getElementById("<%=ddlTables.ClientID%>");
        var objViews = document.getElementById("<%=ddlViews.ClientID%>");
        var objQuery = document.getElementById("<%=txtCustomQuery.ClientID%>");

        objTables.style["display"] = "none";
        objViews.style["display"] = "none";
        objQuery.style["display"] = "none";

        switch (objSource.value) {
            case "0":
                objTables.style["display"] = "block";
                break;
            case "1":
                objViews.style["display"] = "block";
                break;
            case "2":
                objQuery.style["display"] = "block";
                break;
        }
    }
</script>
<div class="aspsoeExporter">
    <h2>
        Aspose .NET Database Data Exporter to Excel using Aspose.Cells for Umbraco
    </h2>
    <h4>
        <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Text="" ForeColor="Maroon"></asp:Label></h4>
    <table width="100%">
        <tr>
            <td>
                <table class="tblBack">
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;Connection String <i>(MS SQL Server)</i>:
                        </td>
                        <td>
                            <asp:TextBox ID="txtConString" runat="server" Text="" MaxLength="200" CssClass="input"
                                Width="485px"></asp:TextBox>
                            <asp:Button ID="LoadButton" CssClass="buttonClass" runat="server" Visible="true"
                                OnClick="LoadButton_Click" Text="Re-Load"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;Type of Data Source:
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlSource" CssClass="input" Width="600px">
                                <asp:ListItem Selected="True" Value="0" Text="Tables"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Views"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Custom SQL Query"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;Data Source:
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlTables" CssClass="input" Width="600px">
                            </asp:DropDownList>
                            <asp:DropDownList runat="server" ID="ddlViews" Style="display: none;" CssClass="input"
                                Width="600px">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtCustomQuery" runat="server" TextMode="MultiLine" CssClass="input"
                                Style="display: none;" MaxLength="1000" Width="600px" Height="120px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;Aspose.Cells Export Type:
                        </td>
                        <td>
                            <asp:DropDownList ID="ExportTypeDropDown" runat="server" CssClass="input" Width="600px">
                                <asp:ListItem Text="Excel Workbook (*.xlsx)" Selected="True" Value="xlsx"></asp:ListItem>
                                <asp:ListItem Text="Excel Binary Workbook (*.xlsb)" Value="xlsb"></asp:ListItem>
                                <asp:ListItem Text="Excel 97-2003 Workbook (*.xls)" Value="xls"></asp:ListItem>
                                <asp:ListItem Text="Text (Tab delimited) (*.txt)" Value="txt"></asp:ListItem>
                                <asp:ListItem Text="CSV (Comma delimited) (*.csv)" Value="csv"></asp:ListItem>
                                <asp:ListItem Text="OpenDocument Spreadsheet (*.ods)" Value="ods"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            .
                        </td>
                        <td>
                            <asp:Button ID="ProcessButton" CssClass="buttonClass" runat="server" Visible="true"
                                OnClick="ProcessButton_Click" Text="Export Data"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
