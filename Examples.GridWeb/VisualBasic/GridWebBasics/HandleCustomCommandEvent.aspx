<%@ Page Title="Handle Custom Command Event - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false"
     MasterPageFile="~/Site.Master" CodeBehind="HandleCustomCommandEvent.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.GridWebBasics.HandleCustomCommandEvent" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Handle Custom Command Event - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click custom command button (<img src="../Image/aspose.ico" style="vertical-align:middle" />) to execute command event.
        </p>
        <br />
        <div>
            <table>
               <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server"
                           OnSaveCommand="GridWeb1_SaveCommand" OnCustomCommand="GridWeb1_CustomCommand"
                           ShowLoading="false">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
</asp:Content>
