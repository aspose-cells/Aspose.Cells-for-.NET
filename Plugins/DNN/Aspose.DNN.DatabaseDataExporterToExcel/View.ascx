<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Aspose.DotNetNuke.Modules.AsposeDNNDataExporterExcel.View" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

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
<div class="dnnClear dnnForm">
    <span id="success_msg" runat="server" visible="false" class="dnnFormMessage dnnFormSuccess"></span>
    <span id="info_msg" runat="server" visible="false" class="dnnFormMessage dnnFormInfo"></span>
    <span id="error_msg" runat="server" visible="false" class="dnnFormMessage dnnFormError"></span>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="Label1" CssClass="SubHead" ResourceKey="ConnectionString"></dnn:Label>
            <asp:TextBox ID="txtConString" runat="server" Text="" MaxLength="200" CssClass="AsposeConnectionClass"></asp:TextBox>
            <asp:Button ID="LoadButton" CssClass="dnnPrimaryAction" runat="server" Visible="true" OnClick="LoadButton_Click" resourcekey="Load"></asp:Button>
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblSourceType" CssClass="SubHead" ResourceKey="SourceType"></dnn:Label>
            <asp:DropDownList runat="server" ID="ddlSource" CssClass="AsposeDropDownClass">
                <asp:ListItem Selected="True" Value="0" resourcekey="Tables"></asp:ListItem>
                <asp:ListItem Value="1" resourcekey="Views"></asp:ListItem>
                <asp:ListItem Value="2" resourcekey="Query"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblSource" CssClass="SubHead" ResourceKey="Source"></dnn:Label>
            <asp:DropDownList runat="server" ID="ddlTables" CssClass="AsposeDropDownClass">
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlViews" Style="display: none;" CssClass="AsposeDropDownClass">
            </asp:DropDownList>
            <asp:TextBox ID="txtCustomQuery" runat="server" TextMode="MultiLine" CssClass="AsposeCustomQueryClass"
                Style="display: none;" MaxLength="1000"></asp:TextBox>
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="ExportType" CssClass="SubHead" ResourceKey="ExportType"></dnn:Label>
            <asp:DropDownList ID="ExportTypeDropDown" runat="server">
                <asp:ListItem Text="Excel Workbook (*.xlsx)" Selected="True" Value="xlsx"></asp:ListItem>
                <asp:ListItem Text="Excel Binary Workbook (*.xlsb)" Value="xlsb"></asp:ListItem>
                <asp:ListItem Text="Excel 97-2003 Workbook (*.xls)" Value="xls"></asp:ListItem>
                <asp:ListItem Text="Text (Tab delimited) (*.txt)" Value="txt"></asp:ListItem>
                <asp:ListItem Text="CSV (Comma delimited) (*.csv)" Value="csv"></asp:ListItem>
                <asp:ListItem Text="OpenDocument Spreadsheet (*.ods)" Value="ods"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </fieldset>
    <div class="dnnFormItem">
        <asp:Button ID="ProcessButton" CssClass="dnnPrimaryAction" runat="server" Visible="true" OnClick="ProcessButton_Click" resourcekey="Export"></asp:Button>
    </div>
</div>
