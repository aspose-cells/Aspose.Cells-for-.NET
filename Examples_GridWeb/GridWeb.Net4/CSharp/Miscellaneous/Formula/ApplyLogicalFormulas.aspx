<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Formula.ApplyLogicalFormulas" MasterPageFile="~/Site.Master"
    Title="Logical Formula - Aspose.Cells Grid Suite Examples" CodeBehind="ApplyLogicalFormulas.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                               
            Logical Formula - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            This example loads an existing file into an empty Worksheet to demonstrate how GridWeb
            applies typical <b>Logical</b> formulas to grid cells and calculates formula values.
            Click <b>Reload</b> to reload initial data for the grid. You can also Save/Open
            the output in <b>XLS</b> Format by clicking the Save Button on GridWeb Control Bar.
        </p>
        <p>
            Please download the
            <asp:LinkButton ID="lnkFile" runat="server" Text="Logical.xls" OnClick="lnkFile_Click"></asp:LinkButton>
            used in this example.</p>
        <p>                    
            Reload data:&nbsp;&nbsp                    
            <asp:Button ID="btnReload" runat="server" Text="Reload" OnClick="btnReload_Click">                    
            </asp:Button>
        </p>    
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                    
        <acw:GridWeb ID="GridWeb1" runat="server" HeaderBarWidth="100pt"                        
            PresetStyle="Professional2" OnSaveCommand="GridWeb1_SaveCommand" ShowLoading="false">                    
        </acw:GridWeb>
    </div>
</asp:Content>
