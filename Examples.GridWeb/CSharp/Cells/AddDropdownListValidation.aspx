<%@ Page Title="Add Dropdown List Validation - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master"
     AutoEventWireup="true" CodeBehind="AddDropdownListValidation.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Cells.AddDropdownListValidation" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                           
            Add Dropdown List Validation - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>Add Dropdown List Validation</b> to add dropdown list based validation to GridWeb cells.
        </p>
        <p>                                    
            <asp:Label ID="Label1" runat="server" ></asp:Label> <br />                        
            <asp:Button ID="btnAddDropDownListValidation" runat="server" Text="Add DropDown List Validaiton" OnClick="btnAddDropDownListValidation_Click" />
        </p>

    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">
        <acw:GridWeb ID="GridWeb1" runat="server" ForceValidation="true">                 
        </acw:GridWeb>
    </div>
</asp:Content>
