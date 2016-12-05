<%@ Page Title="Copy Rows/Columns - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
     CodeBehind="CopyRowsColumns.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns.CopyRowsColumns" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                             
            Copy Rows/Columns - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
         Click
            <ul>
                <li><b>Copy Row</b> to see how  a row can be copied in GridWeb</li>
                <li><b>Copy Multiple Rows</b> to see how multiple rows can be copied in GridWeb</li>
                <li><b>Copy Column</b> to see how a column can be copied in GridWeb</li>
                <li><b>Copy Multiple Columns</b> to see how multiple columns can be copied in GridWeb</li>
            </ul>
        </p>
        <p>                            
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <p>                         
            <asp:Button ID="btnCopyRow" runat="server" Text="Copy Row" Width="100" OnClick="btnCopyRow_Click"></asp:Button>                        
            <asp:Button ID="btnCopyMultipleRows" runat="server" Text="Copy Multiple Rows" Width="150" OnClick="btnCopyMultipleRows_Click"></asp:Button>                        
            <asp:Button ID="btnCopyColumn" runat="server" Text="Copy Column" Width="100" OnClick="btnCopyColumn_Click"></asp:Button>                        
            <asp:Button ID="btnCopyMultipleColumns" runat="server" Text="Copy Multiple Columns" Width="150" OnClick="btnCopyMultipleColumns_Click"></asp:Button>           
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server" ForceValidation="False"                           
            MaxColumn="5" ShowLoading="false" XhtmlMode="True">                        
        </acw:GridWeb>        
    </div>
</asp:Content>

