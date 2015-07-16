<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/umbraco/masterpages/umbracoPage.Master" CodeBehind="ExportToExcel.aspx.cs" Inherits="Aspose.UmbracoMemberExportToExcel.AsposeMemberExport" %>

<%@ Register Assembly="controls" Namespace="umbraco.uicontrols" TagPrefix="umbraco" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
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

    <style type="text/css">
        table.exportToExcelGridView {
            border: 1px solid #dbdbdb !important;
        }

            table.exportToExcelGridView td, table.exportToExcelGridView th {
                padding: 5px;
            }

            table.exportToExcelGridView thead {
                background-color: #f8f8f8;
                border: 1px solid #dbdbdb !important;
            }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <umbraco:UmbracoPanel ID="UmbracoPanel" Text="Aspose Member Export to Excel 1.0" runat="server">
        <asp:PlaceHolder ID="MemberExportPlaceHolder" runat="server">
            <div class="umb-pane ng-scope">
                <asp:Label ID="ErrorLabel" ForeColor="Red" Visible="false" runat="server"></asp:Label>
                <p>
                    Please select output format and select one or more members to export. By default all members are exported.
                </p>
                <umbraco:Pane ID="ExportTypePane" runat="server">
                    <umbraco:PropertyPanel ID="ExportTypePropertyPanel" Text="Export Output Format" runat="server">
                        <asp:DropDownList ID="ExportTypeDropDown" runat="server">
                            <asp:ListItem Text="Excel Workbook (*.xlsx)" Selected="True" Value="xlsx"></asp:ListItem>
                            <asp:ListItem Text="Excel Binary Workbook (*.xlsb)" Value="xlsb"></asp:ListItem>
                            <asp:ListItem Text="Excel 97-2003 Workbook (*.xls)" Value="xls"></asp:ListItem>
                            <asp:ListItem Text="Text (Tab delimited) (*.txt)" Value="txt"></asp:ListItem>
                            <asp:ListItem Text="CSV (Comma delimited) (*.csv)" Value="csv"></asp:ListItem>
                            <asp:ListItem Text="OpenDocument Spreadsheet (*.ods)" Value="ods"></asp:ListItem>
                        </asp:DropDownList>
                    </umbraco:PropertyPanel>
                </umbraco:Pane>
                <umbraco:Pane ID="Pane1" Style="margin-bottom: 20px;" runat="server">
                    <umbraco:PropertyPanel ID="PropertyPanel1" Text="Save copy to Disk" runat="server">
                        <asp:CheckBox ID="SaveCopyToDiskCheckBox" Checked="true" runat="server" />
                    </umbraco:PropertyPanel>
                </umbraco:Pane>
                <asp:GridView ID="UmbracoMembersGridView" EmptyDataText="There are no members." Width="100%" EmptyDataRowStyle-CssClass="emptyClass"
                    GridLines="None" BorderWidth="0" AutoGenerateColumns="False" HeaderStyle-CssClass="" EnableViewState="true"
                    CssClass="table table-striped exportToExcelGridView" DataKeyNames="Email" ClientIDMode="Static" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderStyle-CssClass="rgHeader" HeaderStyle-Width="35px">
                            <HeaderTemplate>
                                <asp:CheckBox ID="SelectAllCheckBox" CssClass="selectAllCheckBox" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="SelectedCheckBox" CssClass="selectableCheckBox" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Text" HeaderStyle-CssClass="rgHeader" HeaderText="Name" />
                        <asp:BoundField DataField="LoginName" HeaderStyle-CssClass="rgHeader" HeaderText="LoginName" />
                        <asp:BoundField DataField="Email" HeaderStyle-CssClass="rgHeader" HeaderText="Email" />
                        <asp:BoundField DataField="CreateDateTime" HeaderStyle-CssClass="rgHeader" HeaderText="CreateDateTime" />
                    </Columns>
                </asp:GridView>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="SavePlaceHolder" runat="server">
            <umbraco:Pane ID="ExportPane" runat="server">
                <asp:Button ID="ExportButton" runat="server" Text="Export" OnClick="ExportButton_Click" CssClass="btn btn-success" />
            </umbraco:Pane>
        </asp:PlaceHolder>
    </umbraco:UmbracoPanel>
</asp:Content>
