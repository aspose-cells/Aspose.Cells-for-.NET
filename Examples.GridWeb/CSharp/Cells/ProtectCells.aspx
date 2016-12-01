<%@ Page Title="Protect Cells - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
     CodeBehind="ProtectCells.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Cells.ProtectCells" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                       
            Protect Cells - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">                
        <p>
          Click <b>Edit All Cells</b> to toggle edit/readonly mode for all cells or click <b>Edit Selected Cells</b> toggle edit/readonly mode for selected cells.
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" ></asp:Label> <br />
            <asp:CheckBox ID="chkAllCells" runat="server" Text="Edit All Cells" Checked="true" AutoPostBack="true" OnCheckedChanged="chkAllCells_CheckedChanged"  />
            <asp:CheckBox ID="chkSelectedCells" runat="server" Text="Edit Selected Cells" AutoPostBack="true" OnCheckedChanged="chkSelectedCells_CheckedChanged" />            
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>        
    </div>
</asp:Content>
 

