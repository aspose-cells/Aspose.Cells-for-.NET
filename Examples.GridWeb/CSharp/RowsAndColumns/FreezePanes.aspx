<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns.FreezePanes"
    MasterPageFile="~/Site.Master" Title="Freeze/Unfreeze Panes - Aspose.Cells Grid Suite Examples"
    CodeBehind="FreezePanes.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Freeze/Unfreeze Panes - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Freeze Pane</b> to see how rows and columns can be freezed in the GridWeb Control <br />
            or click <b>Unfreeze Pane</b> to unfreeze rows and columns in GridWeb Control.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td nowrap>
                        Row:<asp:TextBox ID="txtRow" runat="server" Width="30px">3</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRow" Text="*"
                            ErrorMessage="Row is required" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ControlToValidate="txtRow" Text="*"
                            ValidationExpression="^\d+$" ErrorMessage="Enter a valid number for row" Display="Dynamic"></asp:RegularExpressionValidator>
                        Column:<asp:TextBox ID="txtColumn" runat="server" Width="30px">2</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtColumn" Text="*"
                            ErrorMessage="Column is required" Display="Static"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtColumn" Text="*"
                            ValidationExpression="^\d+$" ErrorMessage="Enter a valid number for column" Display="Dynamic"></asp:RegularExpressionValidator>
                       Number of Rows:<asp:TextBox ID="txtNoOfRows" runat="server" Width="30px">3</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNoOfRows" Text="*"
                            ErrorMessage="Number of rows is required" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNoOfRows" Text="*"
                            ValidationExpression="^\d+$" ErrorMessage="Enter a valid number for no. of rows" Display="Dynamic"></asp:RegularExpressionValidator>
                        Number of Columns:<asp:TextBox ID="txtNoOfColumns" runat="server" Width="30px">2</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNoOfColumns" Text="*"
                            ErrorMessage="Number of columns is required" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtNoOfColumns" Text="*"
                            ValidationExpression="^\d+$" ErrorMessage="Enter a valid number for no. of columns" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnFreeze" runat="server" Text="Freeze Pane" OnClick="btnFreeze_Click">
                        </asp:Button>
                        <asp:Button ID="btnUnfreeze" runat="server" Text="Unfreeze Pane" OnClick="btnUnfreeze_Click"
                            CausesValidation="False"></asp:Button>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" Width="700px" MaxColumn="10" ShowLoading="false"
                            MaxRow="15" Height="600px" PresetStyle="Traditional1">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
