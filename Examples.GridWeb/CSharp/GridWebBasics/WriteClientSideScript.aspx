<%@ Page Title="Write Client Side Script - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="WriteClientSideScript.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics.WriteClientSideScript" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <script>
        // ExStart:WriteClientSideScript
        // A client side JavaScript function that will be executed before submitting data to server
        function ConfirmFunction(arg, cancelEdit) {
            // Showing a confirm dialog with some information where "this" refers to GridWeb
            return confirm("The control is " + this.id + "\nThe command is \"" + arg + "\".\nDo you want to continue?");
        }
        
        // A client side JavaScript function that will be executed whenever a validation error will occur
        function ValidationErrorFunction() {
            // Showing an alert message where "this" refers to GridWeb
            alert(this.id + ": Please correct your input error.");
        }
        // ExEnd:WriteClientSideScript
    </script>
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
                        Write Client Side Script - Aspose.Cells Grid Suite Examples
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
            Date Validation is added on cell C1. Valid date format is yyyy-mm-dd. Try entering an invalid date format and click <b>Save</b> <br />
            to see how the client side validation error function executes.
            <br /><br />
            Try to submit the GridWeb using any command buttons and see client side submit function result.
        </p>
        <br />
        <div>
            <table>

                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server" Width="700" Height="400 "
                           OnSaveCommand="GridWeb1_SaveCommand" ShowLoading="false">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
</asp:Content>