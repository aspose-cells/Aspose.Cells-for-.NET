<%@ Page Title="Calculate Custom Functions - Aspose.Cells Grid Suite Examples" Language="C#" 
    MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalculateCustomFunction.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Articles.CalculateCustomFunction" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-size: small;">
        <tbody>
            <tr>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                       Calculate Custom Functions - Aspose.Cells Grid Suite Examples
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
           A custom function is added to cell B3, which multiples a given number by 2.
        </p>
        <br />
        <div style="text-align: left">
            <table>
                <tr>
                    <td>
                        <acw:GridWeb ID="GridWeb1" runat="server">
                        </acw:GridWeb>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
