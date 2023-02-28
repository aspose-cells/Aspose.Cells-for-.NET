<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.DataSourceControl.BindWithDataSourceControl"
    MasterPageFile="~/Site.Master" Title="Bind with DataSourceControl - Aspose.Cells Grid Suite Examples"
    CodeBehind="BindWithDataSourceControl.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                    
            Bind with DataSourceControl - Aspose.Cells Grid Suite Examples                    
        </h2>        
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            This example is to demonstrate the use of Access Data Source that further binded with
            empty <b>GridWorksheet</b>. Insert, Update, Delete queries and their coresponding
            parameters are defined in Access Data Source.
        </p>
        <p>
            You can ADD/UPDATE/DELETE records using the GridWeb Control Bar. Any Changes made
            in GridWeb will also be reflected in binded database. You can also Save/Open the
            output in <b>XLS</b>format by clicking the Save Button on GridWeb Control Bar.
        </p>    
    </div>    
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">
        <acw:GridWeb ID="GridWeb1" runat="server" Width="606px" Height="197px" ActiveCellBgColor="#DDDDFF"
            ShowLoading="false" ActiveHeaderBgColor="#F2F2F2" ActiveTabStyle-BackColor="White"
            ActiveTabStyle-BorderColor="Gray" ActiveTabStyle-BorderStyle="Solid" ActiveTabStyle-BorderWidth="1px"
            ActiveTabStyle-Font-Names="Arial" ActiveTabStyle-Font-Size="10pt" ActiveTabStyle-ForeColor="Black"
            ActiveTabStyle-Height="15pt" ActiveTabStyle-Wrap="False" BottomTableStyle-BackColor="#F0F0F0"
            BottomTableStyle-BorderCollapse="Collapse" BottomTableStyle-BorderWidth="0px"
            BottomTableStyle-Height="20pt" BottomTableStyle-LayoutFixed="Fixed" BottomTableStyle-TopBorderStyle-BorderColor="Gray"
            BottomTableStyle-TopBorderStyle-BorderStyle="Solid" BottomTableStyle-TopBorderStyle-BorderWidth="1px"
            FrameTableStyle-BackColor="White" FrameTableStyle-BorderCollapse="Collapse" FrameTableStyle-BorderColor="Gray"
            FrameTableStyle-BorderStyle="Solid" FrameTableStyle-BorderWidth="1px" FrameTableStyle-LayoutFixed="Fixed"
            HeaderBarStyle-BackColor="#E0E0E0" HeaderBarStyle-BorderColor="Gray" HeaderBarStyle-BorderStyle="Solid"
            HeaderBarStyle-BorderWidth="1px" HeaderBarStyle-BottomBorderStyle-BorderColor="Gray"
            HeaderBarStyle-BottomBorderStyle-BorderStyle="Solid" HeaderBarStyle-BottomBorderStyle-BorderWidth="1px"
            HeaderBarStyle-Font-Names="Arial" HeaderBarStyle-Font-Size="10pt" HeaderBarStyle-ForeColor="Black"
            HeaderBarStyle-HorizontalAlign="Center" HeaderBarStyle-LeftBorderStyle-BorderColor="White"
            HeaderBarStyle-LeftBorderStyle-BorderStyle="Solid" HeaderBarStyle-LeftBorderStyle-BorderWidth="1px"
            HeaderBarStyle-RightBorderStyle-BorderColor="Gray" HeaderBarStyle-RightBorderStyle-BorderStyle="Solid"
            HeaderBarStyle-RightBorderStyle-BorderWidth="1px" HeaderBarStyle-TopBorderStyle-BorderColor="White"
            HeaderBarStyle-TopBorderStyle-BorderStyle="Solid" HeaderBarStyle-TopBorderStyle-BorderWidth="1px"
            HeaderBarStyle-VerticalAlign="Middle" HeaderBarStyle-Wrap="False" HeaderBarTableStyle-BorderCollapse="Separate"
            HeaderBarTableStyle-BorderWidth="0px" HeaderBarTableStyle-LayoutFixed="Fixed"
            OnCustomCommand="GridWeb1_CustomCommand" SelectCellBgColor="#EEEEFF" TabStyle-BackColor="#E0E0E0"
            TabStyle-BorderColor="Gray" TabStyle-BorderStyle="Solid" TabStyle-BorderWidth="1px"
            TabStyle-Font-Names="Arial" TabStyle-Font-Size="10pt" TabStyle-ForeColor="Black"
            TabStyle-Height="15pt" TabStyle-Wrap="False" ViewTableStyle-BorderCollapse="Collapse"
            ViewTableStyle-BorderWidth="0px" ViewTableStyle-LayoutFixed="Fixed" ActiveTabStyle-NumberType="0"
            ActiveTabStyle-RotationAngle="0" EnableClientFreeze="False" HeaderBarStyle-NumberType="0"
            HeaderBarStyle-RotationAngle="0" TabStyle-NumberType="0" TabStyle-RotationAngle="0">
            <CustomCommandButtons>
                <acw:CustomCommandButton ImageUrl="../../images/addrec.gif" Command="ADD" ToolTip="Add a new record."
                    runat="server">
                </acw:CustomCommandButton>
                <acw:CustomCommandButton ImageUrl="../../images/delrec.gif" Command="DELETE" ToolTip="Delete the record."
                    runat="server">
                </acw:CustomCommandButton>
                <acw:CustomCommandButton ImageUrl="../../images/updatedb.gif" Command="UPDATE" ToolTip="Update the database(Only available for local users)."
                    runat="server">
                </acw:CustomCommandButton>
            </CustomCommandButtons>
            <WorkSheets>
                <acw:GridWorksheetDesign runat="server" DataMember="" DataSource="<%# AccessDataSource1 %>"
                    Name="Sheet1">
                    <BindColumns>
                        <acw:BindColumn Caption="ProductID" CommandName="" CommandText="" CustomFormat=""
                            DataField="ProductID" ImageUrl="" IsAutoCreated="True">
                            <Style RotationAngle="0" NumberType="0">
                                </Style>
                            <AlternativeStyle RotationAngle="0" NumberType="0"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="0"></ColumnHeaderStyle>
                            <Validation ValidationType="WholeNumber" />
                        </acw:BindColumn>
                        <acw:BindColumn Caption="ProductName" CommandName="" CommandText="" CustomFormat=""
                            DataField="ProductName" ImageUrl="" IsAutoCreated="True">
                            <Style RotationAngle="0" NumberType="0">
                                </Style>
                            <AlternativeStyle RotationAngle="0" NumberType="0"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="0"></ColumnHeaderStyle>
                        </acw:BindColumn>
                        <acw:BindColumn Caption="SupplierID" CommandName="" CommandText="" CustomFormat=""
                            DataField="SupplierID" ImageUrl="" IsAutoCreated="True">
                            <Style RotationAngle="0" NumberType="0">
                                </Style>
                            <AlternativeStyle RotationAngle="0" NumberType="0"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="0"></ColumnHeaderStyle>
                            <Validation ValidationType="WholeNumber" />
                        </acw:BindColumn>
                        <acw:BindColumn Caption="CategoryID" CommandName="" CommandText="" CustomFormat=""
                            DataField="CategoryID" ImageUrl="" IsAutoCreated="True">
                            <Style RotationAngle="0" NumberType="0">
                                </Style>
                            <AlternativeStyle RotationAngle="0" NumberType="0"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="0"></ColumnHeaderStyle>
                            <Validation ValidationType="WholeNumber" />
                        </acw:BindColumn>
                        <acw:BindColumn Caption="QuantityPerUnit" CommandName="" CommandText="" CustomFormat=""
                            DataField="QuantityPerUnit" ImageUrl="" IsAutoCreated="True">
                            <Style RotationAngle="0" NumberType="0">
                                </Style>
                            <AlternativeStyle RotationAngle="0" NumberType="0"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="0"></ColumnHeaderStyle>
                        </acw:BindColumn>
                        <acw:BindColumn Caption="UnitPrice" CommandName="" CommandText="" CustomFormat=""
                            DataField="UnitPrice" ImageUrl="" IsAutoCreated="True">
                            <Style RotationAngle="0" NumberType="0">
                                </Style>
                            <AlternativeStyle RotationAngle="0" NumberType="0"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="0"></ColumnHeaderStyle>
                            <Validation ValidationType="WholeNumber" />
                        </acw:BindColumn>
                        <acw:BindColumn Caption="UnitsInStock" CommandName="" CommandText="" CustomFormat=""
                            DataField="UnitsInStock" ImageUrl="" IsAutoCreated="True">
                            <Style RotationAngle="0" NumberType="0">
                                </Style>
                            <AlternativeStyle RotationAngle="0" NumberType="0"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="0"></ColumnHeaderStyle>
                            <Validation ValidationType="WholeNumber" />
                        </acw:BindColumn>
                        <acw:BindColumn Caption="UnitsOnOrder" CommandName="" CommandText="" CustomFormat=""
                            DataField="UnitsOnOrder" ImageUrl="" IsAutoCreated="True">
                            <Style RotationAngle="0" NumberType="0">
                                </Style>
                            <AlternativeStyle RotationAngle="0" NumberType="0"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="0"></ColumnHeaderStyle>
                            <Validation ValidationType="WholeNumber" />
                        </acw:BindColumn>
                        <acw:BindColumn Caption="ReorderLevel" CommandName="" CommandText="" CustomFormat=""
                            DataField="ReorderLevel" ImageUrl="" IsAutoCreated="True">
                            <Style RotationAngle="0" NumberType="0">
                                </Style>
                            <AlternativeStyle RotationAngle="0" NumberType="0"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="0"></ColumnHeaderStyle>
                            <Validation ValidationType="WholeNumber" />
                        </acw:BindColumn>
                        <acw:BindColumn Caption="Discontinued" CommandName="" CommandText="" CustomFormat=""
                            DataField="Discontinued" ImageUrl="" IsAutoCreated="True">
                            <Style RotationAngle="0" NumberType="0">
                                </Style>
                            <AlternativeStyle RotationAngle="0" NumberType="0"></AlternativeStyle>
                            <ColumnHeaderStyle RotationAngle="0" NumberType="0"></ColumnHeaderStyle>
                            <Validation ValidationType="CheckBox" />
                        </acw:BindColumn>
                    </BindColumns>
                </acw:GridWorksheetDesign>
            </WorkSheets>
        </acw:GridWeb>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="Northwind.mdb"
            DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = ?" InsertCommand="INSERT INTO [Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
            SelectCommand="SELECT * FROM [Products]" 
            UpdateCommand="UPDATE [Products] SET [ProductName] = ?, [SupplierID] = ?, [CategoryID] = ?, [QuantityPerUnit] = ?, [UnitPrice] = ?, [UnitsInStock] = ?, [UnitsOnOrder] = ?, [ReorderLevel] = ?, [Discontinued] = ? WHERE [ProductID] = ?" 
            onselecting="AccessDataSource1_Selecting">
            <DeleteParameters>
                <asp:Parameter Name="ProductID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="SupplierID" Type="Int32" />
                <asp:Parameter Name="CategoryID" Type="Int32" />
                <asp:Parameter Name="QuantityPerUnit" Type="String" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                <asp:Parameter Name="UnitsInStock" Type="Int16" />
                <asp:Parameter Name="UnitsOnOrder" Type="Int16" />
                <asp:Parameter Name="ReorderLevel" Type="Int16" />
                <asp:Parameter Name="Discontinued" Type="Boolean" />
                <asp:Parameter Name="ProductID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ProductID" Type="Int32" />
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="SupplierID" Type="Int32" />
                <asp:Parameter Name="CategoryID" Type="Int32" />
                <asp:Parameter Name="QuantityPerUnit" Type="String" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                <asp:Parameter Name="UnitsInStock" Type="Int16" />
                <asp:Parameter Name="UnitsOnOrder" Type="Int16" />
                <asp:Parameter Name="ReorderLevel" Type="Int16" />
                <asp:Parameter Name="Discontinued" Type="Boolean" />
            </InsertParameters>
        </asp:AccessDataSource>             
    </div>
</asp:Content>
