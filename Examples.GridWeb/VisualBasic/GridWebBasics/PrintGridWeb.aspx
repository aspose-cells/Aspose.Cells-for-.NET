<%@ Page Title="Print GridWeb - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="PrintGridWeb.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.GridWebBasics.PrintGridWeb" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <!-- ExStart:PrintGridWebJS -->
    <script>
        function Print(grid) {
            // Get Id of GridWeb
            var grid = document.getElementById('<%= GridWeb1.ClientID %>');
            // Call print
            grid.print();
        }
    </script>
    <!-- ExEnd:PrintGridWebJS -->
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-family: Arial; font-size: small;">
        <tbody>
            <tr>
                <td style="width: 19px; vertical-align: top;">
                    <img alt="" height="41" src="/Common/images/heading_lft.jpg" width="19" />
                </td>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Write Client Side Script - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
                <td style="width:19px; vertical-align: top;">
                    <img alt="" height="41" src="/Common/images/heading_rt.jpg" width="19" />
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-family: Arial; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Print</b> button to see how the contents of GridWeb can be printed.
        </p>
        <br />
        <div>
            <table>
                <tr>
                   <!-- ExStart:PrintGridWeb -->
                   <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="Print();return false;" />
                   <!-- ExEnd:PrintGridWeb -->
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server"
                           OnSaveCommand="GridWeb1_SaveCommand" ShowLoading="false">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
</asp:Content>