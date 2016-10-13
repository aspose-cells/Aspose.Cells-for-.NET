<%@ Page Title="Init Context Menu Item Command - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
     CodeBehind="InitContextMenuItem.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.GridWebBasics.InitContextMenuItem" %>

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
                        Init Context Menu Item Command - Aspose.Cells Grid Suite Examples
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
            Right click on the GridWeb to see the custom command item added to context menu. <br />
            Try clicking custom command <b>ContextMenuItemText</b> to execute it.                    
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <!-- ExStart:InitContextMenuItem -->
                        <acw:GridWeb ID="GridWeb1" runat="server" XhtmlMode="True" EnableAJAX="true" OnCustomCommand="GridWeb1_CustomCommand" EnableClientColumnOperations="False" EnableClientFreeze="False" EnableClientMergeOperations="False" EnableClientRowOperations="False" EnableStyleDialogbox="False">
                             <CustomCommandButtons>
                                <acw:CustomCommandButton Command="MyContextMenuItemCommand" Text="ContextMenuItemText" CommandType="ContextMenuItem"></acw:CustomCommandButton>
                             </CustomCommandButtons>
                        </acw:GridWeb>
                        <!-- ExEnd:InitContextMenuItem -->
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
</asp:Content>
