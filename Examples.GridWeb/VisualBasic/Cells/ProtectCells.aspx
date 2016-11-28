<%@ Page Title="Protect Cells - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="ProtectCells.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.Cells.ProtectCells" %>

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
                       Protect Cells - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>Edit All Cells</b> to toggle edit/readonly mode for all cells or click <b>Edit Selected Cells</b> toggle edit/readonly mode for selected cells.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" ></asp:Label> <br />
                        <asp:CheckBox ID="chkAllCells" runat="server" Text="Edit All Cells" Checked="true" AutoPostBack="true" OnCheckedChanged="chkAllCells_CheckedChanged"  />
                        <asp:CheckBox ID="chkSelectedCells" runat="server" Text="Edit Selected Cells" AutoPostBack="true" OnCheckedChanged="chkSelectedCells_CheckedChanged" />
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
 
