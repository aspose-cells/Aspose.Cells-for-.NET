<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common.DisplayCharts" 
    MasterPageFile="~/Site.Master" Title="Display Chart - Aspose.Cells Grid Suite Examples" CodeBehind="DisplayCharts.aspx.cs" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<script type="text/javascript" src="../acw_client/jquery-1.7.2.min.js"></script>
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                                              
            Display Chart - Aspose.Cells Grid Suite Examples                    
        </h2>       
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            This example loads an existing file into an empty WebWorksheet to demonstrate how GridWeb
            display various of charts.Try edit the cell value,then the related charts image will refresh automatically.
            User can also call method to refresh all the chart image during some event.
            <b>Check</b> <a href="RefreshCharts.aspx" target="_blank"><b>here </b></a> for another example. 
            
        </p>    
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">       
        <acw:GridWeb ID="GridWeb1" runat="server" Height="538px" Width="1200px" >                        
        </acw:GridWeb>        
    </div>
</asp:Content>
