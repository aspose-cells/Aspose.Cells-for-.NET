<%@ Page Title="Apply Custom Preset Styles - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="ApplyCustomPresetStyle.aspx.vb" Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.GridWebBasics.ApplyCustomPresetStyle" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <script type="text/javascript">
			function seeCustomStyleFile(file){
				window.open(file, "", "","");
			}
    </script>

    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-family: Arial; font-size: small;">
        <tbody>
            <tr>
                <td style="width: 19; vertical-align: top;">
                    <img alt="" height="41" src="/Common/images/heading_lft.jpg" width="19" />
                </td>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Apply Custom Preset Styles - Aspose.Cells Grid Suite Examples
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
            Click the buttons to load or save custom styles for  
            the GridWeb Control.
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                       
                        <p>
                             <asp:Button ID="btnApplyCustomStyle" runat="server" Text="Apply Custom Style" OnClick="btnApplyCustomStyle_Click" />
                            <asp:Button ID="btnSaveCustomStyle" runat="server" Text="Save Custom Style" OnClick="btnSaveCustomStyle_Click" />
                        </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" Width="606px" HeaderBarWidth="100pt" MaxColumn="6"
                            MaxRow="6" OnSaveCommand="GridWeb1_SaveCommand" ShowLoading="false">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
</asp:Content>



