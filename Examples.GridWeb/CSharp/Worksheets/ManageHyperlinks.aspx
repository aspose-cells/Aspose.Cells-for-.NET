<%@ Page Title="Manage Hyperlinks - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="ManageHyperlinks.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.ManageHyperlinks" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                         
            Manage Hyperlinks - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Update Hyperlinks</b> to check how existing hyperlinks are updated 
            <br />or click on <b>Remove Hyperlinks</b> to remove existing hyperlinks.
        </p>        
        <p>                        
            <asp:Button ID="btnUpdateHyperlinks" runat="server" Text="Update Hyperlinks" OnClick="btnUpdateHyperlinks_Click"></asp:Button>                        
            <asp:Button ID="btnRemoveHyperlinks" runat="server" Text="Remove Hyperlinks" OnClick="btnRemoveHyperlinks_Click"></asp:Button>
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">
        <acw:GridWeb ID="GridWeb1" runat="server" Width="600px" Height="400px" ShowLoading="false"
            PresetStyle="Colorful2" MaxRow="13" MaxColumn="8">
        </acw:GridWeb>
    </div>
</asp:Content>

