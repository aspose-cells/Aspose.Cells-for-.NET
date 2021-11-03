<%@ Page Title="Add/Remove Comments From Client Side - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRemoveCommentsFromClientSide.aspx.cs" 
    Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.AddRemoveCommentsFromClientSide" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">       
            Add/Remove Comments From Client Side - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div>
        <input type="button" value="Add Comment" onclick="addComment()"/><br/><br/>
        <input type="button" value="Remove Comment" onclick="removeComment()"/><br/><br/>

    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>
    </div>

    <script>
        function addComment() {
            gridwebinstance.getByIndex(0).addcomments({note:'hello',author:'aspose'});
        }
        function removeComment() {
            gridwebinstance.getByIndex(0).delcomments();
        }
    </script>
</asp:Content>


