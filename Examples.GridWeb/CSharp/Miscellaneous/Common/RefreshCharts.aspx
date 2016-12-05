<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common.RefreshCharts" MasterPageFile="~/Site.Master"
    Title="Refresh Charts - Aspose.Cells Grid Suite Demos" CodeBehind="RefreshCharts.aspx.cs" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" src="../acw_client/jquery-1.7.2.min.js"></script>
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                       
            Refresh Charts - Aspose.Cells Grid Suite Examples                    
        </h2>        
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            This example loads an existing file into an empty WebWorksheet to demonstrate how GridWeb
            display various of charts.Try edit the cell value,and click the submit button,then the chart image will refresh.        
        </p>
       
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWebchart" runat="server" Height="538px" Width="1200px"                              
            AutoRefreshChart="false" OnSubmitCommand="submitaction">                        
        </acw:GridWeb>
    </div>
</asp:Content>
