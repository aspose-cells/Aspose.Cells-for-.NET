<%@ Page Title="Set Auto-Filter - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="SetAutoFilter.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Cells.SetAutoFilter" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                           
            Set Auto-Filter - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>        
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Auto-Filter has been enabled for the GridWeb. Try to filter the rows using headers.
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>              
    </div>
</asp:Content>
