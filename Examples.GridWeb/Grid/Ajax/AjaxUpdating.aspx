<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Ajax_AjaxUpdating"
    MasterPageFile="~/tpl/Demo.Master" Title="AJAX Updating - Aspose.Cells Grid Suite Demos"
    CodeBehind="AjaxUpdating.aspx.cs" %>

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
                        AJAX Updating - Aspose.Cells Grid Suite Demos
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
            This demo uses functionality from AJAX to minimize the <b>Postbacks</b> to the server
            by setting the <b>GridWeb.EnableAJAX = true</b>. In order to get this demo work,
            you need to install Microsoft AJAX Toolkit for ASP.Net 2.0.
        </p>
        <p>
            Enter values for your <b>Height(CM)</b> in <b>C3</b> and <b>Weight(KG)</b> in <b>C4</b>
            to see how GridWeb control performs calculations and updates Cell <b>C5</b> and
            <b>C6</b> with results utilizing AJAX-Style updates. Also, <b>Number Validation</b>
            is appplied on Input Cells(<b>C3</b>,<b>C4</b>). You can refresh the GridWeb control
            any time by pressing the <b>Reload</b> button.
        </p>
        <p>
        </p>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnReload" runat="server" Text="Reload" OnClick="btnReload_Click">
                    </asp:Button>
                </td>
            </tr>
            <tr>
                <td height="236px">
                    <acw:GridWeb ID="GridWeb1" runat="server" Width="630px" Height="236px" ShowLoading="false"
                        ActiveCellBgColor="#DDDDFF" ActiveHeaderBgColor="#0088BB" ActiveHeaderColor="#CCCCFF"
                        ActiveTabStyle-BackColor="#CCCCFF" ActiveTabStyle-BorderColor="#004466" ActiveTabStyle-BorderStyle="Solid"
                        ActiveTabStyle-BorderWidth="1px" ActiveTabStyle-Font-Names="Arial" ActiveTabStyle-Font-Size="10pt"
                        ActiveTabStyle-ForeColor="#003344" ActiveTabStyle-Height="15pt" ActiveTabStyle-NumberType="0"
                        ActiveTabStyle-Rotation="0" ActiveTabStyle-Wrap="False" BottomTableStyle-BackColor="#BBBBFF"
                        BottomTableStyle-BorderCollapse="Collapse" BottomTableStyle-BorderWidth="0px"
                        BottomTableStyle-Height="20pt" BottomTableStyle-LayoutFixed="Fixed" BottomTableStyle-TopBorderStyle-BorderColor="#006699"
                        BottomTableStyle-TopBorderStyle-BorderStyle="Solid" BottomTableStyle-TopBorderStyle-BorderWidth="1px"
                        DefaultGridLineColor="#CFCFFF" EnableAJAX="True" EnableSmartNavigation="True"
                        FrameTableStyle-BackColor="White" FrameTableStyle-BorderCollapse="Collapse" FrameTableStyle-BorderColor="#0077AA"
                        FrameTableStyle-BorderStyle="Solid" FrameTableStyle-BorderWidth="1px" FrameTableStyle-LayoutFixed="Fixed"
                        HeaderBarStyle-BackColor="#006699" HeaderBarStyle-BorderColor="#CCCCFF" HeaderBarStyle-BorderStyle="Solid"
                        HeaderBarStyle-BorderWidth="1px" HeaderBarStyle-Font-Names="Arial" HeaderBarStyle-Font-Size="10pt"
                        HeaderBarStyle-ForeColor="#CCCCFF" HeaderBarStyle-HorizontalAlign="Center" HeaderBarStyle-NumberType="0"
                        HeaderBarStyle-Rotation="0" HeaderBarStyle-VerticalAlign="Middle" HeaderBarStyle-Wrap="False"
                        HeaderBarTableStyle-BorderCollapse="Collapse" HeaderBarTableStyle-BorderWidth="0px"
                        HeaderBarTableStyle-LayoutFixed="Fixed" ScrollBarArrowColor="White" ScrollBarBaseColor="#CCCCFF"
                        SelectCellBgColor="#EEEEFF" TabStyle-BackColor="#006699" TabStyle-BorderColor="#004466"
                        TabStyle-BorderStyle="Solid" TabStyle-BorderWidth="1px" TabStyle-Font-Names="Arial"
                        TabStyle-Font-Size="10pt" TabStyle-ForeColor="White" TabStyle-Height="15pt" TabStyle-NumberType="0"
                        TabStyle-Rotation="0" TabStyle-Wrap="False" ViewTableStyle-BorderCollapse="Collapse"
                        ViewTableStyle-BorderWidth="0px" ViewTableStyle-LayoutFixed="Fixed">
                        
                    </acw:GridWeb>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
