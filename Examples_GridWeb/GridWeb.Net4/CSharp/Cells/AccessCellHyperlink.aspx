<%@ Page Title="Access Cell Hyperlink - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="AccessCellHyperlink.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Cells.AccessCellHyperlink" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">        
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                   
            Access Cell Hyperlink - Aspose.Cells Grid Suite Examples                    
        </h2>        
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>Access Cell Hyperlink</b> to see how GridWeb's worksheet cell hyperlink can be accessed.
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" ></asp:Label> <br />                        
            <asp:Button ID="btnAccessCellHyperlink" runat="server" Text="Access Cell Hyperlink" OnClick="btnAccessCellHyperlink_Click" />
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>
    </div>
</asp:Content>
