<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common.CreateInvoice" MasterPageFile="~/Site.Master"
    Title="Create Invoice - Aspose.Cells Grid Suite Examples" CodeBehind="CreateInvoice.aspx.cs" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                               
            Create Invoice - Aspose.Cells Grid Suite Examples                    
        </h2>                
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Create</b> to see how an invoice document is created from scratch and displayed
            in the GridWeb Control.
        </p>    
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">                        
        Create Contents from Scratch:    
        <asp:Button ID="Button1" runat="server" Text="Create" OnClick="Button1_Click"></asp:Button>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server" Height="238px" Width="600px"                            
            ShowLoading="false" OnSaveCommand="GridWeb1_SaveCommand">                        
        </acw:GridWeb>        
    </div>
</asp:Content>
