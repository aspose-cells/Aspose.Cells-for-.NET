<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_DataBind_DataBind2"
    MasterPageFile="~/tpl/Demo.Master" Title="Data Binding at Runtime - Aspose.Cells Grid Suite Demos"
    CodeBehind="DataBind2.aspx.cs" %>

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
                        Data Binding at Runtime - Aspose.Cells Grid Suite Demos
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
            This demo binds the data from database to Worksheets Designer. Data is fetched into
            a <b>Dataset</b> from Database using <b>OleDbAdapter</b> and binded with empty <b>WebWorksheet</b>.
            There is one <b>CheckBox</b> that Show/Hide Header of GridWeb.
        </p>
        <p>
            GridWeb by default provides the functionality to <b>Sort</b> items in a Column by
            clicking any <b>Column Header</b>. Another functionality that GridWeb provides is
            of <b>Calender Control</b> just by knowing that Column Type is of Date. Click on
            any cell from column "CreatedDate" and see how the Calender Control popup. For this
            demo <b>Validation</b> of type <b>Required</b> is applied on column <b>ProductName</b>.
            If any cell from this column is empty then it will be marked. You can ADD/UPDATE/DELETE
            records using the GridWeb Control Bar. Any Changes made in GridWeb will also be
            reflected in binded database. You can also Save/Open the output in <b>XLS</b>format
            by clicking the Save Button on GridWeb Control Bar.
        </p>
    </div>
    <table>
        <tr>
            <td>
                <asp:CheckBox ID="chkControlHeaderBar" runat="server" Text="Show Control HeaderBar"
                    AutoPostBack="True" Checked="True" OnCheckedChanged="chkControlHeaderBar_CheckedChanged">
                </asp:CheckBox>
            </td>
        </tr>
        <tr>
            <td>
                <acw:GridWeb ID="GridWeb1" runat="server" PresetStyle="Professional2" ScrollBarBaseColor="#DDCCFF"
                EnableAjax=true
                    ShowLoading="false" ScrollBarArrowColor="White" ActiveHeaderColor="#CCCCFF" DefaultGridLineColor="#CFCFFF"
                    ActiveTabStyle-Height="15pt" ActiveTabStyle-BorderWidth="1px" ActiveTabStyle-Font-Size="10pt"
                    ActiveTabStyle-Font-Names="Arial" ActiveTabStyle-BorderColor="#7777AA" ActiveTabStyle-BorderStyle="Solid"
                    ActiveTabStyle-ForeColor="#003344" ActiveTabStyle-BackColor="#CCBBFF" ActiveTabStyle-Wrap="False"
                    ActiveCellBgColor="#DDDDFF" TabStyle-Height="15pt" TabStyle-BorderWidth="1px"
                    TabStyle-Font-Size="10pt" TabStyle-Font-Names="Arial" TabStyle-BorderColor="#7777AA"
                    TabStyle-BorderStyle="Solid" TabStyle-ForeColor="White" TabStyle-BackColor="#665599"
                    TabStyle-Wrap="False" HeaderBarTableStyle-LayoutFixed="Fixed" HeaderBarTableStyle-BorderWidth="0px"
                    HeaderBarTableStyle-BorderCollapse="Collapse" ActiveHeaderBgColor="#8877BB" HeaderBarStyle-VerticalAlign="Middle"
                    HeaderBarStyle-BorderWidth="1px" HeaderBarStyle-Font-Size="10pt" HeaderBarStyle-Font-Names="Arial"
                    HeaderBarStyle-BorderColor="#CCCCFF" HeaderBarStyle-BorderStyle="Solid" HeaderBarStyle-HorizontalAlign="Center"
                    HeaderBarStyle-ForeColor="#CCCCFF" HeaderBarStyle-BackColor="#665599" HeaderBarStyle-Wrap="False"
                    BottomTableStyle-LayoutFixed="Fixed" BottomTableStyle-Height="20pt" BottomTableStyle-BorderWidth="0px"
                    BottomTableStyle-BorderCollapse="Collapse" BottomTableStyle-TopBorderStyle-BorderStyle="Solid"
                    BottomTableStyle-TopBorderStyle-BorderWidth="1px" BottomTableStyle-TopBorderStyle-BorderColor="#006699"
                    BottomTableStyle-BackColor="#CCBBFF" ViewTableStyle-LayoutFixed="Fixed" ViewTableStyle-BorderWidth="0px"
                    ViewTableStyle-BorderCollapse="Collapse" SelectCellBgColor="#EEEEFF" FrameTableStyle-BorderStyle="Solid"
                    FrameTableStyle-LayoutFixed="Fixed" FrameTableStyle-BorderWidth="1px" FrameTableStyle-BorderColor="#7777AA"
                    FrameTableStyle-BorderCollapse="Collapse" FrameTableStyle-BackColor="White" OnCustomCommand="GridWeb1_CustomCommand"
                    OnSaveCommand="GridWeb1_SaveCommand">
                    
                    <CustomCommandButtons>
                        <acw:CustomCommandButton ImageUrl="../../images/addrec.gif" Command="ADD" ToolTip="Add a new record.">
                        </acw:CustomCommandButton>
                        <acw:CustomCommandButton ImageUrl="../../images/delrec.gif" Command="DELETE" ToolTip="Delete the record.">
                        </acw:CustomCommandButton>
                        <acw:CustomCommandButton ImageUrl="../../images/updatedb.gif" Command="UPDATE" ToolTip="Update the database(Only available for local users).">
                        </acw:CustomCommandButton>
                    </CustomCommandButtons>
                </acw:GridWeb>
            </td>
        </tr>
    </table>
</asp:Content>
