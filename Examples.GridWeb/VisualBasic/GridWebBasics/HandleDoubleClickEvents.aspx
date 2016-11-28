<%@ Page Title="Handling Double Click Events - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false"
     MasterPageFile="~/Site.Master" CodeBehind="HandleDoubleClickEvents.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.GridWebBasics.HandleDoubleClickEvents" %>

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
                        Handling Double Click Events - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
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
