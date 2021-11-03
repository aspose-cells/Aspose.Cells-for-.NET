<%@ Page Title="Update Font Settings From Client Side - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateFontFromClientSide.aspx.cs" 
    Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.UpdateFontFromClientSide" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">       
            Update Font Settings From Client Side - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div>
        <input type="button" value="Make Font Italic" onclick="makeFontItalic()"/><br/><br/>
        <input type="button" value="Make Font Bold" onclick="makeFontBold()"/><br/><br/>
        <input type="button" value="Change Font Size" onclick="changeFontSize()"/><br/><br/>
        <input type="button" value="Change Font Family" onclick="changeFontFamily()"/><br/><br/>
        <input type="button" value="Change Font Color" onclick="changeFontColor()"/><br/><br/>
        <input type="button" value="Change Font Background Color" onclick="changeFontBackgroundColor()"/><br/><br/><br/>

    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>
    </div>

    <script>
        function makeFontItalic(){
            gridwebinstance.getByIndex(0).rangeupdate(updateCellFontStyle, "i");
        }
        function makeFontBold(){
            gridwebinstance.getByIndex(0).rangeupdate(updateCellFontStyle, "b");
        }
        function changeFontSize(){
            gridwebinstance.getByIndex(0).rangeupdate(updateCellFontSize, "5pt");
        }
        function changeFontFamily(){
            gridwebinstance.getByIndex(0).rangeupdate(updateCellFontName, "Corbel Light");
        }
        function changeFontColor(){
            gridwebinstance.getByIndex(0).rangeupdate(updateCellFontColor, "green");
        }
        function changeFontBackgroundColor(){
            gridwebinstance.getByIndex(0).rangeupdate(updateCellBackGroundColor, "yellow");
        }
    </script>
</asp:Content>

