<%@ Page Title="Delete Rows/Columns - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
     CodeBehind="DeleteRowsColumns.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns.DeleteRowsColumns" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                        
            Delete Rows/Columns - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">        
        <p>
            Click <b>Reload</b> to reload data from data source. Click
            <ul>
                <li><b>Delete Column</b> to see how column is deleted in GridWeb</li>
                <li><b>Delete Row</b> to see how row is deleted in GridWeb</li>
            </ul>
        </p>    
        <p>                                  
            Reload Data:<asp:Button ID="btnReload" runat="server" Text="Reload" OnClick="btnReload_Click">                        
            </asp:Button>
        </p>
        <p>
            Delete Column: <br />
            Column Index:<asp:TextBox ID="txtColumnIndex" runat="server" Width="20px">2</asp:TextBox>                        
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtColumnIndex"  Text="*"                            
                ErrorMessage="Column index is required" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>                        
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtColumnIndex"  Text="*"                            
                ErrorMessage="Enter a valid number for column index" Display="Dynamic" ValidationExpression="^\d+$" ValidationGroup="Group1"></asp:RegularExpressionValidator>                                    
            <asp:Button ID="btnDeleteColumn" runat="server" Text="Delete Column" Width="100" OnClick="btnDeleteColumn_Click"                            
                ValidationGroup="Group1"></asp:Button>
        </p>
        <p>
            Delete Row: <br />                                    
            Row Index:<asp:TextBox ID="txtRowIndex" runat="server" Width="20px">2</asp:TextBox>                        
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRowIndex"  Text="*"                            
                ErrorMessage="Row index is required" Display="Dynamic" ValidationGroup="Group2"></asp:RequiredFieldValidator>                        
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRowIndex"  Text="*"                            
                ErrorMessage="Enter a valid number for row index" Display="Dynamic" ValidationExpression="^\d+$" ValidationGroup="Group2"></asp:RegularExpressionValidator>                        
            <asp:Button ID="btnDeleteRow" runat="server" Text="Delete Row" Width="100" OnClick="btnDeleteRow_Click"                            
                ValidationGroup="Group2"></asp:Button>&nbsp;
        </p>
        <p>
            <b>Note: </b> Indexes are zero-based.
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">   
        <acw:GridWeb ID="GridWeb1" runat="server" ForceValidation="False"                          
            MaxColumn="5" PresetStyle="Professional1"                            
            ShowLoading="false" XhtmlMode="True">                        
        </acw:GridWeb>
    </div>
</asp:Content>
