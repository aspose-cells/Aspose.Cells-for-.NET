<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Filter_AutoFilter"
    MasterPageFile="~/tpl/Demo.Master" Title="Using the AutoFilter Feature to Filter Rows - Aspose.Cells Grid Suite Demos"
    CodeBehind="AutoFilter.aspx.cs" %>

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
                        Using the AutoFilter Feature to Filter Rows - Aspose.Cells Grid Suite Demos
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
            Click <b>Submit Changes</b> ("V") button to see how demo displays auto-filter in
            <b>Row 5</b> enabling user to filter grid contents.
        </p>
        <br />
        <div>
            <acw:GridWeb ID="GridWeb1" runat="server" MaxColumn="3" Width="690px" PresetStyle="Professional1"
                ShowLoading="false" Height="432px">
                <WebWorksheets>
                    <acw:WorksheetDesign Name="SheetAutoFilter">
                    </acw:WorksheetDesign>
                </WebWorksheets>
            </acw:GridWeb>
        </div>
    </div>
</asp:Content>
