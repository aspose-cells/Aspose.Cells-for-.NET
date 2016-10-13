<%@ Page Title="Restrict Context Menu - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="RestrictContextMenu.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.RowsAndColumns.RestrictContextMenu" %>

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
                        Restrict Context Menu - Aspose.Cells Grid Suite Examples
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
            Click <b>Restrict Context Menu</b> to limit options available in GridWeb, verify by right-clicking on GridWeb.
        </p>
        <br />
        <div style="text-align: left">
            <table>
                <tr>                   
                    <td>
                        <asp:Button ID="btnRestrictContextMenu" runat="server" Text="Restrict Context Menu" Width="150" OnClick="btnRestrictContextMenu_Click"></asp:Button>&nbsp;
                    </td>
                </tr>         
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" Width="795px" ForceValidation="False" Height="300px"
                            MaxColumn="5" PresetStyle="Professional1"
                            ShowLoading="false" XhtmlMode="True">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>