<%@ Page Title="Edit/View Modes - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="ApplyEditModes.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.GridWebBasics.ApplyEditModes" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
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
                       Edit/View Modes - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
                <td style="width: 19; vertical-align: top;">
                    <img alt="" height="41" src="/Common/images/heading_rt.jpg" width="19" />
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-family: Arial; font-size: small;" class="componentDescriptionTxt">
        <p class="componentDescriptionTxt">
            Click <b>Enable Editing</b> to see how GridWeb toggles editable / read-only mode.
        </p>
        <br />
        <div class="demoContentArea">
            <table>
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Enable editing" Checked="True"
                            AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
				<td>
					<asp:Panel ID="Panel2" runat="server">
                   
					 Enable/Disable row read-only
					<asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" 
                        oncheckedchanged="CheckBox2_CheckedChanged" />
                    <asp:Label ID="Label1" runat="server" Text="row"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" Text="3"></asp:TextBox>
					 
                    </asp:Panel>
					
				</td>
			</tr>
			<tr>
				<td>
	               <asp:Panel ID="Panel3" runat="server">
					 Enable/Disable column read-only
					<asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" 
                        oncheckedchanged="CheckBox3_CheckedChanged" />
                    <asp:Label ID="Label2" runat="server" Text="col"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" Text="2"></asp:TextBox>
					 </asp:Panel>
				</td>
			</tr>
          
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" PresetStyle="Colorful2" ShowLoading="false"
                            Height="226px" Width="632px" OnSaveCommand="GridWeb1_SaveCommand">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

