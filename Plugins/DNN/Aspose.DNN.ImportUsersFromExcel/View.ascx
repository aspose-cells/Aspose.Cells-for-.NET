<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Aspose.DNN.ImportUsersFromExcel.View" %>
<style>
    .uploadBtn {
        height: 32px;
    }
</style>
<div class="dnnForm">

    <span id="success_msg" runat="server" visible="false" class="dnnFormMessage dnnFormSuccess"></span>
    <span id="info_msg" runat="server" visible="false" class="dnnFormMessage dnnFormInfo"></span>
    <span id="error_msg" runat="server" visible="false" class="dnnFormMessage dnnFormError">Invalid file format or wrong data format uploaded.</span>
    <h3>Upload Excel File</h3>
    <div class="dnnFormItem">
        <asp:FileUpload ID="ImportFileUpload" runat="server" />
        <asp:Button ID="UploadButton" CssClass="dnnPrimaryAction uploadBtn" runat="server" Text="Process Excel File" OnClick="UploadButton_Click"></asp:Button>
    </div>

    <div class="dnnFormItem">
        <b>Note:</b> The excel file contain the list of users to be imported as per format defined in this <asp:LinkButton runat="server" ID="templateFile" OnClick="templateFile_Click">template file</asp:LinkButton>.
    </div>

    <div ID="ImportHeading" runat="server" visible="false">
        <hr />
        <h3>Import Users into DNN</h3>        
    </div>    

    <div class="dnnFormItem">
        <asp:Button ID="ProcessButton" CssClass="dnnPrimaryAction uploadBtn dnnRight" runat="server" Text="Import Selected Users" Visible="false" OnClick="ProcessButton_Click"></asp:Button>
    </div>

    <div class="dnnFormItem">
        <asp:GridView ID="UsersGridView" Width="100%" Visible="false" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no users." CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="rgHeader" HeaderStyle-Width="20px">
                    <HeaderTemplate>
                        <asp:CheckBox ID="SelectAllCheckBox" CssClass="selectAllCheckBox" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="SelectedCheckBox" CssClass="selectableCheckBox" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DisplayName" HeaderText="Display Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Username" HeaderText="Username" />                              
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>

</div>
