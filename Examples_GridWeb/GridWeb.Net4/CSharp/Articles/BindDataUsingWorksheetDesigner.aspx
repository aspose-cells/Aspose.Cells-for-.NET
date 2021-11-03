<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Articles.BindDataUsingWorksheetDesigner"
    MasterPageFile="~/Site.Master" Title="Data Binding using Worksheets Designer - Aspose.Cells Grid Suite Examples"
    CodeBehind="BindDataUsingWorksheetDesigner.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                            
            Data Binding using Worksheets Designer - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Bind</b> to see this data is binded with the help of Worksheets Designer.
            Data is fetched into a <b>Dataset</b> from Database using <b>OleDbAdapter</b> and
            binded with empty <b>WebWorksheet</b>. There are two <b>CheckBoxes</b>, each Enable/Disable
            diffrent properties of GridWeb. CheckBox <b>Create in-sheet headers</b> Show/Hide
            the GridWeb's Header. and checkBox <b>Show Control HeaderBar</b> Show/Hide the GridWeb's
            Header Bar.
        </p>
        <p>
            GridWeb by default provides the functionality to <b>Sort</b> items in a Column by
            clicking any <b>Column Header</b>. Another functionality that GridWeb provides is
            of <b>Calender Control</b> just by knowing that Column Type is of Date. Click on
            any cell from column "CreatedDate" and see how the Calender Control popup. You can
            ADD/UPDATE/DELETE records using the GridWeb Control Bar. Any Changes made in GridWeb
            will also be reflected in binded database. You can also Save/Open the output in
            <b>XLS</b> Format by clicking the Save Button on GridWeb Control Bar.
        </p>
        <p>
                                
            <asp:Button ID="BtnBind" runat="server" Text="Bind" OnClick="BtnBind_Click"></asp:Button>&nbsp;
            <asp:CheckBox ID="chkCreateSheetHeader" runat="server" Text="Create in-sheet headers" AutoPostBack="True"                        
                Checked="True" OnCheckedChanged="chkCreateSheetHeader_CheckedChanged"></asp:CheckBox>                    
            <asp:CheckBox ID="chkControlHeaderBar" runat="server" Text="Show Control HeaderBar"                        
                AutoPostBack="True" Checked="True" OnCheckedChanged="chkControlHeaderBar_CheckedChanged">                    
            </asp:CheckBox>
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">            
        <acw:GridWeb ID="GridWeb1" runat="server" PageSize="500" ScrollBarBaseColor="#CCCCFF"
            ShowLoading="false" ScrollBarArrowColor="White" ActiveHeaderColor="#CCCCFF" DefaultGridLineColor="#CFCFFF"
            PresetStyle="Professional1" ActiveTabStyle-Height="15pt" ActiveTabStyle-BorderWidth="1px"
            ActiveTabStyle-Font-Size="10pt" ActiveTabStyle-Font-Names="Arial" ActiveTabStyle-BorderColor="#004466"
            ActiveTabStyle-BorderStyle="Solid" ActiveTabStyle-ForeColor="#003344" ActiveTabStyle-BackColor="#CCCCFF"
            ActiveTabStyle-Wrap="False" ActiveCellBgColor="#DDDDFF" TabStyle-Height="15pt"
            TabStyle-BorderWidth="1px" TabStyle-Font-Size="10pt" TabStyle-Font-Names="Arial"
            TabStyle-BorderColor="#004466" TabStyle-BorderStyle="Solid" TabStyle-ForeColor="White"
            TabStyle-BackColor="#006699" TabStyle-Wrap="False" HeaderBarTableStyle-LayoutFixed="Fixed"
            HeaderBarTableStyle-BorderWidth="0px" HeaderBarTableStyle-BorderCollapse="Collapse"
            ActiveHeaderBgColor="#0088BB" HeaderBarStyle-VerticalAlign="Middle" HeaderBarStyle-BorderWidth="1px"
            HeaderBarStyle-Font-Size="10pt" HeaderBarStyle-Font-Names="Arial" HeaderBarStyle-BorderColor="#CCCCFF"
            HeaderBarStyle-BorderStyle="Solid" HeaderBarStyle-HorizontalAlign="Center" HeaderBarStyle-ForeColor="#CCCCFF"
            HeaderBarStyle-BackColor="#006699" HeaderBarStyle-Wrap="False" BottomTableStyle-LayoutFixed="Fixed"
            BottomTableStyle-Height="20pt" BottomTableStyle-BorderWidth="0px" BottomTableStyle-BorderCollapse="Collapse"
            BottomTableStyle-TopBorderStyle-BorderStyle="Solid" BottomTableStyle-TopBorderStyle-BorderWidth="1px"
            BottomTableStyle-TopBorderStyle-BorderColor="#006699" BottomTableStyle-BackColor="#BBBBFF"
            ViewTableStyle-LayoutFixed="Fixed" ViewTableStyle-BorderWidth="0px" ViewTableStyle-BorderCollapse="Collapse"
            SelectCellBgColor="#EEEEFF" FrameTableStyle-BorderStyle="Solid" FrameTableStyle-LayoutFixed="Fixed"
            FrameTableStyle-BorderWidth="1px" FrameTableStyle-BorderColor="#0077AA" FrameTableStyle-BorderCollapse="Collapse"
            FrameTableStyle-BackColor="White" OnCustomCommand="GridWeb1_CustomCommand" OnSaveCommand="GridWeb1_SaveCommand">
            <WebWorksheets>
                <acw:WorksheetDesign DataMember="Products" BindStartRow="2" Name="Products" EnableCreateBindColumnHeader="True"
                    DataSource='<%# dataSet11 %>'>
                    <BindColumns>
                        <acw:BindColumn IsAutoCreated="True" Caption="ProductID" DataField="ProductID">
                            <Style BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" BackColor="#A0A0FF">
                                </Style>
                            <Validation ValidationType="Integer" IsRequired="True"></Validation>
                            <ColumnHeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="#E0E0E0"
                                BackColor="Teal"></ColumnHeaderStyle>
                            <AlternativeStyle BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" BackColor="#C0C0FF">
                            </AlternativeStyle>
                        </acw:BindColumn>
                        <acw:BindColumn IsAutoCreated="True" Caption="CreatedDate" DataField="CreatedDate">
                            <Style BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" BackColor="#A0A0FF">
                                </Style>
                            <Validation ValidationType="Date"></Validation>
                            <ColumnHeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="#E0E0E0"
                                BackColor="Teal"></ColumnHeaderStyle>
                            <AlternativeStyle BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" BackColor="#C0C0FF">
                            </AlternativeStyle>
                        </acw:BindColumn>
                        <acw:BindColumn Width="80pt" IsAutoCreated="True" Caption="Discontinued" DataField="Discontinued">
                            <Style BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" BackColor="#A0A0FF">
                                </Style>
                            <Validation ValidationType="CheckBox"></Validation>
                            <ColumnHeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="#E0E0E0"
                                BackColor="Teal"></ColumnHeaderStyle>
                            <AlternativeStyle BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" BackColor="#C0C0FF">
                            </AlternativeStyle>
                        </acw:BindColumn>
                        <acw:BindColumn Width="80pt" IsAutoCreated="True" Caption="ProductName" DataField="ProductName">
                            <Style BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" BackColor="#A0A0FF">
                                </Style>
                            <Validation IsRequired="True"></Validation>
                            <ColumnHeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="#E0E0E0"
                                BackColor="Teal"></ColumnHeaderStyle>
                            <AlternativeStyle BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" BackColor="#C0C0FF">
                            </AlternativeStyle>
                        </acw:BindColumn>
                        <acw:BindColumn IsAutoCreated="True" Caption="CategoryID" DataField="CategoryID">
                            <Style BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" HorizontalAlign="Right"
                                BackColor="#A0A0FF">
                                </Style>
                            <Validation ValidationType="DropDownList" ValueText="|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20">
                            </Validation>
                            <ColumnHeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="#E0E0E0"
                                BackColor="Teal"></ColumnHeaderStyle>
                            <AlternativeStyle BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" HorizontalAlign="Right"
                                BackColor="#C0C0FF"></AlternativeStyle>
                        </acw:BindColumn>
                        <acw:BindColumn Width="90pt" IsAutoCreated="True" Caption="QuantityPerUnit" DataField="QuantityPerUnit">
                            <Style BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" HorizontalAlign="Right"
                                BackColor="#A0A0FF">
                                </Style>
                            <ColumnHeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="#E0E0E0"
                                BackColor="Teal"></ColumnHeaderStyle>
                            <AlternativeStyle BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" HorizontalAlign="Right"
                                BackColor="#C0C0FF"></AlternativeStyle>
                        </acw:BindColumn>
                        <acw:BindColumn IsAutoCreated="True" Caption="UnitPrice" NumberType="Currency3" DataField="UnitPrice">
                            <Style BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" HorizontalAlign="Right"
                                BackColor="#A0A0FF">
                                </Style>
                            <Validation ValidationType="Number"></Validation>
                            <ColumnHeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="#E0E0E0"
                                BackColor="Teal"></ColumnHeaderStyle>
                            <AlternativeStyle BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" HorizontalAlign="Right"
                                BackColor="#C0C0FF"></AlternativeStyle>
                        </acw:BindColumn>
                        <acw:BindColumn Width="80pt" IsAutoCreated="True" Caption="ReorderLevel" DataField="ReorderLevel">
                            <Style BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" HorizontalAlign="Right"
                                BackColor="#A0A0FF">
                                </Style>
                            <Validation ValidationType="Integer"></Validation>
                            <ColumnHeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="#E0E0E0"
                                BackColor="Teal"></ColumnHeaderStyle>
                            <AlternativeStyle BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" HorizontalAlign="Right"
                                BackColor="#C0C0FF"></AlternativeStyle>
                        </acw:BindColumn>
                        <acw:BindColumn Width="80pt" IsAutoCreated="True" Caption="UnitsInStock" DataField="UnitsInStock">
                            <Style BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" HorizontalAlign="Right"
                                BackColor="#A0A0FF">
                                </Style>
                            <Validation ValidationType="Integer"></Validation>
                            <ColumnHeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="#E0E0E0"
                                BackColor="Teal"></ColumnHeaderStyle>
                            <AlternativeStyle BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" HorizontalAlign="Right"
                                BackColor="#C0C0FF"></AlternativeStyle>
                        </acw:BindColumn>
                        <acw:BindColumn Width="80pt" IsAutoCreated="True" Caption="UnitsOnOrder" DataField="UnitsOnOrder">
                            <Style BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" HorizontalAlign="Right"
                                BackColor="#A0A0FF">
                                </Style>
                            <Validation ValidationType="Integer"></Validation>
                            <ColumnHeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="#E0E0E0"
                                BackColor="Teal"></ColumnHeaderStyle>
                            <AlternativeStyle BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" HorizontalAlign="Right"
                                BackColor="#C0C0FF"></AlternativeStyle>
                        </acw:BindColumn>
                        <acw:BindColumn IsAutoCreated="True" Caption="SupplierID" DataField="SupplierID">
                            <Style BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" BackColor="#A0A0FF">
                                </Style>
                            <Validation ValidationType="Integer"></Validation>
                            <ColumnHeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="#E0E0E0"
                                BackColor="Teal"></ColumnHeaderStyle>
                            <AlternativeStyle BorderWidth="1px" BorderColor="#CFCFFF" BorderStyle="Solid" BackColor="#C0C0FF">
                            </AlternativeStyle>
                        </acw:BindColumn>
                    </BindColumns>
                </acw:WorksheetDesign>
            </WebWorksheets>
            <CustomCommandButtons>
                <acw:CustomCommandButton ImageUrl="../../images/addrec.gif" Command="ADD" ToolTip="Add a new record.">
                </acw:CustomCommandButton>
                <acw:CustomCommandButton ImageUrl="../../images/delrec.gif" Command="DELETE" ToolTip="Delete the record.">
                </acw:CustomCommandButton>
                <acw:CustomCommandButton ImageUrl="../../images/updatedb.gif" Command="UPDATE" ToolTip="Update the database(Only available for local users).">
                </acw:CustomCommandButton>
            </CustomCommandButtons>
        </acw:GridWeb>            
    </div>
</asp:Content>
