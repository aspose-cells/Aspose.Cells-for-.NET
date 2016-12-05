<%@ Page Title="Modify Cells - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="ModifyCells.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Cells.ModifyCells" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                               
            Modify Cell Value - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>Modify Cell Value</b> to see how GridWeb's worksheet cells value can be updated.
        </p>
        <p>                            
            <asp:Label ID="Label1" runat="server" ></asp:Label> <br />                        
            <asp:Button ID="btnModifyCellValue" runat="server" Text="Modify Cell Value" OnClick="btnModifyCellValue_Click" />        
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>        
    </div>
</asp:Content>
 
