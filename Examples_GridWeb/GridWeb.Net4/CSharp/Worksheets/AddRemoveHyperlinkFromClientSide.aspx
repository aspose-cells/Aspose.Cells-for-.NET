<%@ Page Title="Add/Remove Hyperlinks From Client Side - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRemoveHyperlinkFromClientSide.aspx.cs" 
    Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.AddRemoveHyperlinkFromClientSide" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">       
            Add/Remove Hyperlinks From Client Side - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div>
        <input type="button" value="Add Hyperlink" onclick="addLink()"/><br/><br/>
        <input type="button" value="Remove Hyperlink" onclick="removeLink()"/><br/><br/>

    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>
    </div>

    <script>
        function addLink() {
            var linkinfo={};
            linkinfo.url="http://www.aspose.com",
            linkinfo.text="Link to Aspose Webbsite",
            gridwebinstance.getByIndex(0).rangeupdate(addCelllink,linkinfo);
        }
        function removeLink() {
            gridwebinstance.getByIndex(0).rangeupdate(delCelllink);
        }
    </script>
</asp:Content>


