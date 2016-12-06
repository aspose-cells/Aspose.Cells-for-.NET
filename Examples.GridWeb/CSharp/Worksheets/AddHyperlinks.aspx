<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.AddHyperlinks"
    MasterPageFile="~/Site.Master" Title="Add Hyperlinks - Aspose.Cells Grid Suite Examples"
    CodeBehind="AddHyperlinks.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                       
            Add Hyperlinks - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click the hyperlinks to check their behaviour.
        </p>
        <p>                      
            <asp:Button ID="Button1" runat="server" Text="ReLoad" OnClick="Button1_Click"></asp:Button>
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">
        <acw:GridWeb ID="GridWeb1" runat="server" Width="600px" Height="400px" ShowLoading="false"
            PresetStyle="Colorful2" MaxRow="13" MaxColumn="8" OnSaveCommand="GridWeb1_SaveCommand"
            OnCellCommand="GridWeb1_CellCommand">
        </acw:GridWeb>
    </div>
</asp:Content>
