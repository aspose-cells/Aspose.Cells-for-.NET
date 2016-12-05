<%@ Page Title="Apply Custom Preset Styles - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="ApplyCustomPresetStyle.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.GridWebBasics.ApplyCustomPresetStyle" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                        
            Apply Custom Preset Styles - Aspose.Cells Grid Suite Examples                    
        </h2>               
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click the buttons to load or save custom styles for  
            the GridWeb Control.
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </p>            
    </div>
    <div>                        
        <p>                             
            <asp:Button ID="btnApplyCustomStyle" runat="server" Text="Apply Custom Style" OnClick="btnApplyCustomStyle_Click" />                            
            <asp:Button ID="btnSaveCustomStyle" runat="server" Text="Save Custom Style" OnClick="btnSaveCustomStyle_Click" />                        
        </p>
    </div>
    <div style="text-align:center">                        
        <acw:GridWeb ID="GridWeb1" runat="server" Width="606px" HeaderBarWidth="100pt" MaxColumn="6"                            
            MaxRow="6" OnSaveCommand="GridWeb1_SaveCommand" ShowLoading="false">                        
        </acw:GridWeb>             
    </div>
</asp:Content>

