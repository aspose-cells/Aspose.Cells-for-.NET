<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Formula.ApplyTextAndDataFormulas"
    MasterPageFile="~/Site.Master" Title="Text and Data Formula - Aspose.Cells Grid Suite Examples"
    CodeBehind="ApplyTextAndDataFormulas.aspx.cs" %>

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
                        Text and Data Formulas - Aspose.Cells Grid Suite Examples
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
            This example loads an existing file into an empty Worksheet to demonstrate how GridWeb
            applies typical <b>Text</b> and <b>Data</b> formulas to grid cells and calculates
            formula values. Click <b>Reload</b> to reload initial data for the grid. You can
            also Save/Open the output in <b>XLS</b> Format by clicking the Save Button on GridWeb
            Control Bar.
        </p>
        <p>
            Please download the
            <asp:LinkButton ID="lnkFile" runat="server" Text="TextAndData.xls" OnClick="lnkFile_Click"></asp:LinkButton>
            used in this example.</p>
        <table>
            <tr>
                <td>
                    Reload data:&nbsp;&nbsp;
                    <asp:Button ID="btnReload" runat="server" Text="Reload" OnClick="btnReload_Click">
                    </asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                    <acw:GridWeb ID="GridWeb1" runat="server" HeaderBarWidth="100pt"
                        PresetStyle="Colorful2" OnSaveCommand="GridWeb1_SaveCommand" ShowLoading="false">
                    </acw:GridWeb>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
