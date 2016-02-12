<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="Aspose.DotNetNuke.Modules.AsposeDynamicFormGeneratorExcel.Settings" %>
<div class="dnnClear dnnForm">
    <span id="success_msg" runat="server" visible="false" class="dnnFormMessage dnnFormSuccess"></span>
    <span id="info_msg" runat="server" visible="false" class="dnnFormMessage dnnFormInfo"></span>
    <span id="error_msg" runat="server" visible="false" class="dnnFormMessage dnnFormError"></span>
    <fieldset>
        <div align="lef">
            <h2>
                <img src="/DesktopModules/Aspose.DNN.DynamicFormGenerator.Excel/Images/aspose_logo.gif" />&nbsp;<asp:Label ID="lblTitle" runat="server">Manage Form Fields</asp:Label></h2>
        </div>
        <div class="dnnFormItem">
            <asp:Label ID="lblFieldType" runat="server" Text="Field Type"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlFieldType" runat="server">
                <asp:ListItem Text="TextBox" Selected="True" Value="Text"></asp:ListItem>
                <asp:ListItem Text="Multiline TextBox" Value="MultiText"></asp:ListItem>
                <asp:ListItem Text="Title" Value="Title"></asp:ListItem>
                <asp:ListItem Text="Success Message" Value="Success"></asp:ListItem>
                <asp:ListItem Text="Radio Button" Value="Radio"></asp:ListItem>
                <asp:ListItem Text="CheckBox Button" Value="Check"></asp:ListItem>
                <asp:ListItem Text="DropDown List" Value="DropDown"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="dnnFormItem">
            <asp:Label ID="lblFieldID" runat="server" Text="Field ID (Seprate Multiple Ids with ';' for Radio/Check)"></asp:Label><br />
            <asp:TextBox ID="txtFieldId" runat="server"></asp:TextBox>
        </div>
        <div class="dnnFormItem">
            <asp:Label ID="lblFieldLabelText" runat="server" Text="Field Label Text"></asp:Label><br />
            <asp:TextBox ID="txtFieldLableText" runat="server"></asp:TextBox>
        </div>
        <div class="dnnFormItem">
            <asp:Label ID="lblFieldValues" runat="server" Text="Field Values (Seprate Multiple Values with ';' for Radio/Check/Dropdown)"></asp:Label><br />
            <asp:TextBox ID="txtFieldValues" runat="server"></asp:TextBox>
        </div>
        <div class="dnnFormItem">
            <asp:Label ID="lblDisplayonForm" runat="server" Text="Display on Form"></asp:Label><br />
            <asp:CheckBox ID="chkIsDisplay" runat="server" Text="Display on Form" Checked="true" />
        </div>
        <div class="dnnFormItem">
            <asp:Label ID="lblSortId" runat="server" Text="Sort #"></asp:Label><br />
            <asp:TextBox ID="txtSortId" runat="server"></asp:TextBox>
        </div>
        <br />
        <div align="lef">
            <asp:Button ID="ProcessButton" CssClass="dnnPrimaryAction" runat="server" Visible="true" OnClick="ProcessButton_Click" Text="Add New Field"></asp:Button>
            &nbsp;&nbsp;&nbsp;<asp:Button ID="ClearFormButton" CssClass="dnnPrimaryAction" runat="server" Visible="true" OnClick="ClearFormButton_Click" Text="Clear Form"></asp:Button>

        </div>
    </fieldset>

    <span><b>Form Fields</b></span>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="true" OnRowCommand="GridView1_RowCommand" DataKeyNames="Field ID" EmptyDataText="There is no record found.">
        <Columns>
            <asp:BoundField DataField="Sort ID" HeaderText="Sort Id" ItemStyle-HorizontalAlign="Center"
                ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" />
            <asp:BoundField DataField="Field Type" HeaderText="Field Type" ItemStyle-HorizontalAlign="Left"
                ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Left" HeaderStyle-VerticalAlign="Middle" />
            <asp:BoundField DataField="Field ID" HeaderText="Field ID" ItemStyle-HorizontalAlign="Left"
                ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Left" HeaderStyle-VerticalAlign="Middle" />
            <asp:BoundField DataField="Field Label Text" HeaderText="Field Label Text" ItemStyle-HorizontalAlign="Left"
                ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Left" HeaderStyle-VerticalAlign="Middle" />
            <asp:BoundField DataField="Field Values" HeaderText="Field Values" ItemStyle-HorizontalAlign="Left"
                ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Left" HeaderStyle-VerticalAlign="Middle" />
            <asp:BoundField DataField="Is Display" HeaderText="Is Display" ItemStyle-HorizontalAlign="Left"
                ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Left" HeaderStyle-VerticalAlign="Middle" />
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                HeaderText="Edit" Visible="true" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"
                HeaderStyle-Width="80px">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEditCommand" runat="server" ToolTip="Click here to edit record" CausesValidation="false"
                        CommandArgument='<%# Eval("Field ID") %>' CommandName="EditSetupValue">Edit
                    </asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <br />
    .
</div>
