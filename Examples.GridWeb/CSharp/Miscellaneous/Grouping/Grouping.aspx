<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Grouping_Grouping"
    MasterPageFile="~/Site.Master" Title="Grouping Rows - Aspose.Cells Grid Suite Demos"
    CodeBehind="Grouping.aspx.cs" %>

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
                        Grouping Rows - Aspose.Cells Grid Suite Demos
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
                    <acw:GridWeb ID="GridWeb1" runat="server" ActiveCellBgColor="#DDDDFF" ViewTableStyle-LayoutFixed="Fixed"
                        ShowLoading="false" ViewTableStyle-BorderWidth="0px" ViewTableStyle-BorderCollapse="Collapse"
                        BottomTableStyle-LayoutFixed="Fixed" BottomTableStyle-Height="20pt" BottomTableStyle-BorderWidth="0px"
                        BottomTableStyle-BorderCollapse="Collapse" BottomTableStyle-TopBorderStyle-BorderStyle="Solid"
                        BottomTableStyle-TopBorderStyle-BorderWidth="1px" BottomTableStyle-TopBorderStyle-BorderColor="Gray"
                        BottomTableStyle-BackColor="#F0F0F0" HeaderBarStyle-LeftBorderStyle-BorderStyle="Solid"
                        HeaderBarStyle-LeftBorderStyle-BorderWidth="1px" HeaderBarStyle-LeftBorderStyle-BorderColor="White"
                        HeaderBarStyle-VerticalAlign="Middle" HeaderBarStyle-RightBorderStyle-BorderStyle="Solid"
                        HeaderBarStyle-RightBorderStyle-BorderWidth="1px" HeaderBarStyle-RightBorderStyle-BorderColor="Gray"
                        HeaderBarStyle-TopBorderStyle-BorderStyle="Solid" HeaderBarStyle-TopBorderStyle-BorderWidth="1px"
                        HeaderBarStyle-TopBorderStyle-BorderColor="White" HeaderBarStyle-BorderWidth="1px"
                        HeaderBarStyle-Font-Size="10pt" HeaderBarStyle-Font-Names="Arial" HeaderBarStyle-BorderColor="Gray"
                        HeaderBarStyle-BorderStyle="Solid" HeaderBarStyle-HorizontalAlign="Center" HeaderBarStyle-ForeColor="Black"
                        HeaderBarStyle-BackColor="#E0E0E0" HeaderBarStyle-BottomBorderStyle-BorderStyle="Solid"
                        HeaderBarStyle-BottomBorderStyle-BorderWidth="1px" HeaderBarStyle-BottomBorderStyle-BorderColor="Gray"
                        HeaderBarStyle-Wrap="False" HeaderBarTableStyle-LayoutFixed="Fixed" HeaderBarTableStyle-BorderWidth="0px"
                        HeaderBarTableStyle-BorderCollapse="Separate" ActiveTabStyle-Height="15pt" ActiveTabStyle-BorderWidth="1px"
                        ActiveTabStyle-Font-Size="10pt" ActiveTabStyle-Font-Names="Arial" ActiveTabStyle-BorderColor="Gray"
                        ActiveTabStyle-BorderStyle="Solid" ActiveTabStyle-ForeColor="Black" ActiveTabStyle-BackColor="White"
                        ActiveTabStyle-Wrap="False" SelectCellBgColor="#EEEEFF" FrameTableStyle-BorderStyle="Solid"
                        FrameTableStyle-LayoutFixed="Fixed" FrameTableStyle-BorderWidth="1px" FrameTableStyle-BorderColor="Gray"
                        FrameTableStyle-BorderCollapse="Collapse" FrameTableStyle-BackColor="White" TabStyle-Height="15pt"
                        TabStyle-BorderWidth="1px" TabStyle-Font-Size="10pt" TabStyle-Font-Names="Arial"
                        TabStyle-BorderColor="Gray" TabStyle-BorderStyle="Solid" TabStyle-ForeColor="Black"
                        TabStyle-BackColor="#E0E0E0" TabStyle-Wrap="False" ActiveHeaderBgColor="#F2F2F2"
                        OnCustomCommand="GridWeb1_CustomCommand" OnSaveCommand="GridWeb1_SaveCommand">
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
