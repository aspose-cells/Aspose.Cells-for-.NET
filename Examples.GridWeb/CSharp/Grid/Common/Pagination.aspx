<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Common_Pagination"
    MasterPageFile="~/tpl/Demo.Master" Title="Paginating Sheet - Aspose.Cells Grid Suite Demos"
    CodeBehind="Pagination.aspx.cs" %>

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
                        Paginating Sheet - Aspose.Cells Grid Suite Demos
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
            Click <b>Reload</b> to see how demo loads data from data source and divides it into
            several pages to improve performance or support logical data division for subsequent
            data preview in the GridWeb Control.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Reload" OnClick="Button1_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" PageSize="20" EnablePaging="True" Width="637px"
                            Height="400px" HeaderBarWidth="100pt" MaxColumn="6" MaxRow="6" PresetStyle="Colorful2"
                            ShowLoading="false" OnSaveCommand="GridWeb1_SaveCommand">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
