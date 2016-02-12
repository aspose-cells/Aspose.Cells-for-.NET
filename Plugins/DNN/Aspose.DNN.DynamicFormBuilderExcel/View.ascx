<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Aspose.DotNetNuke.Modules.AsposeDynamicFormGeneratorExcel.View" %>
<div class="dnnClear dnnForm">
    <span id="success_msg" runat="server" visible="false" class="dnnFormMessage dnnFormSuccess"></span>
    <span id="info_msg" runat="server" visible="false" class="dnnFormMessage dnnFormInfo"></span>
    <span id="error_msg" runat="server" visible="false" class="dnnFormMessage dnnFormError"></span>
    <fieldset>
        <div align="center">
            <h2>
                <img src="/DesktopModules/Aspose.DNN.DynamicFormGenerator.Excel/Images/aspose_logo.gif" />&nbsp;<asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
        </div>
        <div class="dnnFormItem">

            <asp:PlaceHolder runat="server" ID="myPlaceHolder"></asp:PlaceHolder>
        </div>
    </fieldset>
    <div align="center">
        <asp:Button ID="ProcessButton" CssClass="dnnPrimaryAction" runat="server" Visible="true" OnClick="ProcessButton_Click" Text="Submit"></asp:Button>
        &nbsp;&nbsp;&nbsp;<asp:Button ID="ClearFormButton" CssClass="dnnPrimaryAction" runat="server" Visible="true" OnClick="ClearFormButton_Click" Text="Clear"></asp:Button>
    </div>
</div>
