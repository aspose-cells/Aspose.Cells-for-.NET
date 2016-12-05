<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.DataBind.DataBind3"
    MasterPageFile="~/Site.Master" Title="Data Binding to a Custom Collection - Aspose.Cells Grid Suite Examples"
    CodeBehind="DataBind3.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Data Binding to a Custom Collection - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            This example demonstrate the <b>DataBind</b> functionality of the GridWeb control with
            a user defined <b>List</b> Another functionality that GridWeb provides is of <b>Calender
                Control</b> just by knowing that Column Type is of Date. Click on any cell from
            column "DateField1" and see how the Calender Control popup. Also, <b>Date Type Validation</b>
            is applied on column "DateField1". You can ADD/UPDATE/DELETE records using the GridWeb
            Control Bar. You can also Save/Open the output in <b>XLS</b> format by clicking
            the Save Button on GridWeb Control Bar.
        </p>
    </div>
    <table>
        <tr>
            <td>
                <acw:GridWeb ID="GridWeb1" runat="server" FrameTableStyle-BackColor="White" FrameTableStyle-BorderCollapse="Collapse"
                    ShowLoading="false" FrameTableStyle-BorderColor="#7777AA" FrameTableStyle-BorderWidth="1px"
                    FrameTableStyle-LayoutFixed="Fixed" FrameTableStyle-BorderStyle="Solid" SelectCellBgColor="#EEEEFF"
                    ViewTableStyle-BorderCollapse="Collapse" ViewTableStyle-BorderWidth="0px" ViewTableStyle-LayoutFixed="Fixed"
                    BottomTableStyle-BackColor="#CCBBFF" BottomTableStyle-TopBorderStyle-BorderColor="#006699"
                    BottomTableStyle-TopBorderStyle-BorderWidth="1px" BottomTableStyle-TopBorderStyle-BorderStyle="Solid"
                    BottomTableStyle-BorderCollapse="Collapse" BottomTableStyle-BorderWidth="0px"
                    BottomTableStyle-Height="20pt" BottomTableStyle-LayoutFixed="Fixed" HeaderBarStyle-Wrap="False"
                    HeaderBarStyle-BackColor="#665599" HeaderBarStyle-ForeColor="#CCCCFF" HeaderBarStyle-HorizontalAlign="Center"
                    HeaderBarStyle-BorderStyle="Solid" HeaderBarStyle-BorderColor="#CCCCFF" HeaderBarStyle-Font-Names="Arial"
                    HeaderBarStyle-Font-Size="10pt" HeaderBarStyle-BorderWidth="1px" HeaderBarStyle-VerticalAlign="Middle"
                    ActiveHeaderBgColor="#8877BB" HeaderBarTableStyle-BorderCollapse="Collapse" HeaderBarTableStyle-BorderWidth="0px"
                    HeaderBarTableStyle-LayoutFixed="Fixed" TabStyle-Wrap="False" TabStyle-BackColor="#665599"
                    TabStyle-ForeColor="White" TabStyle-BorderStyle="Solid" TabStyle-BorderColor="#7777AA"
                    TabStyle-Font-Names="Arial" TabStyle-Font-Size="10pt" TabStyle-BorderWidth="1px"
                    TabStyle-Height="15pt" ActiveCellBgColor="#DDDDFF" ActiveTabStyle-Wrap="False"
                    ActiveTabStyle-BackColor="#CCBBFF" ActiveTabStyle-ForeColor="#003344" ActiveTabStyle-BorderStyle="Solid"
                    ActiveTabStyle-BorderColor="#7777AA" ActiveTabStyle-Font-Names="Arial" ActiveTabStyle-Font-Size="10pt"
                    ActiveTabStyle-BorderWidth="1px" ActiveTabStyle-Height="15pt" PresetStyle="Traditional1"
                    DefaultGridLineColor="#CFCFFF" ActiveHeaderColor="#CCCCFF" ScrollBarArrowColor="White"
                    ScrollBarBaseColor="#DDCCFF" Height="233px" Width="496px" OnCustomCommand="GridWeb1_CustomCommand"
                    OnSaveCommand="GridWeb1_SaveCommand">
                    
                    <CustomCommandButtons>
                        <acw:CustomCommandButton ImageUrl="../../images/addrec.gif" Command="ADD" ToolTip="Add a new record.">
                        </acw:CustomCommandButton>
                        <acw:CustomCommandButton ImageUrl="../../images/delrec.gif" Command="DELETE" ToolTip="Delete the record.">
                        </acw:CustomCommandButton>
                    </CustomCommandButtons>
                </acw:GridWeb>
            </td>
        </tr>
    </table>
</asp:Content>
