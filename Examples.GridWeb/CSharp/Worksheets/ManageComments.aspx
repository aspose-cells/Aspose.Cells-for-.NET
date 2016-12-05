<%@ Page Title="Manage Comments - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master"
     AutoEventWireup="true" CodeBehind="ManageComments.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.ManageComments" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                       Manage Comments - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Add Comments</b> to add new comments or click <b>Update Comments</b> to update existing comments
            <br />or click on <b>Remove Comments</b> to remove existing comments.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnAddComments" runat="server" Text="Add Comments" OnClick="btnAddComments_Click"></asp:Button>
                        <asp:Button ID="btnUpdateComments" runat="server" Text="Update Comments" OnClick="btnUpdateComments_Click"></asp:Button>
                        <asp:Button ID="btnRemoveComments" runat="server" Text="Remove Comments" OnClick="btnRemoveComments_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" Width="600px" Height="400px" ShowLoading="false"
                            PresetStyle="Colorful2" MaxRow="13" MaxColumn="8">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
