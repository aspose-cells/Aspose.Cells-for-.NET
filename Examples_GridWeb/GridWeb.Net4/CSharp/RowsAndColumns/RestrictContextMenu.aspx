<%@ Page Title="Restrict Context Menu - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="RestrictContextMenu.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns.RestrictContextMenu" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                       
            Restrict Context Menu - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Restrict Context Menu</b> to limit options available in GridWeb, verify by right-clicking on GridWeb.
        </p>
        <p>
            <asp:Button ID="btnRestrictContextMenu" runat="server" Text="Restrict Context Menu" Width="150" OnClick="btnRestrictContextMenu_Click"></asp:Button>&nbsp;
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">        
        <acw:GridWeb ID="GridWeb1" runat="server" ForceValidation="False"
            MaxColumn="5" PresetStyle="Professional1"
            ShowLoading="false" XhtmlMode="True">
        </acw:GridWeb>        
    </div>
</asp:Content>

