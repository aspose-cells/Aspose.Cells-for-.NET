<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common.CreateInvoice" MasterPageFile="~/Site.Master"
    Title="Create Invoice - Aspose.Cells Grid Suite Examples" CodeBehind="CreateInvoice.aspx.cs" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>
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
                        Create Invoice - Aspose.Cells Grid Suite Examples
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
            Click <b>Create</b> to see how an invoice document is created from scratch and displayed
            in the GridWeb Control.
        </p>
        <br />
        <div class="demoContentArea">
            <table class="i1" id="Table1">
                <tr>
                    <td nowrap class="demo">
                        Create Contents from Scratch:
                    </td>
                    <td width="100%" class="demo">
                        <asp:Button ID="Button1" runat="server" Text="Create" OnClick="Button1_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="demo">
                        <acw:GridWeb ID="GridWeb1" runat="server" Height="238px" Width="600px"
                            ShowLoading="false" OnSaveCommand="GridWeb1_SaveCommand">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
