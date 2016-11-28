<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Format.ApplyNumberFormats" MasterPageFile="~/Site.Master"
    Title="Number Formats - Aspose.Cells Grid Suite Examples" CodeBehind="ApplyNumberFormats.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Number Formats - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Pick a number format from the list, enter some positive value (text) and click <b>Submit</b>
            to see how number formats are applied to a grid cell and your value is displayed
            in it.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        Reload data:
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Reload" OnClick="Button1_Click"></asp:Button>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        NumberType:
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="0">General</asp:ListItem>
                            <asp:ListItem Value="1">Decimal1</asp:ListItem>
                            <asp:ListItem Value="2">Decimal2</asp:ListItem>
                            <asp:ListItem Value="3">Decimal3</asp:ListItem>
                            <asp:ListItem Value="4">Decimal4</asp:ListItem>
                            <asp:ListItem Value="5">Currency1</asp:ListItem>
                            <asp:ListItem Value="6">Currency2</asp:ListItem>
                            <asp:ListItem Value="7">Currency3</asp:ListItem>
                            <asp:ListItem Value="8">Currency4</asp:ListItem>
                            <asp:ListItem Value="37">Currency5</asp:ListItem>
                            <asp:ListItem Value="38">Currency6</asp:ListItem>
                            <asp:ListItem Value="39">Currency7</asp:ListItem>
                            <asp:ListItem Value="40">Currency8</asp:ListItem>
                            <asp:ListItem Value="23">Currency9</asp:ListItem>
                            <asp:ListItem Value="24">Currency10</asp:ListItem>
                            <asp:ListItem Value="25">Currency11</asp:ListItem>
                            <asp:ListItem Value="26">Currency12</asp:ListItem>
                            <asp:ListItem Value="9">Percentage1</asp:ListItem>
                            <asp:ListItem Value="10">Percentage2</asp:ListItem>
                            <asp:ListItem Value="12">Fraction1</asp:ListItem>
                            <asp:ListItem Value="13">Fraction2</asp:ListItem>
                            <asp:ListItem Value="41">Accounting1</asp:ListItem>
                            <asp:ListItem Value="42">Accounting2</asp:ListItem>
                            <asp:ListItem Value="43">Accounting3</asp:ListItem>
                            <asp:ListItem Value="44">Accounting4</asp:ListItem>
                            <asp:ListItem Value="11">Scientific1</asp:ListItem>
                            <asp:ListItem Value="48">Scientific2</asp:ListItem>
                            <asp:ListItem Value="49">Text</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        Input Value:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button2"
                            runat="server" Text="Submit" OnClick="Button2_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <acw:GridWeb ID="GridWeb1" runat="server" HeaderBarWidth="100pt" Height="310px" Width="670px"
                            PresetStyle="Professional1" OnSaveCommand="GridWeb1_SaveCommand" ShowLoading="false">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
            <br />
            <div>
                <p>
                    For the NumberType detail information please see: 
                    <a href="http://www.aspose.com/docs/display/cellsnet/List+of+Supported+Number+Formats">
                    List of Supported Number Formats</a>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
