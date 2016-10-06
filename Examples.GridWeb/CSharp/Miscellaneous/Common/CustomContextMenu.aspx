<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Common_CustomContextMenu"
    MasterPageFile="~/Site.Master" Title="Custom Context Menu - Aspose.Cells Grid Suite Demos"
    CodeBehind="CustomContextMenu.aspx.cs" %>

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
                        Custom Context Menu - Aspose.Cells Grid Suite Demos
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
            <b>Right-Click</b> to see how demo applies custom context menu and displays data
            in the GridWeb Control.
        </p>
        <br />
        <div class="demoContentArea">
            <table>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" Width="650px" Height="258px" PresetStyle="Professional1"
                            ShowLoading="false" BottomTableStyle-LayoutFixed="Fixed" BottomTableStyle-Height="20pt"
                            BottomTableStyle-BorderWidth="0px" BottomTableStyle-BorderCollapse="Collapse"
                            BottomTableStyle-TopBorderStyle-BorderStyle="Solid" BottomTableStyle-TopBorderStyle-BorderWidth="1px"
                            BottomTableStyle-TopBorderStyle-BorderColor="#006699" BottomTableStyle-BackColor="#BBBBFF"
                            HeaderBarStyle-VerticalAlign="Middle" HeaderBarStyle-BorderWidth="1px" HeaderBarStyle-Font-Size="10pt"
                            HeaderBarStyle-Font-Names="Arial" HeaderBarStyle-BorderColor="#CCCCFF" HeaderBarStyle-BorderStyle="Solid"
                            HeaderBarStyle-HorizontalAlign="Center" HeaderBarStyle-ForeColor="#CCCCFF" HeaderBarStyle-BackColor="#006699"
                            HeaderBarStyle-Wrap="False" ActiveHeaderColor="#CCCCFF" ScrollBarBaseColor="#CCCCFF"
                            ViewTableStyle-LayoutFixed="Fixed" ViewTableStyle-BorderWidth="0px" ViewTableStyle-BorderCollapse="Collapse"
                            HeaderBarTableStyle-LayoutFixed="Fixed" HeaderBarTableStyle-BorderWidth="0px"
                            HeaderBarTableStyle-BorderCollapse="Collapse" ActiveCellBgColor="#DDDDFF" DefaultGridLineColor="#CFCFFF"
                            SelectCellBgColor="#EEEEFF" ScrollBarArrowColor="White" ActiveHeaderBgColor="#0088BB"
                            TabStyle-Height="15pt" TabStyle-BorderWidth="1px" TabStyle-Font-Size="10pt" TabStyle-Font-Names="Arial"
                            TabStyle-BorderColor="#004466" TabStyle-BorderStyle="Solid" TabStyle-ForeColor="White"
                            TabStyle-BackColor="#006699" TabStyle-Wrap="False" FrameTableStyle-BorderStyle="Solid"
                            FrameTableStyle-LayoutFixed="Fixed" FrameTableStyle-BorderWidth="1px" FrameTableStyle-BorderColor="#0077AA"
                            FrameTableStyle-BorderCollapse="Collapse" FrameTableStyle-BackColor="White" ActiveTabStyle-Height="15pt"
                            ActiveTabStyle-BorderWidth="1px" ActiveTabStyle-Font-Size="10pt" ActiveTabStyle-Font-Names="Arial"
                            ActiveTabStyle-BorderColor="#004466" ActiveTabStyle-BorderStyle="Solid" ActiveTabStyle-ForeColor="#003344"
                            ActiveTabStyle-BackColor="#CCCCFF" ActiveTabStyle-Wrap="False" EnableClientColumnOperations="False"
                            EnableClientFreeze="False" EnableClientMergeOperations="False" EnableClientRowOperations="False"
                            EnableStyleDialogbox="False" OnCustomCommand="GridWeb1_CustomCommand">
                            <CustomCommandButtons>
                                <acw:CustomCommandButton Command="COMMAND1" Text="COMMAND1" CommandType="ContextMenuItem">
                                </acw:CustomCommandButton>
                                <acw:CustomCommandButton Command="COMMAND2" Text="COMMAND2" CommandType="ContextMenuItem">
                                </acw:CustomCommandButton>
                            </CustomCommandButtons>
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
