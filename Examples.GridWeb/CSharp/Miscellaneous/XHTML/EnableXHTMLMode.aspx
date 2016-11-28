<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.XHTML.EnableXHTMLMode" MasterPageFile="~/Site.Master"
    Title="XHTML 1.0 Support - Aspose.Cells Grid Suite Examples" CodeBehind="EnableXHTMLMode.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        XHTML 1.0 Support - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            This example demonstrates Grid control in <b>Xhtml</b>-compliant mode. Depending on
            the <b>DOCTYPE</b> of your HTML document, you may need to use either <b>XhtmlMode="True"</b>
            or <b>XhtmlMode="False"</b>.
        </p>
        <br />
        <div>
            <acw:GridWeb ID="GridWeb1" runat="server" XhtmlMode="True" PresetStyle="Colorful1"
                ShowLoading="false">
            </acw:GridWeb>
        </div>
    </div>
</asp:Content>
