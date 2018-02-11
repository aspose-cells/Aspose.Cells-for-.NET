<%@ Page Title="Import/Export Excel File from Stream - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
     CodeBehind="ImportExportFileFromStream.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics.ImportExportFileFromStream" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.js"></script> 
 
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                    
        <h2 class="demos-heading-bg">                        
            Import/Export Excel File from Stream - Aspose.Cells Grid Suite Examples                    
        </h2>                
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Load</b> to see how excel file data loads from stream and click <b>Save</b>
            button to see how data may be saved to an Excel file using stream.
        </p>
        <br />         
        <div>                        
            Load an Excel file from stream:&nbsp;&nbsp;                                     
            <asp:Button ID="btnLoadExcelFile" runat="server" Text="Load" OnClick="btnLoadExcelFile_Click"></asp:Button>&nbsp;
            <br />
            Save to excel file using stream:&nbsp;&nbsp;                                     
            <asp:Button ID="btnSaveUsingStream" runat="server" Text="Save" OnClick="btnSaveUsingStream_Click"></asp:Button>&nbsp;         
        </div>
        <div style="text-align: center; font-size: small;">                     
            <acw:GridWeb ID="GridWeb1" runat="server" OnSaveCommand="GridWeb1_SaveCommand" Height="100%" Width="60%"
                            ShowLoading="False" PresetStyle="Professional1" EnableAJAX="True" 
                              XhtmlMode="True" ShowCellEditBox="True" BorderWidth="0px">           
            </acw:GridWeb>                                                                                
        </div>
    </div>
</asp:Content>
