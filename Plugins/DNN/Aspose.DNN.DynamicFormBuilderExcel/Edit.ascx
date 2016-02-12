<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="Aspose.DotNetNuke.Modules.AsposeDynamicFormGeneratorExcel.Edit" %>

<div class="dnnClear dnnForm">
    <span id="success_msg" runat="server" visible="false" class="dnnFormMessage dnnFormSuccess"></span>
    <span id="info_msg" runat="server" visible="false" class="dnnFormMessage dnnFormInfo"></span>
    <span id="error_msg" runat="server" visible="false" class="dnnFormMessage dnnFormError"></span>
    <fieldset>
        <div align="lef">
            <h2>
                <img src="/DesktopModules/Aspose.DNN.DynamicFormGenerator.Excel/Images/aspose_logo.gif" />&nbsp;<asp:Label ID="lblTitle" runat="server">Export Data using Aspose.Cells for .NET</asp:Label></h2>
        </div>
        <div class="dnnFormItem">
            <asp:Label ID="lblFieldType" Font-Bold="true" runat="server" Text="Aspose.Cells Export Type"></asp:Label>
            <br />
            <asp:DropDownList ID="ExportTypeDropDown" runat="server">
                <asp:ListItem Text="Excel Workbook (*.xlsx)" Selected="True" Value="xlsx"></asp:ListItem>
                <asp:ListItem Text="Excel Binary Workbook (*.xlsb)" Value="xlsb"></asp:ListItem>
                <asp:ListItem Text="Excel 97-2003 Workbook (*.xls)" Value="xls"></asp:ListItem>
                <asp:ListItem Text="Text (Tab delimited) (*.txt)" Value="txt"></asp:ListItem>
                <asp:ListItem Text="CSV (Comma delimited) (*.csv)" Value="csv"></asp:ListItem>
                <asp:ListItem Text="OpenDocument Spreadsheet (*.ods)" Value="ods"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="ProcessButton" CssClass="dnnPrimaryAction" runat="server" Visible="true" OnClick="ProcessButton_Click" Text="Export Data"></asp:Button>
        </div>
    </fieldset>

    <br />
    .
</div>
