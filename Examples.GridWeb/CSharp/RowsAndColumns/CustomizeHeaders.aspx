<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns.CustomizeHeaders"
    MasterPageFile="~/Site.Master" Title="Customize Headers - Aspose.Cells Grid Suite Examples"
    CodeBehind="CustomizeHeaders.aspx.cs" %>

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
                        Customize Headers - Aspose.Cells Grid Suite Examples
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
            Click <b>Create Caption</b> to see how column and row labels can be customized
            in the GridWeb Control.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        Create Custom Header Captions:
                        <asp:Button ID="btnCreateCaption" runat="server" Text="Create Caption" OnClick="btnCreateCaption_Click">
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
