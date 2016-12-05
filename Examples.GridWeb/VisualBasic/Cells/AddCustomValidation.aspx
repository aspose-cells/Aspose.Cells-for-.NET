<%@ Page Title="Add Custom Validation - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="AddCustomValidation.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.Cells.AddCustomValidation" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
      <script>        
        // A client side JavaScript function that will be executed whenever a validation error will occur
        function ValidationErrorFunction() {
            // Showing an alert message where "this" refers to GridWeb
            alert(this.id + ": Please correct your input error.");
        }
      </script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                          
            Add Custom Validation - Aspose.Cells Grid Suite Examples                    
        </h2>            
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>Add Custom Validation</b> to add custom validation to GridWeb cells.
        </p>
        <p>                         
            <asp:Label ID="Label1" runat="server" ></asp:Label> <br />                        
            <asp:Button ID="btnAddCustomValidation" runat="server" Text="Add Custom Validaiton" OnClick="btnAddCustomValidation_Click" />
        </p>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server" ForceValidation="true">                        
        </acw:GridWeb>              
    </div>
</asp:Content>
