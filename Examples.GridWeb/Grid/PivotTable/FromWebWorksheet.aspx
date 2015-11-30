<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_PivotTable_FromWebWorksheet"
    MasterPageFile="~/tpl/Demo.Master" Title="Working with different data sources - Aspose.Cells Grid Suite Demos"
    CodeBehind="FromWebWorksheet.aspx.cs" %>

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
                        Working with different data sources - Aspose.Cells Grid Suite Demos
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
            In this demo, an existing worksheet is read into WenWorksheet using <b>ImportExcelFile</b>
            method of GridWeb. A <b>Pivot Table</b> is created on imported data using the following
            three diffrent methods.Moreover, this demo applies diffrent Style settings to Pivot
            Table <b>Fields</b>, such as <b>Orientation</b>,<b>Font Type</b> and <b>Font Size</b>.
            You can also Save/Open the output in <b>XLS</b>Format by clicking the Save Button
            on GridWeb Control Bar.
        </p>
        <p>
            Click <b>From Worksheet</b> to see how demo generates PivotTable report from a worksheet.<br />
            
        </p>
        <p>
            Please download the
            <asp:HyperLink ID="lnkFile" runat="server" NavigateUrl="~/file/PivotTable.xls">PivotTable.xls</asp:HyperLink>
            used in this demo.</p>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnReload" runat="server" Text="Reload Source Data" Width="130px"
                        OnClick="btnReload_Click"></asp:Button>
                    <asp:Button ID="btnWorksheet" runat="server" Text="From WorkSheet" Width="130px"
                        OnClick="btnWorksheet_Click"></asp:Button>
                      
                </td>
            </tr>
            <tr>
                <td>
                    <acw:GridWeb ID="GridWeb1" runat="server" Width="700px" PresetStyle="Traditional1"
                        ShowLoading="false" OnSaveCommand="GridWeb1_SaveCommand">
                    </acw:GridWeb>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
