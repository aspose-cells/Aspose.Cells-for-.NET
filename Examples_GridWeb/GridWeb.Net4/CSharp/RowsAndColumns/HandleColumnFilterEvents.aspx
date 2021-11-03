<%@ Page Title="Handle Column Filter Events - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="HandleColumnFilterEvents.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns.HandleColumnFilterEvents" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                               
            Handle Column Filter Events - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>        
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">        
        <p>
            Apply filter to desired column to view information about the applied filter.           
        </p>            
        <p>                                    
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">
        <!-- ExStart:HandleColumnFilterEvents -->
        <acw:GridWeb ID="GridWeb1" runat="server" 
            OnBeforeColumnFilter="GridWeb1_BeforeColumnFilter"
                OnAfterColumnFilter="GridWeb1_AfterColumnFilter">
        </acw:GridWeb>
        <!-- ExEnd:HandleColumnFilterEvents -->        
    </div>
</asp:Content>

