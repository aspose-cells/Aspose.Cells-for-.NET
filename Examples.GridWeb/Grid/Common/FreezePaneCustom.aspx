<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Common_FreezePaneCustom"
    MasterPageFile="~/tpl/Demo.Master" Title="Freeze/Unfreeze Panes - Aspose.Cells Grid Suite Demos"
    CodeBehind="FreezePaneCustom.aspx.cs" %>

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
                        Freeze/Unfreeze Panes - Aspose.Cells Grid Suite Demos
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
            Click <b>Create Caption</b> to see how demo freezes/unfreezes panes and displays
            data in the GridWeb Control.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td nowrap>
                        Row:<asp:TextBox ID="TextBox1" runat="server" Width="30px">3</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="*" Display="Static"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ControlToValidate="TextBox1"
                            ValidationExpression="^\d+$" ErrorMessage="*" Display="static"></asp:RegularExpressionValidator>
                        Column:<asp:TextBox ID="TextBox2" runat="server" Width="30px">3</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                            ErrorMessage="*" Display="Static"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox2"
                            ValidationExpression="^\d+$" ErrorMessage="*" Display="static"></asp:RegularExpressionValidator>
                        Row Number:<asp:TextBox ID="TextBox3" runat="server" Width="30px">2</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                            ErrorMessage="*" Display="Static" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox3"
                            ValidationExpression="^\d+$" ErrorMessage="*" Display="static"></asp:RegularExpressionValidator>
                        Column Number:<asp:TextBox ID="TextBox4" runat="server" Width="30px">3</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4"
                            ErrorMessage="*" Display="Static" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox3"
                            ValidationExpression="^\d+$" ErrorMessage="*" Display="static"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Freeze Pane" OnClick="Button1_Click">
                        </asp:Button>
                        <asp:Button ID="Button2" runat="server" Text="Unfreeze Pane" OnClick="Button2_Click"
                            CausesValidation="False"></asp:Button>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" XWidth="682px" MaxColumn="10" ShowLoading="false"
                            MaxRow="15" Height="300px" PresetStyle="Traditional1" OnSaveCommand="GridWeb1_SaveCommand">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
