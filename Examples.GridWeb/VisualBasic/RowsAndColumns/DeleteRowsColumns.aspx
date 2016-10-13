<%@ Page Title="Delete Rows/Columns - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="DeleteRowsColumns.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.RowsAndColumns.DeleteRowsColumns" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-family: Arial; font-size: small;">
        <tbody>
            <tr>
                <td style="width: 19; vertical-align: top;">
                    <img alt="" height="41" src="/Common/images/heading_lft.jpg" width="19" />
                </td>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Delete Rows/Columns - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
                <td style="width: 19; vertical-align: top;">
                    <img alt="" height="41" src="/Common/images/heading_rt.jpg" width="19" />
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-family: Arial; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Reload</b> to reload data from data source. Click
            <ul>
                <li><b>Delete Column</b> to see how column is deleted in GridWeb</li>
                <li><b>Delete Row</b> to see how row is deleted in GridWeb</li>
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
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        Delete Column:
                    </td>
                    <td>
                        Column Index:<asp:TextBox ID="txtColumnIndex" runat="server" Width="20px">2</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtColumnIndex"  Text="*"
                            ErrorMessage="Column index is required" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtColumnIndex"  Text="*"
                            ErrorMessage="Enter a valid number for column index" Display="Dynamic" ValidationExpression="^\d+$" ValidationGroup="Group1"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnDeleteColumn" runat="server" Text="Delete Column" Width="100" OnClick="btnDeleteColumn_Click"
                            ValidationGroup="Group1"></asp:Button>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                       Delete Row:
                    </td>
                    <td>
                        Row Index:<asp:TextBox ID="txtRowIndex" runat="server" Width="20px">2</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRowIndex"  Text="*"
                            ErrorMessage="Row index is required" Display="Dynamic" ValidationGroup="Group2"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRowIndex"  Text="*"
                            ErrorMessage="Enter a valid number for row index" Display="Dynamic" ValidationExpression="^\d+$" ValidationGroup="Group2"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnDeleteRow" runat="server" Text="Delete Row" Width="100" OnClick="btnDeleteRow_Click"
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
                        <acw:GridWeb ID="GridWeb1" runat="server" Width="795px" ForceValidation="False" Height="600px"
                            MaxColumn="5" PresetStyle="Professional1"
                            ShowLoading="false" XhtmlMode="True">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
