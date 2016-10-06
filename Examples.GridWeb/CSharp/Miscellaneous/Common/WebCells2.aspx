<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Common_WebCells2" MasterPageFile="~/Site.Master"
    Title="WebCells - Aspose.Cells Grid Suite Demos" CodeBehind="WebCells2.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
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
                        WebCells - Aspose.Cells Grid Suite Demos
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
                <li><b>Insert Column</b> to see how demo inserts a column</li>
                <li><b>Insert Row</b> to see how demo inserts a row</li>
                <li><b>Delete Row</b> to see how demo deletes a row</li>
                <li><b>Delete Column</b> to see how demo deletes a column</li>
            </ul>
        </p>
        <br />
        <div style="text-align: left">
            <table>
                <tr>
                    <td>
                        Reload Data:<asp:Button ID="Button6" runat="server" Text="Reload" OnClick="Button6_Click">
                        </asp:Button>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        Insert/Delete Column:
                    </td>
                    <td>
                        ColumnIndex:<asp:TextBox ID="TextBox1" runat="server" Width="20px">2</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="*" Display="Static" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="*" Display="static" ValidationExpression="^\d+$" ValidationGroup="Group1"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Insert Column" Width="100" OnClick="Button1_Click"
                            ValidationGroup="Group1"></asp:Button>
                        <asp:Button ID="Button2" runat="server" Text="Delete Column" Width="100" OnClick="Button2_Click"
                            ValidationGroup="Group1"></asp:Button>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        Insert/Delete Row:
                    </td>
                    <td>
                        RowIndex:<asp:TextBox ID="Textbox2" runat="server" Width="20px">2</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Textbox2"
                            ErrorMessage="*" Display="static" ValidationGroup="Group2"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Textbox2"
                            ErrorMessage="*" Display="static" ValidationExpression="^\d+$" ValidationGroup="Group2"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" Text="Insert Row" Width="100" OnClick="Button3_Click"
                            ValidationGroup="Group2"></asp:Button>&nbsp;
                        <asp:Button ID="Button4" runat="server" Text="Delete Row" Width="100" OnClick="Button4_Click"
                            ValidationGroup="Group2"></asp:Button>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        Merge Cells:
                    </td>
                    <td>
                        StartRow:<asp:TextBox ID="Textbox3" runat="server" Width="20px">0</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Textbox3"
                            ErrorMessage="*" Display="static" ValidationGroup="Group3"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Textbox3"
                            ErrorMessage="*" Display="static" ValidationExpression="^\d+$" ValidationGroup="Group3"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        StartColumn:<asp:TextBox ID="Textbox4" runat="server" Width="20px">0</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Textbox4"
                            ErrorMessage="*" Display="Static" ValidationGroup="Group3"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="Textbox4"
                            ErrorMessage="*" Display="static" ValidationExpression="^\d+$" ValidationGroup="Group3"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        RowNumber:<asp:TextBox ID="Textbox5" runat="server" Width="20px">3</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Textbox5"
                            ErrorMessage="*" Display="static" ValidationGroup="Group3"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="Textbox5"
                            ErrorMessage="*" Display="Static" ValidationExpression="^\d+$" ValidationGroup="Group3"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        ColumnNumber:<asp:TextBox ID="Textbox6" runat="server" Width="20px">2</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Textbox6"
                            ErrorMessage="*" Display="static" ValidationGroup="Group3"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="Textbox6"
                            ErrorMessage="*" Display="static" ValidationExpression="^\d+$" ValidationGroup="Group3"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Button ID="Button5" runat="server" Text="Merge Cells" Width="100" OnClick="Button5_Click"
                            ValidationGroup="Group3"></asp:Button>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        Add/Remove Comment:
                    </td>
                    <td>
                        RowIndex:<asp:TextBox ID="Textbox7" runat="server" Width="20px">1</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Textbox7"
                            ErrorMessage="*" Display="static" ValidationGroup="Group4"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="Textbox7"
                            ErrorMessage="*" Display="static" ValidationExpression="^\d+$" ValidationGroup="Group4"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        ColumnIndex:<asp:TextBox ID="Textbox8" runat="server" Width="20px">1</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Textbox8"
                            ErrorMessage="*" Display="static" ValidationGroup="Group4"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="Textbox8"
                            ErrorMessage="*" Display="static" ValidationExpression="^\d+$" ValidationGroup="Group4"></asp:RegularExpressionValidator>
                        <td>
                            <td colspan="2">
                                Comment:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Textbox9" runat="server" Width="140px">This is my comment.</asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="Button7" runat="server" Text="Add Comment" Width="90" OnClick="Button7_Click"
                                    ValidationGroup="Group4"></asp:Button>
                                <asp:Button ID="Button8" runat="server" Text="Remove Comment" Width="112" OnClick="Button8_Click"
                                    ValidationGroup="Group4"></asp:Button>
                            </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb2" runat="server" Width="795px" ForceValidation="False" Height="600px"
                            MaxColumn="5" OnSaveCommand="GridWeb2_SaveCommand" PresetStyle="Professional1"
                            ShowLoading="false" XhtmlMode="False">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
