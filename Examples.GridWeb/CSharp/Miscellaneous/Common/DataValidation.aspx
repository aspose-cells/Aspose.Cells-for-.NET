<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Common_DataValidation"
    MasterPageFile="~/Site.Master" Title="Data Protection / Data Validation - Aspose.Cells Grid Suite Demos"
    CodeBehind="DataValidation.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <script type="text/javascript" language="javascript">
		// check the value, if value > 10000 return true.
		function myvalidation1(source, value)
		{
			if (Number(value) > 10000)
				return true;
			else
				return false;
		}
   
	   function MyValidationErrorFunction()
	   {
	       //Showing an alert message where "this" refers to GridWeb
	       alert(this.id + ": Please correct your input error.");
	   }

    </script>

    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Data Protection / Data Validation - Aspose.Cells Grid Suite Demos
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Reload</b> to see how demo reloads data and applies validation rules so
            that invalid (not matching certain RegExp) values could not be entered in the GridWeb
            Control.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        Input Entry Protection/Validation:&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" Text="Reload" OnClick="Button1_Click"></asp:Button>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="Checkbox1" runat="server" Text="Enable Force Validation" Checked="True"
                            AutoPostBack="True" OnCheckedChanged="Checkbox1_CheckedChanged"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" OnValidationErrorClientFunction="MyValidationErrorFunction"
                            ForceValidation="True" Width="750px" Height="410px" PresetStyle="Standard" XhtmlMode="true"
                            ShowLoading="false" OnSaveCommand="GridWeb1_SaveCommand">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
