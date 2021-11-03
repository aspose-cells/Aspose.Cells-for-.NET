<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.SortData" MasterPageFile="~/Site.Master"
    Title="Sort Data - Aspose.Cells Grid Suite Examples" CodeBehind="SortData.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                        
            Sort Data - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click column or row headers to sort data from top to bottom or left to right respectively. <br />
            Click <b>Reload</b> to see how to reload data from data source
            in the GridWeb Control.
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="ReLoad" OnClick="Button1_Click"></asp:Button>
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">
        <acw:GridWeb ID="GridWeb1" runat="server" MaxColumn="4" MaxRow="13" ShowLoading="false"
            PresetStyle="Colorful2" Height="350px" Width="624px" OnCellCommand="GridWeb1_CellCommand"
            OnSaveCommand="GridWeb1_SaveCommand">
        </acw:GridWeb>
    </div>
</asp:Content>
