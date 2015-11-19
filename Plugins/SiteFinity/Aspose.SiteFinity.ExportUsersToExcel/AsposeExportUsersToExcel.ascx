<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AsposeExportUsersToExcel.ascx.cs" Inherits="Aspose.SiteFinity.ExportUsersToExcel.AsposeExportUsersToExcel" %>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css">
<link rel="stylesheet" type="text/css" media="all" href="<%= ResolveUrl("~/Addons/Aspose.SiteFinity.ExportUsersToExcel/css/style.css") %>" />
<script type="text/javascript" language="javascript">

    $(document).ready(function () {
        $('.selectAllCheckBox input[type="checkbox"]').click(function (event) {  //on click
            if (this.checked) { // check select status
                $('.selectableCheckBox input[type="checkbox"]').each(function () { //loop through each checkbox
                    this.checked = true;  //select all checkboxes with class "checkbox1"              
                });
            } else {
                $('.selectableCheckBox input[type="checkbox"]').each(function () { //loop through each checkbox
                    this.checked = false; //deselect all checkboxes with class "checkbox1"                      
                });
            }
        });
    });
</script>
<h2 class="sub-header">Export Sitefinity Users to Excel</h2>
<p id="NoRowSelectedErrorDiv" runat="server" visible="false" class="bg-danger error">Please select one or more users to export.</p>
<div class="row">
    <ul class="list-inline pull-right">
        <li>
            <asp:DropDownList ID="ExportTypeDropDown" runat="server" CssClass="pull-right form-control">
                <asp:ListItem Text="Excel Workbook (*.xlsx)" Selected="True" Value="xlsx"></asp:ListItem>
                <asp:ListItem Text="Excel Binary Workbook (*.xlsb)" Value="xlsb"></asp:ListItem>
                <asp:ListItem Text="Excel 97-2003 Workbook (*.xls)" Value="xls"></asp:ListItem>
                <asp:ListItem Text="Text (Tab delimited) (*.txt)" Value="txt"></asp:ListItem>
                <asp:ListItem Text="CSV (Comma delimited) (*.csv)" Value="csv"></asp:ListItem>
                <asp:ListItem Text="OpenDocument Spreadsheet (*.ods)" Value="ods"></asp:ListItem>
            </asp:DropDownList>
        </li>
        <li>
            <asp:Button ID="ExportButton" CssClass="btn btn-primary pull-right" runat="server" Text="Export" OnClick="ExportButton_Click"></asp:Button>
        </li>
    </ul>
</div>
<div class="row">
    <asp:GridView ID="SitefinityUsersGridView" EmptyDataText="There are no users." Width="100%" EmptyDataRowStyle-CssClass="emptyClass"
        GridLines="None" BorderWidth="0" AutoGenerateColumns="false"
        CssClass="table table-striped" DataKeyNames="Email" ClientIDMode="Static" runat="server">
        <Columns>
            <asp:TemplateField HeaderStyle-CssClass="rgHeader" HeaderStyle-Width="20px">
                <HeaderTemplate>
                    <asp:CheckBox ID="SelectAllCheckBox" CssClass="selectAllCheckBox" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="SelectedCheckBox" CssClass="selectableCheckBox" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Username" HeaderText="Username" />
            <asp:BoundField DataField="FirstName" HeaderText="Firstname" />
            <asp:BoundField DataField="LastName" HeaderText="Lastname" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
        </Columns>
    </asp:GridView>
</div>
