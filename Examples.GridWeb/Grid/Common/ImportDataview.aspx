<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Common_importdataview"
    MasterPageFile="~/tpl/Demo.Master" Title="Import DataView - Aspose.Cells Grid Suite Demos"
    CodeBehind="ImportDataview.aspx.cs" %>

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
                        Import DataView - Aspose.Cells Grid Suite Demos
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
            Click <b>Load</b> to see how Demo Imports data from a DataView Object (data stored
            in a database table is fetched to DataView Object) and displays data in the GridWeb
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
