<%@ Page Title="Make Rows/Columns ReadOnly - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="MakeRowsColumnsReadOnly.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns.MakeRowsColumnsReadOnly" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                  
            Make Rows/Columns ReadOnly - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Make Cell ReadOnly</b> to see how cell A1 can be made ready only.
        </p>
        <p>
            <asp:Button ID="btnMakeCellReadOnly" runat="server" Text="Make Cell ReadOnly" Width="150" OnClick="btnMakeCellReadOnly_Click"></asp:Button>&nbsp;
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">            
        <acw:GridWeb ID="GridWeb1" runat="server" Width="795px" ForceValidation="False" Height="600px"                
            MaxColumn="5" ShowLoading="false" XhtmlMode="True">            
        </acw:GridWeb>        
    </div>
</asp:Content>

