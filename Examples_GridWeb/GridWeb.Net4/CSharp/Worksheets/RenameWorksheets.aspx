<%@ Page Title="Rename Worksheets - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
     CodeBehind="RenameWorksheets.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.RenameWorksheets" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                     
            Rename Worksheets - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>Rename Worksheet</b> to see how GridWeb's worksheets can be renamed.
        </p>
        <p>                                    
            <asp:Button ID="btnRenameWorksheet" runat="server" Text="Rename Worksheet" OnClick="btnRenameWorksheet_Click" />
        </p>
        
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server" PresetStyle="Colorful2">                        
        </acw:GridWeb>
    </div>
</asp:Content>

