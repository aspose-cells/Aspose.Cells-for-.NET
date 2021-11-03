<%@ Page Title="Add Formulas - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="AddFormulas.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Cells.AddFormulas" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                                                  
            Add Formulas - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>Add Formula</b> to load data, add a formula and calculate it <br />
            or click <b>Add Complex Formula</b> that adds a complex formula which references cells in other worksheets.
        </p>
        <p>                        
            <asp:Label ID="Label1" runat="server" ></asp:Label> <br />                        
            <asp:Button ID="btnAddFormula" runat="server" Text="Add Formula" OnClick="btnAddFormula_Click" />                        
            <asp:Button ID="btnAddComplexFormula" runat="server" Text="Add Complex Formula" OnClick="btnAddComplexFormula_Click" />
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>            
    </div>
</asp:Content>
 

