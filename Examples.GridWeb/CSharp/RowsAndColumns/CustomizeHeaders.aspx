<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns.CustomizeHeaders"
    MasterPageFile="~/Site.Master" Title="Customize Headers - Aspose.Cells Grid Suite Examples"
    CodeBehind="CustomizeHeaders.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                         
            Customize Headers - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Create Caption</b> to see how column and row labels can be customized
            in the GridWeb Control.
        </p>
        <p>                                    
            Create Custom Header Captions:                        
            <asp:Button ID="btnCreateCaption" runat="server" Text="Create Caption" OnClick="btnCreateCaption_Click">                        
            </asp:Button>
        </p>        
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server" Height="297px" Width="636px" PresetStyle="Traditional2"                            
            ShowLoading="false">                        
        </acw:GridWeb>
    </div>
</asp:Content>
