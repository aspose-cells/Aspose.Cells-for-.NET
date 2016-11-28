<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Format.ApplyDateTimeFormats"
    MasterPageFile="~/Site.Master" Title="Date & Time Format - Format - Aspose.Cells Grid Suite Examples"
    CodeBehind="ApplyDateTimeFormats.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Date and Time Format - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Pick a date format from the list, enter a value (text) and click <b>Submit</b> to
            see how custom date formats are applied to a grid cell with your values.
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
                            <asp:ListItem Value="14">Date1</asp:ListItem>
                            <asp:ListItem Value="15">Date2</asp:ListItem>
                            <asp:ListItem Value="16">Date3</asp:ListItem>
                            <asp:ListItem Value="17">Date4</asp:ListItem>
                            <asp:ListItem Value="18">Time1</asp:ListItem>
                            <asp:ListItem Value="19">Time2</asp:ListItem>
                            <asp:ListItem Value="20">Time3</asp:ListItem>
                            <asp:ListItem Value="21">Time4</asp:ListItem>
                            <asp:ListItem Value="22">Time5</asp:ListItem>
                            <asp:ListItem Value="45">Time6</asp:ListItem>
                            <asp:ListItem Value="46">Time7</asp:ListItem>
                            <asp:ListItem Value="47">Time8</asp:ListItem>
                            <asp:ListItem Value="27">EasternDate1</asp:ListItem>
                            <asp:ListItem Value="28">EasternDate2</asp:ListItem>
                            <asp:ListItem Value="29">EasternDate3</asp:ListItem>
                            <asp:ListItem Value="30">EasternDate4</asp:ListItem>
                            <asp:ListItem Value="31">EasternDate5</asp:ListItem>
                            <asp:ListItem Value="36">EasternDate6</asp:ListItem>
                            <asp:ListItem Value="50">EasternDate7</asp:ListItem>
                            <asp:ListItem Value="51">EasternDate8</asp:ListItem>
                            <asp:ListItem Value="52">EasternDate9</asp:ListItem>
                            <asp:ListItem Value="53">EasternDate10</asp:ListItem>
                            <asp:ListItem Value="54">EasternDate11</asp:ListItem>
                            <asp:ListItem Value="57">EasternDate12</asp:ListItem>
                            <asp:ListItem Value="58">EasternDate13</asp:ListItem>
                            <asp:ListItem Value="32">EasternTime1</asp:ListItem>
                            <asp:ListItem Value="33">EasternTime2</asp:ListItem>
                            <asp:ListItem Value="34">EasternTime3</asp:ListItem>
                            <asp:ListItem Value="35">EasternTime4</asp:ListItem>
                            <asp:ListItem Value="55">EasternTime5</asp:ListItem>
                            <asp:ListItem Value="56">EasternTime6</asp:ListItem>
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
                        <acw:GridWeb ID="GridWeb1" runat="server" HeaderBarWidth="100pt" Height="310px" Width="649px"
                            PresetStyle="Colorful1" OnSaveCommand="GridWeb1_SaveCommand" ShowLoading="false">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
            <br>
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
