<%@ Page Title="Display Cell Edit Box - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="DisplayCellEditBox.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics.DisplayCellEditBox" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.js"></script> 
 
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                                          
            Display Cell Edit Box - Aspose.Cells Grid Suite Examples                    
        </h2>        
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">        
        <p>
            Click <b>Show Edit Box</b> to toggle cell edit box visibility.
        </p>    
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">            
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Show Edit Box" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" />        
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">
        <acw:GridWeb ID="GridWeb1" runat="server" OnSaveCommand="GridWeb1_SaveCommand"                      
            ShowLoading="False" PresetStyle="Professional1">                           
        </acw:GridWeb>               
    </div>
</asp:Content>

