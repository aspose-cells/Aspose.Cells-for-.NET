<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.PivotTable.CreateCustomPivotTable"
    MasterPageFile="~/Site.Master" Title="Customizing Pivot Table - Aspose.Cells Grid Suite Examples"
    CodeBehind="CreateCustomPivotTable.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">
            Customizing Pivot Table - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>        
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            In this example, an existing worksheet is read into <b>WebWorksheet</b> using <b>ImportExcelFile</b>
            method of GridWeb. A Customized <b>Pivot Table</b> is created on imported data.
        </p>
        <p>
            You can choose fields, captions, positions, sorting order for Column <b>Employee</b>
            and click corresponding <b>Submit</b> buttons to see how Pivot Table is built
            programmatically based on your input. You can also Save/Open the output in <b>XLS</b> Format
            by clicking the Save Button on GridWeb Control Bar.
        </p>
        <p>
            Please download the
            <asp:LinkButton ID="lnkFile" runat="server" Text="PivotTable.xls" OnClick="lnkFile_Click"></asp:LinkButton>
            used in this example.</p>
        <p>                                
            <asp:Button ID="btnReload" runat="server" Width="130" Text="Reload Source Data" OnClick="btnReload_Click">                    
            </asp:Button>
        </p>
        <p>
            <span>Rename field caption:</span>
            <span>                                    
                Rename "Employee" to&nbsp;<asp:TextBox ID="txtEmployee" runat="server" Width="80">Saler</asp:TextBox>                    
                &nbsp;&nbsp;Rename "Product" to&nbsp;<asp:TextBox ID="txtCountry" runat="server"                        
                    Width="80">merchandise</asp:TextBox>                    
                &nbsp;&nbsp;<asp:Button ID="btnSubmit4" runat="server" Text="Submit" OnClick="btnSubmit4_Click">                    
                </asp:Button>
            </span>
        </p>    
        <p>
            <span>
                Set row or column field position:
            </span>
            <span>                    
                "Employee" position&nbsp;<asp:TextBox ID="TextBox3" runat="server" Width="20">1</asp:TextBox>                    
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox3"                        
                    ErrorMessage="*" Display="Static" ValidationGroup="Group1"></asp:RequiredFieldValidator>                    
                <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ControlToValidate="TextBox3"                        
                    ValidationExpression="^\d+$" ErrorMessage="*" Display="static" ValidationGroup="Group1"></asp:RegularExpressionValidator>                    
                &nbsp;&nbsp;"Country" position&nbsp;<asp:TextBox ID="TextBox4" runat="server" Width="20">1</asp:TextBox>                    
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4"                        
                    ErrorMessage="*" Display="static" ValidationGroup="Group1"></asp:RequiredFieldValidator>                    
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4"                        
                    ValidationExpression="^\d+$" ErrorMessage="*" Display="static" ValidationGroup="Group1"></asp:RegularExpressionValidator>                    
                &nbsp;&nbsp;<asp:Button ID="btnSubmit3" runat="server" Text="Submit" ValidationGroup="Group1"                        
                    OnClick="btnSubmit3_Click"></asp:Button>
            </span>
        </p>
        <p>
            <span>
                Set row or column order:
            </span>
            <span>                
                "Employee" order&nbsp;
                <asp:DropDownList ID="ddlEmployee" runat="server">                        
                    <asp:ListItem Value="Asc" Selected="True">Ascending</asp:ListItem>                        
                    <asp:ListItem Value="Desc">descending</asp:ListItem>                        
                    <asp:ListItem Value="Auto">Auto</asp:ListItem>                    
                </asp:DropDownList>                    
                &nbsp;&nbsp;"Country" order&nbsp;
                <asp:DropDownList ID="ddlCountry" runat="server">                        
                    <asp:ListItem Value="Asc" Selected="True">Ascending</asp:ListItem>                        
                    <asp:ListItem Value="Desc">descending</asp:ListItem>                        
                    <asp:ListItem Value="Auto">Auto</asp:ListItem>                    
                </asp:DropDownList>                    
                &nbsp;&nbsp;<asp:Button ID="btnSubmit2" runat="server" Text="Submit" OnClick="btnSubmit2_Click">                   
                </asp:Button>
            </span>
        </p>
        <p>
            <span>
                Hides some rows or columns:
            </span>
            <span>
                <asp:CheckBox ID="CheckBox1" runat="server" Text="David" Checked="True"></asp:CheckBox>
                <asp:CheckBox ID="CheckBox2" runat="server" Text="Maxilaku" Checked="True"></asp:CheckBox>
                <asp:CheckBox ID="CheckBox3" runat="server" Text="Europe" Checked="True"></asp:CheckBox>
                <asp:CheckBox ID="CheckBox4" runat="server" Text="China" Checked="True"></asp:CheckBox>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click">
                </asp:Button>
            </span>
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">          
        <acw:GridWeb ID="GridWeb1" runat="server" Width="720px" PresetStyle="Traditional1"
            ShowLoading="false" OnSaveCommand="GridWeb1_SaveCommand">
        </acw:GridWeb>
    </div>
</asp:Content>
