<%@ Page Title="Merge Cells - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
     CodeBehind="MergeCells.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Cells.MergeCells" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                        
            Merge Cells - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>Merge Cells</b> to merge/unmerge cells for GridWeb control.
        </p>        
        <p>
            <asp:Label ID="Label1" runat="server" ></asp:Label> <br />                        
            <asp:CheckBox ID="chkMergeCells" runat="server" Text="Merge Cells" AutoPostBack="true" OnCheckedChanged="chkMergeCells_CheckedChanged"  />                        
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>
    </div>
</asp:Content>
