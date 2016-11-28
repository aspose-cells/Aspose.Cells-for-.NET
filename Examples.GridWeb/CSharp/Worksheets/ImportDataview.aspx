<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.ImportDataView"
    MasterPageFile="~/Site.Master" Title="Import DataView - Aspose.Cells Grid Suite Examples"
    CodeBehind="ImportDataView.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Import DataView - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Load</b> to see how data is imported from a DataView Object (data stored
            in a database table is fetched to DataView Object) and displayed in the GridWeb
            Control.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        Import from DataView:&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" Text="Load" OnClick="Button1_Click"></asp:Button>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" XhtmlMode="true" Height="300px" Width="657px"
                            ShowLoading="false" PresetStyle="Colorful1" MaxColumn="3" OnSaveCommand="GridWeb1_SaveCommand">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
