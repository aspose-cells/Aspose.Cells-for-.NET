<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Aspose.DNN.ExportUsersAndRolesToExcel.View" %>
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
<h2>Export Users and Roles</h2>
<div class="dnnFormMessage dnnFormWarning" runat="server" visible="false" id="NoRowSelectedErrorDiv">
    Please select one or more users to continue.
</div>
<div class="dnnFormMessage dnnFormSuccess" runat="server" visible="false" id="Success">
    Users and Roles Exported Successfully.
</div>
<ul class="dnnActions dnnClear">
    <li>
        <asp:DropDownList ID="ExportTypeDropDown" runat="server">
            <asp:ListItem Text="Excel Workbook (*.xlsx)" Selected="True" Value="xlsx"></asp:ListItem>
            <asp:ListItem Text="Excel Binary Workbook (*.xlsb)" Value="xlsb"></asp:ListItem>
            <asp:ListItem Text="Excel 97-2003 Workbook (*.xls)" Value="xls"></asp:ListItem>
            <asp:ListItem Text="Text (Tab delimited) (*.txt)" Value="txt"></asp:ListItem>
            <asp:ListItem Text="CSV (Comma delimited) (*.csv)" Value="csv"></asp:ListItem>
            <asp:ListItem Text="OpenDocument Spreadsheet (*.ods)" Value="ods"></asp:ListItem>            
        </asp:DropDownList>
    </li>
    <li>
        <asp:Button ID="ExportButton" CssClass="dnnPrimaryAction exportBtn"  OnClick="ExportButton_Click" runat="server" Text="Export"></asp:Button>
    </li>
</ul>
<asp:GridView ID="UsersGridView" Width="100%" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no contacts." CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="UserID">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:TemplateField HeaderStyle-CssClass="rgHeader" HeaderStyle-Width="20px">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="SelectAllCheckBox" CssClass="selectAllCheckBox" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="SelectedCheckBox" CssClass="selectableCheckBox" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
        <asp:BoundField DataField="DisplayName" HeaderText="Display Name" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="Roles" HeaderText="Roles" />
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:GridView>