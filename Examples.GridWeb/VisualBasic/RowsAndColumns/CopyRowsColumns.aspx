<%@ Page Title="Copy Rows/Columns - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="CopyRowsColumns.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.RowsAndColumns.CopyRowsColumns" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Copy Rows/Columns - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
         Click
            <ul>
                <li><b>Copy Row</b> to see how  a row can be copied in GridWeb</li>
                <li><b>Copy Multiple Rows</b> to see how multiple rows can be copied in GridWeb</li>
                <li><b>Copy Column</b> to see how a column can be copied in GridWeb</li>
                <li><b>Copy Multiple Columns</b> to see how multiple columns can be copied in GridWeb</li>
            </ul>
        </p>
        <br />
        <div style="text-align: left">            
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCopyRow" runat="server" Text="Copy Row" Width="100" OnClick="btnCopyRow_Click"></asp:Button>
                        <asp:Button ID="btnCopyMultipleRows" runat="server" Text="Copy Multiple Rows" Width="150" OnClick="btnCopyMultipleRows_Click"></asp:Button>
                        <asp:Button ID="btnCopyColumn" runat="server" Text="Copy Column" Width="100" OnClick="btnCopyColumn_Click"></asp:Button>
                        <asp:Button ID="btnCopyMultipleColumns" runat="server" Text="Copy Multiple Columns" Width="150" OnClick="btnCopyMultipleColumns_Click"></asp:Button>
                    </td>
                </tr>
            </table>
            <br />            
            <table>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" Width="795px" ForceValidation="False" Height="600px"
                            MaxColumn="5" PresetStyle="Professional1"
                            ShowLoading="false" XhtmlMode="True">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

