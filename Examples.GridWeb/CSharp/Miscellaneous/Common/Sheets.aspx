<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Common_Sheets" MasterPageFile="~/tpl/Demo.Master"
    Title="Worksheets - Aspose.Cells Grid Suite Demos" CodeBehind="Sheets.aspx.cs" %>

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
                        Worksheets - Aspose.Cells Grid Suite Demos
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
            Click <b>Add</b> to see how demo adds a worksheet, <b>Add Copy</b> to add a copy
            of a worksheet and <b>Remove Active Sheet</b> to remove active worksheet. Click
            <b>Reload</b> to re-bind data from data source and display data in the GridWeb Control.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td align="left">
                        <b>Reload Data: </b>
                    </td>
                    <td align="left">
                        <asp:Button ID="Button1" runat="server" Text="Reload" OnClick="Button1_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <b>Add Sheet: </b>
                    </td>
                    <td align="left">
                        <asp:Button ID="Button2" runat="server" Text="Add" OnClick="Button2_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <b>Copy Sheet: </b>
                    </td>
                    <td align="left">
                        <asp:Button ID="Button3" runat="server" Text="Add Copy" OnClick="Button3_Click">
                        </asp:Button>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <b>Remove Sheet: </b>
                    </td>
                    <td align="left">
                        <asp:Button ID="Button4" runat="server" Text="Remove Active Sheet" OnClick="Button4_Click">
                        </asp:Button>
                    </td>
                </tr>
            </table>
            <acw:GridWeb ID="GridWeb1" runat="server" Width="624px" MaxColumn="5" Height="300px"
                ForceValidation="False" PresetStyle="Colorful2" ShowLoading="false" OnSaveCommand="GridWeb1_SaveCommand">
            </acw:GridWeb>
            <br />
            <br />
        </div>
    </div>
</asp:Content>
