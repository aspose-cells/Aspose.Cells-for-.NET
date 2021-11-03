<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.DataBind.ExpandChildView"
    MasterPageFile="~/Site.Master" Title="Hierarchical View - Aspose.Cells Grid Suite Examples"
    CodeBehind="ExpandChildView.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                    
            Hierarchical View - Aspose.Cells Grid Suite Examples                    
        </h2>        
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            This example demonstrates the <b>DataBind</b> funcationality with database using Datasets.
            Data is fetched into three <b>Datasets</b> using <b>OleDbAdapter</b> and primary
            Dataset [Customer] is binded with empty <b>GridWorksheet</b>.On selection [Expand
            Button] of any record from Customer, it's child record [Order] will be loaded, further
            selection of Order will load child record [OrderDetail].
        </p>
        <p>
            GridWeb by default provides the functionality to <b>Sort</b> items in a Column by
            clicking any <b>Column Header</b>. You can ADD/UPDATE/DELETE records using the GridWeb
            Control Bar. Any Changes made in GridWeb will also be reflected in binded database.
            You can also Save/Open the output in <b>XLS</b>format by clicking the Save Button
            on GridWeb Control Bar.
        </p>    
        <p>                            
            <asp:CheckBox ID="chkNoScrollBar" runat="server" Text="No Scroll Bars" AutoPostBack="True"                        
                OnCheckedChanged="chkNoScrollBar_CheckedChanged"></asp:CheckBox>    
        </p>    
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <acw:GridWeb ID="GridWeb1" runat="server" ActiveTabStyle-Height="15pt" ActiveTabStyle-BorderWidth="1px"
            ShowLoading="false" ActiveTabStyle-Font-Size="10pt" ActiveTabStyle-Font-Names="Arial"
            ActiveTabStyle-BorderColor="#003399" ActiveTabStyle-BorderStyle="Solid" ActiveTabStyle-ForeColor="#003399"
            ActiveTabStyle-BackColor="#CCCCFF" ActiveTabStyle-Wrap="False" ActiveCellBgColor="#DDDDFF"
            TabStyle-Height="15pt" TabStyle-BorderWidth="1px" TabStyle-Font-Size="10pt" TabStyle-Font-Names="Arial"
            TabStyle-BorderColor="#003399" TabStyle-BorderStyle="Solid" TabStyle-ForeColor="White"
            TabStyle-BackColor="#3366CC" TabStyle-Wrap="False" HeaderBarTableStyle-LayoutFixed="Fixed"
            HeaderBarTableStyle-BorderWidth="0px" HeaderBarTableStyle-BorderCollapse="Collapse"
            HeaderBarStyle-VerticalAlign="Middle" HeaderBarStyle-BorderWidth="1px" HeaderBarStyle-Font-Size="10pt"
            HeaderBarStyle-Font-Names="Arial" HeaderBarStyle-BorderColor="#3366CC" HeaderBarStyle-BorderStyle="Solid"
            HeaderBarStyle-HorizontalAlign="Center" HeaderBarStyle-ForeColor="#CCCCFF" HeaderBarStyle-BackColor="#003399"
            HeaderBarStyle-Wrap="False" BottomTableStyle-LayoutFixed="Fixed" BottomTableStyle-Height="20pt"
            BottomTableStyle-BorderWidth="0px" BottomTableStyle-BorderCollapse="Collapse"
            BottomTableStyle-TopBorderStyle-BorderStyle="Solid" BottomTableStyle-TopBorderStyle-BorderWidth="1px"
            BottomTableStyle-TopBorderStyle-BorderColor="#3366CC" BottomTableStyle-BackColor="#CCCCFF"
            ViewTableStyle-LayoutFixed="Fixed" ViewTableStyle-BorderWidth="0px" ViewTableStyle-BorderCollapse="Collapse"
            SelectCellBgColor="#EEEEFF" FrameTableStyle-BorderStyle="Solid" FrameTableStyle-LayoutFixed="Fixed"
            FrameTableStyle-BorderWidth="1px" FrameTableStyle-BorderColor="#3366CC" FrameTableStyle-BorderCollapse="Collapse"
            FrameTableStyle-BackColor="#FAFAFF" ActiveHeaderBgColor="#0055BB" PresetStyle="Colorful2"
            Width="654px" Height="177px" DefaultGridLineColor="#CCCCFF" ActiveHeaderColor="#CCCCFF"
            ScrollBarArrowColor="#CCCCFF" ScrollBarBaseColor="#3366CC" OnBindingChildView="GridWeb1_BindingChildView"
            EnableAJAX="True">
            <WebWorksheets>
                <acw:WorksheetDesign Name="Sheet1">
                    <BindColumns>
                        <acw:BindColumn IsAutoCreated="True" Caption="CustomerID" DataField="CustomerID">
                            <Style BackColor="#C0C0FF">
                                </Style>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="General"></ColumnHeaderStyle>
                            <Validation IsRequired="True"></Validation>
                            <AlternativeStyle ForeColor="White" BackColor="#8080FF"></AlternativeStyle>
                        </acw:BindColumn>
                        <acw:BindColumn IsAutoCreated="True" Caption="CompanyName" DataField="CompanyName">
                            <Style BackColor="#C0C0FF">
                                </Style>
                            <AlternativeStyle ForeColor="White" BackColor="#8080FF"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="General"></ColumnHeaderStyle>
                        </acw:BindColumn>
                        <acw:BindColumn IsAutoCreated="True" Caption="ContactName" DataField="ContactName">
                            <Style BackColor="#C0C0FF">
                                </Style>
                            <AlternativeStyle ForeColor="White" BackColor="#8080FF"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="General"></ColumnHeaderStyle>
                        </acw:BindColumn>
                        <acw:BindColumn IsAutoCreated="True" Caption="ContactTitle" DataField="ContactTitle">
                            <Style BackColor="#C0C0FF">
                                </Style>
                            <AlternativeStyle ForeColor="White" BackColor="#8080FF"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="General"></ColumnHeaderStyle>
                        </acw:BindColumn>
                        <acw:BindColumn Width="80pt" IsAutoCreated="True" Caption="Address" DataField="Address">
                            <Style BackColor="#C0C0FF">
                                </Style>
                            <AlternativeStyle ForeColor="White" BackColor="#8080FF"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="General"></ColumnHeaderStyle>
                        </acw:BindColumn>
                        <acw:BindColumn IsAutoCreated="True" Caption="City" DataField="City">
                            <Style BackColor="#C0C0FF">
                                </Style>
                            <AlternativeStyle ForeColor="White" BackColor="#8080FF"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="General"></ColumnHeaderStyle>
                        </acw:BindColumn>
                        <acw:BindColumn IsAutoCreated="True" Caption="Region" DataField="Region">
                            <Style BackColor="#C0C0FF">
                                </Style>
                            <AlternativeStyle ForeColor="White" BackColor="#8080FF"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="General"></ColumnHeaderStyle>
                        </acw:BindColumn>
                        <acw:BindColumn IsAutoCreated="True" Caption="PostalCode" DataField="PostalCode">
                            <Style BackColor="#C0C0FF">
                                </Style>
                            <AlternativeStyle ForeColor="White" BackColor="#8080FF"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="General"></ColumnHeaderStyle>
                        </acw:BindColumn>
                        <acw:BindColumn IsAutoCreated="True" Caption="Country" DataField="Country">
                            <Style BackColor="#C0C0FF">
                                </Style>
                            <AlternativeStyle ForeColor="White" BackColor="#8080FF"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="General"></ColumnHeaderStyle>
                        </acw:BindColumn>
                        <acw:BindColumn IsAutoCreated="True" Caption="Phone" DataField="Phone">
                            <Style BackColor="#C0C0FF">
                                </Style>
                            <AlternativeStyle ForeColor="White" BackColor="#8080FF"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="General"></ColumnHeaderStyle>
                        </acw:BindColumn>
                        <acw:BindColumn IsAutoCreated="True" Caption="Fax" DataField="Fax">
                            <Style BackColor="#C0C0FF">
                                </Style>
                            <AlternativeStyle ForeColor="White" BackColor="#8080FF"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="General"></ColumnHeaderStyle>
                        </acw:BindColumn>
                    </BindColumns>
                </acw:WorksheetDesign>
            </WebWorksheets>
        </acw:GridWeb>                
    </div>
</asp:Content>
