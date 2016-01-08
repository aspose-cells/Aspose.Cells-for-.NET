<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Filter_CustomFilter"
    MasterPageFile="~/tpl/Demo.Master" Title="Using Forumula to Filter Rows - Aspose.Cells Grid Suite Demos"
    CodeBehind="CustomFilter.aspx.cs" %>

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
                        Using Forumula to Filter Rows - Aspose.Cells Grid Suite Demos
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
            Enter custom text value and click <b>Filter Rows</b> to see how demo applies custom
            filter to grid rows in runtime.
        </p>
        <br />
        <div>
            <asp:Label ID="Label1" runat="server">Input the filter value:</asp:Label>
            <asp:TextBox ID="TextBox1" runat="server">Aniseed Syrup</asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="FilterRows" OnClick="Button1_Click">
            </asp:Button>
            <asp:Button ID="Button2" runat="server" Text="ResetFilter" OnClick="Button2_Click">
            </asp:Button>
             <asp:Button ID="Button3" runat="server" Text="ClearFilter" OnClick="Button3_Click">
            </asp:Button>
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            <acw:GridWeb ID="GridWeb1" runat="server" PresetStyle="Colorful2" ShowLoading="false">
            </acw:GridWeb>
        </div>
    </div>
</asp:Content>
