<%@ Page Title="Format Cells - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="FormatCells.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Cells.FormatCells" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                
            Format Cells - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click,
            <ul>
                <li>
                    <b>Apply Font Styles</b> to apply font styles to GridWeb cells.                    
                </li>
                <li>
                    <b>Apply Border Styles</b> to apply border styles to GridWeb cells.
                </li>
                <li>
                    <b>Apply Border Styles to Ranges</b> to apply border styles to a range of GridWeb cells.
                </li>
                <li>
                    <b>Apply Number Formats</b> to apply number formats to GridWeb cells.
                </li>
            </ul>             
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" ></asp:Label> <br />
            <asp:Button ID="btnApplyFontStyles" runat="server" Text="Apply Font Styles" OnClick="btnApplyFontStyles_Click" />
            <asp:Button ID="btnApplyBorderStyles" runat="server" Text="Apply Border Styles" OnClick="btnApplyBorderStyles_Click" />
            <asp:Button ID="btnApplyRangeBorderStyles" runat="server" Text="Apply Border Styles to Range" OnClick="btnApplyRangeBorderStyles_Click" />
            <asp:Button ID="btnApplyNumberFormats" runat="server" Text="Apply Number Formats" OnClick="btnApplyNumberFormats_Click" />            
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>        
    </div>
</asp:Content>
 
