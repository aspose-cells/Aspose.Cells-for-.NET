<%@ Page Title="Read Cell Values on Client Side - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="ReadCellsClientSide.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Articles.ReadCellsClientSide" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <!-- ExStart:ReadGridWebCellsClientSide -->
    <script type="text/javascript">
        function ReadGridWebCells() {
            // Access GridWeb instance and cells array
            var gridwebins = gridwebinstance.get("<%=GridWeb1.ClientID%>");
            var cells = gridwebins.getCellsArray();

            // Log cell name, values, row & column indexes in console
            for (var j = 0; j < cells.length; j++)
            {
                var cellInfo = j + ":" + gridwebins.getCellName(cells[j]) + ",";
                cellInfo += "value is:" + gridwebins.getCellValueByCell(cells[j]) + " ,";
                cellInfo += "row:" + gridwebins.getCellRow(cells[j]) + ",";
                cellInfo += "col:" + gridwebins.getCellColumn(cells[j]);
                console.log(cellInfo);
            }
        }
    </script>
    <!-- ExEnd:ReadGridWebCellsClientSide -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                           
            Read Cell Values on Client Side - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Click me</b> to access cell values on client side. Verify the values from browser console.
        </p>
        <p>                                    
            <!-- ExStart:ReadGridWebCells -->                        
            <button type="button" onclick="ReadGridWebCells()">Click me</button>                        
            <!-- ExEnd:ReadGridWebCells -->
        </p>
        
    </div>
    <div style="text-align: center; font-size: small;margin-top:10px" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>
    </div>
</asp:Content>
