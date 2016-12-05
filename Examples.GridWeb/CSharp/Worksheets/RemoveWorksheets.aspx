<%@ Page Title="Remove Worksheets - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="RemoveWorksheets.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.RemoveWorksheets" %>

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
                       Remove Worksheets - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>Remove Worksheets</b> to see how GridWeb's worksheets can be removed using index or name.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <asp:Button ID="btnRemoveWorksheets" runat="server" Text="Remove Worksheets" OnClick="btnRemoveWorksheets_Click" />
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
