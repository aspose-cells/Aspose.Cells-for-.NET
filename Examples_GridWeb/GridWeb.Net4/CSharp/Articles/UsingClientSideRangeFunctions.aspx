<%@ Page Title="Using client side range functions - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="UsingClientSideRangeFunctions.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Articles.UsingClientSideRangeFunctions" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <script type="text/javascript">
        function workWithRanges()
        {
            // ExStart:UsingRangeFunctions
            // Access GridWeb control
            var gridinstance = document.getElementById('<%=GridWeb1.ClientID%>');

            // Set selected range
            var range = {}; range.startRow = 1; range.startCol = 1; range.endRow = 2; range.endCol = 2;
            gridinstance.setSelectRange(range);

            // Get selected range
            var selectrange = gridinstance.getSelectRange();
            alert("Start Row:" + selectrange.startRow);
            alert("Start Column:" + selectrange.startCol);
            alert("End Row:" + selectrange.endRow);
            alert("End Column:" + selectrange.endCol);

            // Clear selection
            gridinstance.clearSelections();
            // ExEnd:UsingRangeFunctions
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                  
            Using client side range functions - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Set, Get & Clear Range Selections</b> to see  GridWeb client side range functions in action.
        </p>
        <p>                    
            <button type="button" onclick="workWithRanges()">Set, Get & Clear Range Selections</button>
        </p>        
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>                    
    </div>       
</asp:Content>
