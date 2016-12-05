<%@ Page Title="Apply Header Bar Styles - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="ApplyHeaderBarStyle.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.GridWebBasics.ApplyHeaderBarStyle" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                          
            Apply Header Bar Styles - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div  style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click the button to apply header bar styles for  
            the GridWeb Control.
        </p>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">                           
        <asp:Button ID="btnApplyHeaderStyle" runat="server" Text="Apply Header Bar Style" OnClick="btnApplyHeaderStyle_Click" />
    </div>
    <div style="text-align:center">                        
        <acw:GridWeb ID="GridWeb1" runat="server" Width="606px" HeaderBarWidth="100pt" MaxColumn="6"                            
            MaxRow="6" OnSaveCommand="GridWeb1_SaveCommand" ShowLoading="false">                        
        </acw:GridWeb>             
    </div>
</asp:Content>

