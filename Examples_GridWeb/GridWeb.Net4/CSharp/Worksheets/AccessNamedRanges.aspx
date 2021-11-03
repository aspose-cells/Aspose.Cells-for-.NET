<%@ Page Title="Access Named Ranges - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
     CodeBehind="AccessNamedRanges.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.AccessNamedRanges" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                              
            Access Named Ranges - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Add Named Ranges</b> to add a named range and see its usage.
        </p>
        <p>
            <asp:Button ID="btnAddNamedRange" runat="server" Text="Add Named Range" OnClick="btnAddNamedRange_Click"></asp:Button>
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">
        <acw:GridWeb ID="GridWeb1" runat="server" Width="600px" Height="400px" ShowLoading="false"
            PresetStyle="Colorful2" MaxRow="13" MaxColumn="8">
        </acw:GridWeb>
    </div>
</asp:Content>
