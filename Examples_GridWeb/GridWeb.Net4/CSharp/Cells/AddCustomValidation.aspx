<%@ Page Title="Add Custom Validation - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="AddCustomValidation.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Cells.AddCustomValidation" %>

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

    <h2>Add Custom Validation - Aspose.Cells Grid Suite Examples                    
    </h2>
    <p>
        Click <b>Add Custom Validation</b> to add custom validation to GridWeb cells.
    </p>
    <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnAddCustomValidation" runat="server" Text="Add Custom Validaiton" OnClick="btnAddCustomValidation_Click" />
    </p>
    <acw:GridWeb ID="GridWeb1" runat="server" ForceValidation="true" Width="700px">
    </acw:GridWeb>
</asp:Content>
