<%@ Page Title="Add Worksheets - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="AddWorksheets.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.AddWorksheets" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                       
            Add Worksheets - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>Add Worksheets</b> to see how GridWeb's worksheets can be added with or without specifying name.
        </p>
        <p>                        
            <asp:Label ID="Label1" runat="server"></asp:Label>                        
            <asp:Button ID="btnAddWorksheets" runat="server" Text="Add Worksheets" OnClick="btnAddWorksheets_Click" />
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server" PresetStyle="Colorful2">                        
        </acw:GridWeb>
    </div>
</asp:Content>
