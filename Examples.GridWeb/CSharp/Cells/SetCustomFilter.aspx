<%@ Page Title="Set Custom Filter - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="SetCustomFilter.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Cells.SetCustomFilter" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                         
            Set Custom Filter - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>Apply Custom filter</b> to apply a custom filter.
        </p>
        <p>                            
            <asp:Button ID="btnApplyCustomFilter" runat="server" Text="Apply Custom Filter" OnClick="btnApplyCustomFilter_Click" />
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>        
    </div>
</asp:Content>

