<%@ Page Title="Apply Header Bar Styles - Aspose.Cells Grid Suite Examples" Language="C#" 
    MasterPageFile="~/tpl/Demo.Master" AutoEventWireup="true" CodeBehind="ApplyHeaderBarStyle.aspx.cs" 
    Inherits="Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics.ApplyHeaderBarStyle" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>
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
                        Apply Header Bar Styles - Aspose.Cells Grid Suite Examples
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
            Click the button to apply header bar styles for  
            the GridWeb Control.
        </p>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        
                        <p>
                            <asp:Button ID="btnApplyHeaderStyle" runat="server" Text="Apply Header Bar Style" OnClick="btnApplyHeaderStyle_Click" />
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

