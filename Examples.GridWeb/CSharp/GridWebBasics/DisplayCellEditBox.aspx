<%@ Page Title="Display Cell Edit Box - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="DisplayCellEditBox.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics.DisplayCellEditBox" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
 
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.js"></script> 
 
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-family: Arial; font-size: small;">
        <tbody>
            <tr>
                <td style="width: 19; vertical-align: top;">
                    <img alt="" height="41" src="/Common/images/heading_lft.jpg" width="19" />
                </td>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                       Display Cell Edit Box - Aspose.Cells Grid Suite Examples
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
            Click <b>Show Edit Box</b> to toggle cell edit box visibility.
        </p>
        <br />
        <div>
             <asp:CheckBox ID="CheckBox1" runat="server" Text="Show Edit Box" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" />
        </div>
         <div style="width: 100%; height: 100%; ">
                          
                          <acw:GridWeb ID="GridWeb1" runat="server" OnSaveCommand="GridWeb1_SaveCommand"                      
                            ShowLoading="False" PresetStyle="Professional1">
                            </acw:GridWeb> 
                                                                
                   
        </div>
    </div>
</asp:Content>

