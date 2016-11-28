<%@ Page Language="C#"  MasterPageFile="~/Site.Master" Title="Conditional Formatting - Aspose.Cells Grid Suite Examples" 
    CodeBehind="~/Miscellaneous/Common/ConditionalFormatting.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common.ConditionalFormatting"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="Aspose.Cells.GridWeb" %>
<%@ Import Namespace="Aspose.Cells.GridWeb.Data" %>
<%@ Register TagPrefix="agw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Conditional Formatting - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Load</b> to see how files loads with conditional formatting setting,try edit columen B with diffrent value,to see the result.<br />
            Load an Excel file:
            <asp:Button ID="Button2" runat="server" Text="Load" OnClick="Button1_Click"></asp:Button>
        </p>
        <br />
        <div style="width: 100%; height: 100%; ">          
            <agw:gridweb ID="gwcf" runat="server"  EnableAsync="true" Height="402px" Width="800px"/>       
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeaderContent">
    <style type="text/css">
        .style1
        {
            width: 722px;
        }
    </style>
</asp:Content>

 
