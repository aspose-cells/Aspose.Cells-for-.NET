<%@ Page Title="Access Worksheets - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="AccessWorksheets.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.Worksheets.AccessWorksheets" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                          
            Access Worksheets - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>View Worksheets</b> to see how GridWeb's worksheets can be accessed using index or name.
        </p>
        <p>                        
            <asp:Label ID="Label1" runat="server" ></asp:Label> <br />                        
            <asp:Button ID="btnViewWorksheets" runat="server" Text="View Worksheets" OnClick="btnViewWorksheets_Click" />            
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>
    </div>
</asp:Content>
