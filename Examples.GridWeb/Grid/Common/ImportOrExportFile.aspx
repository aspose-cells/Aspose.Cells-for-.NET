<%@ Page Language="C#" AutoEventWireup="true" Inherits="demos_Common_ImportOrExportFile"
    MasterPageFile="~/tpl/Demo.Master" Title="Import/Export Excel File - Aspose.Cells Grid Suite Demos"
    
    
    CodeBehind="ImportOrExportFile.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

 
 
 

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
 
<!-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.js"></script> -->
 
 <script type="text/javascript" language="JavaScript">

     $(document).ready(function ()
     {
        // $("#btnSubmit").bind("click", function () { $('#' + ' ').trigger("click"); return false; });
       //  $("body, input, textarea,td,span").keypress(function (e)
        // {
        //     alert("hello world");
       //  });
     });
     function dealwithcellselectcallback(cell, ret)
     {
         console.log(cell + ":" + ret);
         //cell.styleStr = "|||||#ff0000|||||||";
                          
         cell.style.color = "red";             
         var instance = gridwebinstance.get("_ctl0_MainContent_GridWeb1");
         instance.updateCellFontColor(cell, 'olive');
         // to do CELLSNET-41831 investigate servisde action is the set take affect on serverside????,want to set red color 
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
                        Import/Export Excel File - Aspose.Cells Grid Suite Demos
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
            Click <b>Load</b> to see how demo loads data from data source and click <b>Save</b>
            button to see how data may be sent to user in a form of Excel file.
        </p>
        <br />
         <div style="width: 100%; height: 100%; ">
            
                        Load an Excel file:&nbsp;&nbsp;
                 <%--       <asp:TextBox ID="TextBox1" TextMode="MultiLine" Text=""

Tooltip="Type your description here" runat="server" Width="300px" Height="100px"></asp:TextBox>--%>   
                        <asp:Button ID="Button1" runat="server" Text="Load" OnClick="Button1_Click"></asp:Button>&nbsp;
                          <acw:GridWeb ID="GridWeb1" runat="server" Width="600pt" OnSaveCommand="GridWeb1_SaveCommand"
                          
                            ShowLoading="True" PresetStyle="Professional1" EnableAJAX="True" 
                              XhtmlMode="True" ShowCellEditBox="True" BorderWidth="0px" Height="380pt" 
                            onsubmitcommand="GridWeb1_SubmitCommand">
                            </acw:GridWeb> 

                        <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%" 
                            ScrollBars="Both">
                        </asp:Panel>
                             
                       <%--  <acw:GridWeb ID="GridWeb1" runat="server" Width="100%" OnSaveCommand="GridWeb1_SaveCommand"
                            OnCellSelectedAjaxCallBackClientFunction="dealwithcellselectcallback"
                            CellClickOnAjax="myCellClickOnAjax" 
                             
                            ShowLoading="True" PresetStyle="Colorful1" EnableAJAX="True" 
                              XhtmlMode="True" ShowCellEditBox="True" BorderWidth="0px" Height="500pt" SpanWrap="True">  </acw:GridWeb>   --%>                    
                   
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeaderContent">
    <style type="text/css">
        .style1
        {
            width: 722px;
        }
    </style>
</asp:Content>

