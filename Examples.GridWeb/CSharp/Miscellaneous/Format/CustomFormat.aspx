<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Format_CustomFormat"
    MasterPageFile="~/Site.Master" Title="CustomFormat - Aspose.Cells Grid Suite Demos"
    CodeBehind="CustomFormat.aspx.cs" %>

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
                        CustomFormat - Aspose.Cells Grid Suite Demos
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
            Input custom data format, your cell value (text) and click <b>Submit</b> to see
            how demo applies custom format to a grid cell and displays your value in it.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        Reload data:
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Reload" OnClick="Button1_Click"></asp:Button>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Custom Format:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Input Value:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><asp:Button ID="Button2"
                            runat="server" Text="Submit" OnClick="Button2_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <acw:GridWeb ID="GridWeb1" runat="server" HeaderBarWidth="100pt" ShowLoading="false"
                            Height="310px" Width="668px" PresetStyle="Colorful2" OnSaveCommand="GridWeb1_SaveCommand">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
            <br />
            <div>
                <p>
                    For the NumberType detail information please see: <a href="http://www.aspose.com/documentation/file-format-components/aspose.cells-for-.net/aspose.cells.gridweb.data.numbertype.html">
                        Formatting Cells</a>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
