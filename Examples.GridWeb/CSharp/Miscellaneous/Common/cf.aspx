<%@ Page Language="C#"  MasterPageFile="~/Site.Master" Title="Conditional Formatting Excel File - Aspose.Cells Grid Suite Demos"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="Aspose.Cells.GridWeb" %>
<%@ Import Namespace="Aspose.Cells.GridWeb.Data" %>
<%@ Register TagPrefix="agw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
 
<script runat="server">
     
    protected void Button1_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath("~");

        path = path.Substring(0, path.LastIndexOf("\\"));
        string fileName = path + "\\File\\conditionalformating.xlsx";
        gwcf.ImportExcelFile(fileName);
    }

   

</script>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
 
 
    <table class="componentDescriptionTxt" border="0" cellpadding="0" cellspacing="0"
        style="text-align: center; width: 100%; font-family: Arial; font-size: small;">
        <tbody>
            <tr>
                <td style="width: 19; vertical-align: top;">
                    <img alt="" height="41" src="/Common/images/heading_lft.jpg" width="19" />
                </td>
                <td class="demos-heading-bg" style="width: 100%;">
                    <h2 class="demos-heading-bg">
                        Conditional formatting support - Aspose.Cells Grid Suite Demos
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
            Click <b>Load</b> to see how demo loads files with conditional formatting setting,try edit columen B with diffrent value,to see the result.<br />
            Load an Excel file:
                  
                        <asp:Button ID="Button2" runat="server" Text="Load" OnClick="Button1_Click"></asp:Button>
        </p>
        <br />
         <div style="width: 100%; height: 100%; ">
            
                        &nbsp;&nbsp; &nbsp;
                       <agw:gridweb ID="gwcf" runat="server"  EnableAsync=true Height="402px" 
                            Width="800px"/>

                        <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%" 
                            ScrollBars="Both">
                        </asp:Panel>
                             
                                         
                   
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeaderContent">
    <style type="text/css">
        .style1
        {
            width: 722px;
        }
    </style>
</asp:Content>

 
