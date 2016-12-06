<%@ Page Title="Copy Worksheets - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="CopyWorksheets.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.Worksheets.CopyWorksheets" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                    
            Copy Worksheets - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>          
            Click <b>Copy Worksheet</b> to see how GridWeb's worksheets can be copied.
        </p>
        <p>            
            <asp:Button ID="btnCopyWorksheet" runat="server" Text="Copy Worksheet" OnClick="btnCopyWorksheet_Click" />
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDes-criptionTxt">                    
        <acw:GridWeb ID="GridWeb1" runat="server" PresetStyle="Colorful2">                    
        </acw:GridWeb>      
    </div>
</asp:Content>
