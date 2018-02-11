<%@ Page Title="Remove Worksheets - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="RemoveWorksheets.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.RemoveWorksheets" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                             
            Remove Worksheets - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>          
            Click <b>Remove Worksheets</b> to see how GridWeb's worksheets can be removed using index or name.
        </p>
        <p>                                
            <asp:Label ID="Label1" runat="server"></asp:Label>                        
            <asp:Button ID="btnRemoveWorksheets" runat="server" Text="Remove Worksheets" OnClick="btnRemoveWorksheets_Click" />    
        </p>
        <p>

        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server" PresetStyle="Colorful2">                        
        </acw:GridWeb>
    </div>
</asp:Content>
