<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_XHTML_Xhtml" MasterPageFile="~/Site.Master"
    Title="XHTML 1.0 Support - Aspose.Cells Grid Suite Demos" CodeBehind="Xhtml.aspx.cs" %>

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
                        XHTML 1.0 Support - Aspose.Cells Grid Suite Demos
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
            This demo demonstrates Grid control in <b>Xhtml</b>-compliant mode. Depending on
            the <b>DOCTYPE</b> of your HTML document, you may need to use either <b>XhtmlMode="True"</b>
            or <b></b>.
        </p>
        <br />
        <div>
            <acw:GridWeb ID="GridWeb1" runat="server" XhtmlMode="True" PresetStyle="Colorful1"
                ShowLoading="false">
            </acw:GridWeb>
        </div>
    </div>
</asp:Content>
