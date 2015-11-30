<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Common_CustomHeaders"
    MasterPageFile="~/tpl/Demo.Master" Title="Custom Headers - Aspose.Cells Grid Suite Demos"
    CodeBehind="CustomHeaders.aspx.cs" %>

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
                        Custom Headers - Aspose.Cells Grid Suite Demos
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
            Click <b>Create Caption</b> to see how demo customizes column labels and displays
            data in the GridWeb Control.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        Create Custom Header Captions:
                        <asp:Button ID="Button1" runat="server" Text="Create Caption" OnClick="Button1_Click">
                        </asp:Button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" Height="297px" Width="636px" PresetStyle="Traditional2"
                            ShowLoading="false">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
