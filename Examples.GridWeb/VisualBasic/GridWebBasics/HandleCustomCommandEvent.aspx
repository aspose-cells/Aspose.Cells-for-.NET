<%@ Page Title="Handle Custom Command Event - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false"
     MasterPageFile="~/Site.Master" CodeBehind="HandleCustomCommandEvent.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.GridWebBasics.HandleCustomCommandEvent" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                   
            Handle Custom Command Event - Aspose.Cells Grid Suite Examples                    
        </h2>                
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click custom command button (<img src="../Image/aspose.ico" style="vertical-align:middle" />) to execute command event.
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server"                           
            OnSaveCommand="GridWeb1_SaveCommand" OnCustomCommand="GridWeb1_CustomCommand"                           
            ShowLoading="false">                        
        </acw:GridWeb>
    </div>
</asp:Content>