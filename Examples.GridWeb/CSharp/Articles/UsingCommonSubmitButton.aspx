<%@ Page Title="Using common submit button - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="UsingCommonSubmitButton.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Articles.UsingCommonSubmitButton" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                           
            Using common submit button - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Submit Grid Data to Server</b> to submit GridWeb data.
        </p>
        <p>                                    
            <asp:Button ID="SubmitButton" runat="server" Text="Submit Grid Data to Server" />
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>
    </div>       
</asp:Content>
