<%@ Page Title="Export DataTable - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
     CodeBehind="ExportDataTable.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.ExportDataTable" %>

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
                       Export DataTable - Aspose.Cells Grid Suite Examples
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
          Click <b>Export DataTable</b> to see how GridWeb's worksheets can be exported to DataTable.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnExportDataTable" runat="server" Text="Export DataTable" OnClick="btnExportDataTable_Click" />
                    </td>
                </tr>
                <tr id="trResult" runat="server" visible="false">
                    <td>
                        <b>Export to Specific DataTable </b>
                        <asp:GridView ID="GridView1" runat="server">
                        </asp:GridView>
                        <br />
                        <b>Export to New DataTable </b>
                        <asp:GridView ID="GridView2" runat="server">
                        </asp:GridView>
                    </td>                   
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" PresetStyle="Colorful2" MaxColumn="3">
                        </acw:GridWeb>
                    </td>
                </tr>               
            </table>
            <br />
        </div>
    </div>
</asp:Content>
