<%@ Page Title="Export DataTable - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
     CodeBehind="ExportDataTable.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.ExportDataTable" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                              
            Export DataTable - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>   
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>          
            Click <b>Export DataTable</b> to see how GridWeb's worksheets can be exported to DataTable.
        </p>
        <p>
            <asp:Button ID="btnExportDataTable" runat="server" Text="Export DataTable" OnClick="btnExportDataTable_Click" />
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                
        <p id="trResult" runat="server" visible="false">                    
            <b>Export to Specific DataTable </b>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <b>Export to New DataTable </b>
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>                   
        </p>
        <p>                        
            <acw:GridWeb ID="GridWeb1" runat="server" PresetStyle="Colorful2" MaxColumn="3">                        
            </acw:GridWeb>       
        </p>                         
    </div>
</asp:Content>
