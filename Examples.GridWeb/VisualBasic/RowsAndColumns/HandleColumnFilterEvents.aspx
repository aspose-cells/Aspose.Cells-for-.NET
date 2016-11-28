<%@ Page Title="Handle Column Filter Events - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
     CodeBehind="HandleColumnFilterEvents.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.RowsAndColumns.HandleColumnFilterEvents" %>

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
                        Handle Column Filter Events - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Apply filter to desired column to view information about the applied filter.           
        </p>
        <br />
        <div style="text-align: left">        
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <!-- ExStart:HandleColumnFilterEvents -->
                        <acw:GridWeb ID="GridWeb1" runat="server" 
                            OnBeforeColumnFilter="GridWeb1_BeforeColumnFilter"
                             OnAfterColumnFilter="GridWeb1_AfterColumnFilter">
                        </acw:GridWeb>
                        <!-- ExEnd:HandleColumnFilterEvents -->
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
