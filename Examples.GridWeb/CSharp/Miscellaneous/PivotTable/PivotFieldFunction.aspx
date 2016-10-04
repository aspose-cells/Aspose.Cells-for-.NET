<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_PivotTable_PivotFieldFunction"
    MasterPageFile="~/tpl/Demo.Master" Title="Using PivotField Function - Aspose.Cells Grid Suite Demos"
    CodeBehind="PivotFieldFunction.aspx.cs" %>

<%@ Register TagPrefix="agw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div style="text-align: left; font-family: Arial; font-size: small;" class="componentDescriptionTxt">
        <p>
            In this demo, an existing worksheet is read into <b>WebWorksheet</b> using <b>ImportExcelFile</b>
            method of GridWeb. A <b>Pivot Table</b> is created on imported data. Then you can
            choose a function from drop-down (<b>Count</b>,<b>Sum</b>,<b>Average</b>,<b>Max</b>,<b>Min</b>)
            to see how demo uses <b>Pivot Field Function</b> while re-generating the Pivot Table
            , basing upon the Type of Field Function selected. You can also Save/Open the output
            in <b>XLS</b>Format by clicking the Save Button on GridWeb Control Bar.
        </p>
        <p>
            Please download the
            <asp:HyperLink ID="lnkFile" runat="server" NavigateUrl="~/file/PivotTable.xls">PivotTable.xls</asp:HyperLink>
            used in this demo.</p>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnReload" runat="server" Text="Reload Source Data" Width="130" OnClick="btnReload_Click">
                    </asp:Button>
                </td>
                <td>
                    Summary Functions:
                    <asp:DropDownList ID="ddlSummary" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSummary_SelectedIndexChanged">
                        <asp:ListItem Value="Count">Count</asp:ListItem>
                        <asp:ListItem Value="Sum">Sum</asp:ListItem>
                        <asp:ListItem Value="Average">Average</asp:ListItem>
                        <asp:ListItem Value="Max">Max</asp:ListItem>
                        <asp:ListItem Value="Min">Min</asp:ListItem>
                        <asp:ListItem Value="Product">Product</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <agw:GridWeb ID="GridWeb1" runat="server" Width="720px" PresetStyle="Professional1"
                        OnSaveCommand="GridWeb1_SaveCommand" ShowLoading="false">
                    </agw:GridWeb>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
