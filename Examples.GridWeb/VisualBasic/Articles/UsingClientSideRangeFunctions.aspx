<%@ Page Title="Using client side range functions - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
     CodeBehind="UsingClientSideRangeFunctions.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.Articles.UsingClientSideRangeFunctions" %>

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
  <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                       Using client side range functions - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Set, Get & Clear Range Selections</b> to see  GridWeb client side range functions in action.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <button type="button" onclick="workWithRanges()">Set, Get & Clear Range Selections</button>
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>       
</asp:Content>
