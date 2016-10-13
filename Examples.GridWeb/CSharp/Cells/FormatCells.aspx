<%@ Page Title="Format Cells - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="FormatCells.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Cells.FormatCells" %>

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
                       Format Cells - Aspose.Cells Grid Suite Examples
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
          Click,
            <ul>
                <li>
                    <b>Apply Font Styles</b> to apply font styles to GridWeb cells.                    
                </li>
                <li>
                    <b>Apply Border Styles</b> to apply border styles to GridWeb cells.
                </li>
                <li>
                    <b>Apply Border Styles to Ranges</b> to apply border styles to a range of GridWeb cells.
                </li>
                <li>
                    <b>Apply Number Formats</b> to apply number formats to GridWeb cells.
                </li>
            </ul>             
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" ></asp:Label> <br />
                        <asp:Button ID="btnApplyFontStyles" runat="server" Text="Apply Font Styles" OnClick="btnApplyFontStyles_Click" />
                        <asp:Button ID="btnApplyBorderStyles" runat="server" Text="Apply Border Styles" OnClick="btnApplyBorderStyles_Click" />
                        <asp:Button ID="btnApplyRangeBorderStyles" runat="server" Text="Apply Border Styles to Range" OnClick="btnApplyRangeBorderStyles_Click" />
                        <asp:Button ID="btnApplyNumberFormats" runat="server" Text="Apply Number Formats" OnClick="btnApplyNumberFormats_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
</asp:Content>
 
