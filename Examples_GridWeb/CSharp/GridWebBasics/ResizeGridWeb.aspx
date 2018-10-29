<%@ Page Title="Resize GridWeb - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
     CodeBehind="ResizeGridWeb.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics.ResizeGridWeb" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                                          
            Resize GridWeb - Aspose.Cells Grid Suite Examples                    
        </h2>        
    </div>      
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click the button to resize
            the GridWeb Control.

            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </p>
    </div>      
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">                       
        <p>                             
            <asp:Button ID="btnResizeGridWeb" runat="server" Text="Resize GridWeb" OnClick="btnResizeGridWeb_Click" />                        
        </p>          
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server"                           
            OnSaveCommand="GridWeb1_SaveCommand" ShowLoading="false">                        
        </acw:GridWeb>
    </div>
</asp:Content>


