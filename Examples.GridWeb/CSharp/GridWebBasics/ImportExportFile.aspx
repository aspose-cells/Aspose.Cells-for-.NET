<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics.ImportExportFile"
    MasterPageFile="~/Site.Master" Title="Import/Export Excel File - Aspose.Cells Grid Suite Examples"
    CodeBehind="ImportExportFile.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent"> 
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.js"></script> 
 
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                    
        <h2 class="demos-heading-bg">                        
            Import/Export Excel File - Aspose.Cells Grid Suite Examples                    
        </h2>        
    </div>
    <div class="componentDescriptionTxt">
        <p>
            Click <b>Load</b> to see how data loads from excel file and click <b>Save</b>
            button to see how data may be sent to user in a form of Excel file.
        </p>
        <div>
             Load an Excel file:&nbsp;&nbsp;                                    
             <asp:Button ID="btnLoadExcelFile" runat="server" Text="Load" OnClick="btnLoadExcelFile_Click"></asp:Button>&nbsp;                                      
        </div>
        <div style="text-align:center">                 
             <acw:GridWeb ID="GridWeb1" runat="server" Height="100%" Width="60%" OnSaveCommand="GridWeb1_SaveCommand"                      
                  ShowLoading="False" PresetStyle="Professional1" EnableAJAX="True" 
                  XhtmlMode="True" ShowCellEditBox="True" BorderWidth="0px">                                                      
             </acw:GridWeb>                                                                
        </div>
    </div>
</asp:Content>

