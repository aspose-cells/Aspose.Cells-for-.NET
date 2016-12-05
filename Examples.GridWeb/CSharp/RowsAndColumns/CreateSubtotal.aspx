<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns.CreateSubtotal"
    MasterPageFile="~/Site.Master" Title="Create/Remove Subtotal - Aspose.Cells Grid Suite Examples"
    CodeBehind="CreateSubtotal.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Create/Remove Subtotal - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Load Data</b> to populate grid with data. Data is fetched into a <b>Dataset</b>
            using <b>OleDbAdapter</b> and binded with empty <b>WebWorksheet</b>. Choose a field
            in <b>Group By</b> dropdown, choose <b>Subtotal Function</b> and click <b>Create Subtotal</b>
            to see how demo creates sub-totals based on user entry. The result from GridWeb
            can be opened/saved using the <b>Save</b> button from GridWeb Control Box.
        </p>
        <table>
            <tr>
                <td>
                    Group By:<asp:DropDownList ID="ddlSort" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
                        <asp:ListItem Value="CategoryName" Selected="True">Sort By Category</asp:ListItem>
                        <asp:ListItem Value="CompanyName">Sort By Company</asp:ListItem>
                    </asp:DropDownList>
                    Subtotal Function:<asp:DropDownList ID="ddlFunction" runat="server">
                        <asp:ListItem Value="AVERAGE">AVERAGE</asp:ListItem>
                        <asp:ListItem Value="COUNT">COUNT</asp:ListItem>
                        <asp:ListItem Value="COUNTA" Selected="True">COUNTA</asp:ListItem>
                        <asp:ListItem Value="MAX">MAX</asp:ListItem>
                        <asp:ListItem Value="MIN">MIN</asp:ListItem>
                        <asp:ListItem Value="PRODUCT">PRODUCT</asp:ListItem>
                        <asp:ListItem Value="SUM">SUM</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCreate" runat="server" Text="Create Subtotal" OnClick="btnCreate_Click">
                    </asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                    <acw:GridWeb ID="GridWeb1" runat="server" Width="712px" OnSaveCommand="GridWeb1_SaveCommand"
                        PresetStyle="Professional2" ShowLoading="false">
                    </acw:GridWeb>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
