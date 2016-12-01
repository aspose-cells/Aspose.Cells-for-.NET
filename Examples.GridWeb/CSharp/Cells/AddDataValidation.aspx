<%@ Page Title="Add Data Validation - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="AddDataValidation.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Cells.AddDataValidation" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                    
            Add Data Validation - Aspose.Cells Grid Suite Examples                    
        </h2>            
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>Add Data Validation</b> to add a data based validation in GridWeb cells.
        </p>
        <p>                                    
            <asp:Label ID="Label1" runat="server" ></asp:Label><br />                        
            <asp:Button ID="btnAddDataValidation" runat="server" Text="Add Data Validation" OnClick="btnAddDataValidation_Click" />
        </p>        
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                       
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>
    </div>
</asp:Content>
