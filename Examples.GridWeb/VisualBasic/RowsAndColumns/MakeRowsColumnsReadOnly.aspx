<%@ Page Title="Make Rows/Columns ReadOnly - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
     CodeBehind="MakeRowsColumnsReadOnly.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.RowsAndColumns.MakeRowsColumnsReadOnly" %>

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
                        Make Rows/Columns ReadOnly - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Make Cell ReadOnly</b> to see how cell A1 can be made ready only.
        </p>
        <br />
        <div style="text-align: left">
            <table>
                <tr>                   
                    <td>
                        <asp:Button ID="btnMakeCellReadOnly" runat="server" Text="Make Cell ReadOnly" Width="150" OnClick="btnMakeCellReadOnly_Click"></asp:Button>&nbsp;
                    </td>
                </tr>         
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

