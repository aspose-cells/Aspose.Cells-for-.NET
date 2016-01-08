<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Common_Events" MasterPageFile="~/tpl/Demo.Master"
    Title="Handling Events - Aspose.Cells Grid Suite Demos" CodeBehind="Events.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-family: Arial; font-size: small;">
        <tbody>
            <tr>
                <td style="width: 19; vertical-align: top;">
                    <img alt="" height="41" src="/Common/images/heading_lft.jpg" width="19" />
                </td>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Handling Events - Aspose.Cells Grid Suite Demos
                    </h2>
                </td>
                <td style="width: 19; vertical-align: top;">
                    <img alt="" height="41" src="/Common/images/heading_rt.jpg" width="19" />
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-family: Arial; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Create Caption</b> to see how demo demonstrates handling events (double
            click demo cells to see JavaScript alert) in the GridWeb Control.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Checked="false" Text="Enable all double click events"
                            OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" Width="635px" Height="250px" HeaderBarWidth="100pt"
                            EnableDoubleClickEvent="False" PresetStyle="Professional1" OnSaveCommand="GridWeb1_SaveCommand"
                            OnSheetTabClick="GridWeb1_SheetTabClick" OnSubmitCommand="GridWeb1_SubmitCommand"
                            OnUndoCommand="GridWeb1_UndoCommand" OnCellDoubleClick="GridWeb1_CellDoubleClick"
                            OnColumnDoubleClick="GridWeb1_ColumnDoubleClick" OnRowDoubleClick="GridWeb1_RowDoubleClick"
                            ShowLoading="false">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
