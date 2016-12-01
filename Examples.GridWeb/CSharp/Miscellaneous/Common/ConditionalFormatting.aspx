<%@ Page Language="C#"  MasterPageFile="~/Site.Master" Title="Conditional Formatting - Aspose.Cells Grid Suite Examples" 
    CodeBehind="~/Miscellaneous/Common/ConditionalFormatting.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common.ConditionalFormatting"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="Aspose.Cells.GridWeb" %>
<%@ Import Namespace="Aspose.Cells.GridWeb.Data" %>
<%@ Register TagPrefix="agw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                               
            Conditional Formatting - Aspose.Cells Grid Suite Examples                    
        </h2>           
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Load</b> to see how files loads with conditional formatting setting,try edit columen B with diffrent value,to see the result.<br />
            Load an Excel file:
            <asp:Button ID="Button2" runat="server" Text="Load" OnClick="Button1_Click"></asp:Button>
        </p>    
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">            
        <agw:gridweb ID="gwcf" runat="server"  EnableAsync="true" Height="402px" Width="800px"/>       
    </div>
</asp:Content>

