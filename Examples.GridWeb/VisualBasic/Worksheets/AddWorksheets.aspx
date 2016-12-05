<%@ Page Title="Add Worksheets - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="AddWorksheets.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.Worksheets.AddWorksheets" %>

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
                       Add Worksheets - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>Add Worksheets</b> to see how GridWeb's worksheets can be added with or without specifying name.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <asp:Button ID="btnAddWorksheets" runat="server" Text="Add Worksheets" OnClick="btnAddWorksheets_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" PresetStyle="Colorful2">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
</asp:Content>
