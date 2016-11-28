<%@ Page Title="Resize Rows/Columns - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
     CodeBehind="ResizeRowsColumns.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.RowsAndColumns.ResizeRowsColumns" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Resize Rows/Columns - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Reload</b> to reload data from data source. Click
            <ul>
                <li><b>Set Column Width</b> to see how column width is changed in GridWeb</li>
                <li><b>Set Row Height</b> to see how row height is changed in GridWeb</li>
            </ul>
        </p>
        <br />
        <div style="text-align: left">
            <table>
                <tr>
                    <td>
                        Reload Data:<asp:Button ID="btnReload" runat="server" Text="Reload" OnClick="btnReload_Click">
                        </asp:Button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Group1" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Group2" />
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        Resize Column:
                    </td>
                    <td>
                        Column Index:<asp:TextBox ID="txtColumnIndex" runat="server" Width="20px">2</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtColumnIndex" Text="*"
                            ErrorMessage="Column index is required" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtColumnIndex"  Text="*"
                            ErrorMessage="Enter a valid number for column index" Display="static" ValidationExpression="^\d+$" ValidationGroup="Group1"></asp:RegularExpressionValidator>

                        Column Width:<asp:TextBox ID="txtColumnWidth" runat="server" Width="20px">30</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtColumnWidth" Text="*"
                            ErrorMessage="Column width is required" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtColumnWidth" Text="*"
                            ErrorMessage="Enter a valid number for column width" Display="static" ValidationExpression="^\d+$" ValidationGroup="Group1"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnSetColumnWidth" runat="server" Text="Set Column Width" Width="120" OnClick="btnSetColumnWidth_Click"
                            ValidationGroup="Group1"></asp:Button>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                       Resize Row:
                    </td>
                    <td>
                        Row Index:<asp:TextBox ID="txtRowIndex" runat="server" Width="20px">2</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRowIndex" Text="*"
                            ErrorMessage="Row index is required" Display="Dynamic" ValidationGroup="Group2"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtRowIndex"  Text="*"
                            ErrorMessage="Enter a valid number for row index" Display="static" ValidationExpression="^\d+$" ValidationGroup="Group2"></asp:RegularExpressionValidator>

                        Row Height:<asp:TextBox ID="txtRowHeight" runat="server" Width="20px">30</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRowHeight" Text="*"
                            ErrorMessage="Row height is required" Display="Dynamic" ValidationGroup="Group2"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRowHeight"  Text="*"
                            ErrorMessage="Enter a valid number for row height" Display="static" ValidationExpression="^\d+$" ValidationGroup="Group2"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnSetRowHeight" runat="server" Text="Set Row Height" Width="120" OnClick="btnSetRowHeight_Click"
                            ValidationGroup="Group2"></asp:Button>&nbsp;
                    </td>
                </tr>         
            </table>
            <table>
                <tr>
                    <td>
                        <b>Note: </b> Indexes are zero-based.
                    </td>
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" Width="795px" Height="600px"
                            MaxColumn="5" PresetStyle="Professional1"
                            ShowLoading="false" XhtmlMode="True">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
