<%@ Page Title="Enable Async Mode - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="EnableAsyncMode.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Articles.EnableAsyncMode" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-family: Arial; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                       Enable Async Mode - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-family: Arial; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Enable Async Mode</b> to set processing of GridWeb in asynchronous mode.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>              
                        <asp:Button ID="btnEnableAsync" runat="server" Text="Enable Async Mode" OnClick="btnEnableAsync_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>       
</asp:Content>
