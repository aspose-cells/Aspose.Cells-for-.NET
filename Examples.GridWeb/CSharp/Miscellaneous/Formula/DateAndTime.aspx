<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Formula_DateAndTime"
    MasterPageFile="~/Site.Master" Title="Date & Time - Formula - Aspose.Cells Grid Suite Demos"
    CodeBehind="DateAndTime.aspx.cs" %>

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
                        Date and Time - Formula - Aspose.Cells Grid Suite Demos
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
            This demo loads an existing file into an empty WebWorksheet to demonstrate how GridWeb
            applies typical <b>Date</b> formulas to grid cells and calculates formula values.
            Click <b>Reload</b> to reload initial data for the grid. You can also Save/Open
            the output in <b>XLS</b>Format by clicking the Save Button on GridWeb Control Bar.
        </p>
        <p>
            Please download the
            <asp:HyperLink ID="lnkFile" runat="server" NavigateUrl="~/file/DateAndTime.xls">DateAndTime.xls</asp:HyperLink>
            used in this demo.</p>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnReload" runat="server" Text="Reload" OnClick="btnReload_Click">
                    </asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                    <acw:GridWeb ID="GridWeb1" runat="server" Height="189px" Width="680px" PresetStyle="Professional2"
                        OnSaveCommand="GridWeb1_SaveCommand" ShowLoading="false">
                        <WebWorksheets>
                            <acw:WorksheetDesign runat="server" Name="Sheet1" DataMember="">
                            </acw:WorksheetDesign>
                        </WebWorksheets>
                    </acw:GridWeb>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
