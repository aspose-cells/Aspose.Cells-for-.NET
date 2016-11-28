<%@ Page Title="Import/Export Excel File from Stream - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
     CodeBehind="ImportExportFileFromStream.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.GridWebBasics.ImportExportFileFromStream" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="HeaderContent">
    <style type="text/css">
        .style1
        {
            width: 722px;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
 
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.js"></script> 
 
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Import/Export Excel File from Stream - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Load</b> to see how excel file data loads from stream and click <b>Save</b>
            button to see how data may be saved to an Excel file using stream.
        </p>
        <br />
         <div style="width: 100%; height: 100%; ">
            
                        Load an Excel file from stream:&nbsp;&nbsp;
             
                        <asp:Button ID="btnLoadExcelFile" runat="server" Text="Load" OnClick="btnLoadExcelFile_Click"></asp:Button>&nbsp;
             <br />
             Save to excel file using stream:&nbsp;&nbsp;
             
                        <asp:Button ID="btnSaveUsingStream" runat="server" Text="Save" OnClick="btnSaveUsingStream_Click"></asp:Button>&nbsp;
                          <acw:GridWeb ID="GridWeb1" runat="server" Width="600pt" OnSaveCommand="GridWeb1_SaveCommand"                      
                            ShowLoading="False" PresetStyle="Professional1" EnableAJAX="True" 
                              XhtmlMode="True" ShowCellEditBox="True" BorderWidth="0px" Height="380pt">
                            </acw:GridWeb> 
                                                                
                   
        </div>
    </div>
</asp:Content>
