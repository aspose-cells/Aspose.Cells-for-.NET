<%@ Page Title="Enable Async Mode - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="EnableAsyncMode.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Articles.EnableAsyncMode" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                      
            Enable Async Mode - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Enable Async Mode</b> to set processing of GridWeb in asynchronous mode.
        </p>
        <p>
            <asp:Button ID="btnEnableAsync" runat="server" Text="Enable Async Mode" OnClick="btnEnableAsync_Click" />
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>
    </div>       
</asp:Content>