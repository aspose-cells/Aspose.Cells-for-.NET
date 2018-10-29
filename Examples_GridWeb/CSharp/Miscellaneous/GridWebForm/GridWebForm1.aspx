<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_GridWebForm_GridWebForm1"
    MasterPageFile="~/Site.Master" Title="GridWeb FormView - Aspose.Cells Grid Suite Demos"
    CodeBehind="GridWebForm1.aspx.cs" %>

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
                        GridWeb FormView - Aspose.Cells Grid Suite Demos
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
            Data is fetched into a <b>Dataset</b> using <b>OleDbAdapter</b> and binded with
            empty <b>WebWorksheet</b>. Also a <b>List</b> is created from same Dataset using
            <b>LoadValueList</b> method for column <b>CategoryID</b>
        </p>
        <p>
            By clicking the <b>View</b>, GridWeb activates the <b>WebGridForm</b> for the selected
            entry. WebGridForm further allows you to <b>Navigate</b> through different Categories,
            also it will enable you to <b>Add</b>, <b>Update</b> and <b>Delete</b> the selected
            Category. Any changes made using WebGridForm are reflected in binded Database.
        </p>
        <p>
            You may see how demo enables you to edit form values by using a special <b>WebForm View</b>
            mode. Just click <b>View</b> text in the first column to see the form where you
            can enter new values for grid columns.You can also Save/Open the output in <b>XLS</b>Format
            by clicking the Save Button on GridWeb Control Bar.
        </p>
        <table>
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
                        OnCellCommand="GridWeb1_CellCommand">
                        <WebWorksheets>
                            <acw:WorksheetDesign DataMember="Products" Name="Sheet1">
                                <BindColumns>
                                    <acw:BindColumn CommandName="VIEWDETAIL" UseAlternativeStyle="False" EnableSort="False"
                                        Caption="View" CommandText="[VIEW]">
                                        <Style ForeColor="Blue">
                                            </Style>
                                    </acw:BindColumn>
                                    <acw:BindColumn IsAutoCreated="True" Caption="ProductID" DataField="ProductID">
                                        <Validation ValidationType="Integer" IsRequired="True"></Validation>
                                    </acw:BindColumn>
                                    <acw:BindColumn IsAutoCreated="True" Caption="CategoryID" DataField="CategoryID">
                                        <Validation ValidationType="Integer"></Validation>
                                    </acw:BindColumn>
                                    <acw:BindColumn IsAutoCreated="True" Caption="CreatedDate" DataField="CreatedDate">
                                        <Validation ValidationType="Date"></Validation>
                                    </acw:BindColumn>
                                    <acw:BindColumn IsAutoCreated="True" Caption="Discontinued" DataField="Discontinued">
                                        <Validation ValidationType="CheckBox"></Validation>
                                    </acw:BindColumn>
                                    <acw:BindColumn IsAutoCreated="True" Caption="ProductName" DataField="ProductName">
                                    </acw:BindColumn>
                                    <acw:BindColumn IsAutoCreated="True" Caption="QuantityPerUnit" DataField="QuantityPerUnit">
                                    </acw:BindColumn>
                                    <acw:BindColumn IsAutoCreated="True" Caption="ReorderLevel" DataField="ReorderLevel">
                                        <Validation ValidationType="Integer"></Validation>
                                    </acw:BindColumn>
                                    <acw:BindColumn IsAutoCreated="True" Caption="SupplierID" DataField="SupplierID">
                                        <Validation ValidationType="Integer"></Validation>
                                    </acw:BindColumn>
                                    <acw:BindColumn IsAutoCreated="True" Caption="UnitPrice" NumberType="Currency3" DataField="UnitPrice">
                                        <Validation ValidationType="Number"></Validation>
                                    </acw:BindColumn>
                                    <acw:BindColumn IsAutoCreated="True" Caption="UnitsInStock" DataField="UnitsInStock">
                                        <Validation ValidationType="Integer"></Validation>
                                    </acw:BindColumn>
                                    <acw:BindColumn IsAutoCreated="True" Caption="UnitsOnOrder" DataField="UnitsOnOrder">
                                        <Validation ValidationType="Integer"></Validation>
                                    </acw:BindColumn>
                                </BindColumns>
                            </acw:WorksheetDesign>
                        </WebWorksheets>
                    </acw:GridWeb>
                    <acw:GridWebForm ID="GridWebForm2" runat="server" GridWebControl="GridWeb1">
                    </acw:GridWebForm>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
