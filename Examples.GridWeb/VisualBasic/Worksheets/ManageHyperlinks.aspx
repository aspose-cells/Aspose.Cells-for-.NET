<%@ Page Title="Manage Hyperlinks - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="ManageHyperlinks.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.Worksheets.ManageHyperlinks" %>

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
                       Manage Hyperlinks - Aspose.Cells Grid Suite Examples
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
            Click <b>Update Hyperlinks</b> to check how existing hyperlinks are updated 
            <br />or click on <b>Remove Hyperlinks</b> to remove existing hyperlinks.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnUpdateHyperlinks" runat="server" Text="Update Hyperlinks" OnClick="btnUpdateHyperlinks_Click"></asp:Button>
                        <asp:Button ID="btnRemoveHyperlinks" runat="server" Text="Remove Hyperlinks" OnClick="btnRemoveHyperlinks_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" Width="600px" Height="400px" ShowLoading="false"
                            PresetStyle="Colorful2" MaxRow="13" MaxColumn="8">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

