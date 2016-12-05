<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.RowsAndColumns.GroupRows"
    MasterPageFile="~/Site.Master" Title="Grouping Rows - Aspose.Cells Grid Suite Examples"
    CodeBehind="GroupRows.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Grouping Rows - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Load Data</b> to populate grid with data. Data is fetched into a <b>Dataset</b>
            using <b>OleDbAdapter</b> and binded with empty <b>WebWorksheet</b>. You can select
            several rows and click <b>Group</b> from GridWeb Control Box to see your rows grouped,
            also you can click <b>Ungroup</b> to see the data in original (ungrouped) state.
            The result from GridWeb can be opened/saved using the <b>Save</b> button from GridWeb
            Control Box.
        </p>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnLoad" runat="server" Text="Load Data" OnClick="btnLoad_Click">
                    </asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                    <acw:GridWeb ID="GridWeb1" runat="server" ShowLoading="false"  PresetStyle="Professional1"
                        OnCustomCommand="GridWeb1_CustomCommand">
                        <CustomCommandButtons>
                            <acw:CustomCommandButton Width="60px" ImageUrl="group.gif" Command="GROUP" ToolTip="Group Rows"
                                Text="Group">
                            </acw:CustomCommandButton>
                            <acw:CustomCommandButton Width="66px" ImageUrl="ungroup.gif" Command="UNGROUP" ToolTip="Ungroup Rows"
                                Text="Ungroup">
                            </acw:CustomCommandButton>
                        </CustomCommandButtons>
                        <WebWorksheets>
                            <acw:WorksheetDesign Name="Sheet1">
                            </acw:WorksheetDesign>
                        </WebWorksheets>
                    </acw:GridWeb>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
