<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common.ShowHeaderBarAndCommandButton"
    MasterPageFile="~/Site.Master" Title="HeaderBar & CommandButton - Aspose.Cells Grid Suite Examples"
    CodeBehind="ShowHeaderBarAndCommandButton.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        HeaderBar & CommandButton - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click one of <b>Show XXXX</b> commands to see how header bar / command
            button visibility can be customized in the GridWeb Control.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Checked="True" Text="Show Header Bar"
                            OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Checked="True" Text="Show Submit Button"
                            OnCheckedChanged="Checkbox2_CheckedChanged"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" Checked="True" Text="Show Save Button"
                            OnCheckedChanged="Checkbox3_CheckedChanged"></asp:CheckBox>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox4" runat="server" AutoPostBack="True" Checked="True" Text="Show Undo Button"
                            OnCheckedChanged="Checkbox4_CheckedChanged"></asp:CheckBox>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkNoScrollBar" runat="server" Text="No Scroll Bars" AutoPostBack="True"
                            OnCheckedChanged="chkNoScrollBar_CheckedChanged"></asp:CheckBox>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox5" runat="server" Text="No Tab Navigator" AutoPostBack="True"
                            OnCheckedChanged="chkNoTabBar_CheckedChanged"></asp:CheckBox>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" Height="250px" Width="644px" PresetStyle="Colorful2"
                            ShowLoading="false" EnablePaging="True" PageSize="20" OnSaveCommand="GridWeb1_SaveCommand">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
