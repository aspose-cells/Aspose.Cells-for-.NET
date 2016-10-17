<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common.DisplayCharts" 
    MasterPageFile="~/Site.Master" Title="Display Chart - Aspose.Cells Grid Suite Examples" CodeBehind="DisplayCharts.aspx.cs" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<script type="text/javascript" src="../acw_client/jquery-1.7.2.min.js"></script>
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-family: Arial; font-size: small;">
        <tbody>
            <tr>
                <td style="width: 19; vertical-align: top;">
                    <img alt="" height="41" src="/Common/images/heading_lft.jpg" width="19" />
                </td>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                       Display Chart - Aspose.Cells Grid Suite Examples
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
            This example loads an existing file into an empty WebWorksheet to demonstrate how GridWeb
            display various of charts.Try edit the cell value,then the related charts image will refresh automatically.
            User can also call method to refresh all the chart image during some event.
            <b>Check</b> <a href="RefreshCharts.aspx" target=_blank><b>here </b></a> for another example. 
            
        </p>
        <br />
        <div class="demoContentArea">
            <table class="i1" id="Table1">
               
                <tr>
                    <td colspan="2" class="demo">
                        <acw:GridWeb ID="GridWeb1" runat="server" Height="538px" Width="1200px" >
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
