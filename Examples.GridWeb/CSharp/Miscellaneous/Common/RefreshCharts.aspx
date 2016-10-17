<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common.RefreshCharts" MasterPageFile="~/Site.Master"
    Title="Refresh Charts - Aspose.Cells Grid Suite Demos" CodeBehind="RefreshCharts.aspx.cs" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
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
                       Refresh Charts - Aspose.Cells Grid Suite Examples
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
            display various of charts.Try edit the cell value,and click the submit button,then the chart image will refresh.        
        </p>
        <br />
        <div class="demoContentArea">
            <table class="i1" id="Table1">           
                <tr>
                    <td colspan="2" class="demo">
                        <acw:GridWeb ID="GridWebchart" runat="server" Height="538px" Width="1200px"  
                            AutoRefreshChart="false" OnSubmitCommand="submitaction">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
