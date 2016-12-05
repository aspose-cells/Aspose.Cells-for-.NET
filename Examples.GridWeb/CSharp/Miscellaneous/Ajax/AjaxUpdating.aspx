<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Ajax.AjaxUpdating"
    MasterPageFile="~/Site.Master" Title="AJAX Updating - Aspose.Cells Grid Suite Examples"
    CodeBehind="AjaxUpdating.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                             
            AJAX Updating - Aspose.Cells Grid Suite Examples                    
        </h2>            
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">            
        <p>
            This examples uses functionality from AJAX to minimize the <b>Postbacks</b> to the server
            by setting the <b>GridWeb.EnableAJAX = true</b>. In order for this example to work,
            you need to install Microsoft AJAX Toolkit for ASP.Net 2.0.
        </p>
        <p>
            Enter values for your <b>Height(CM)</b> in <b>C3</b> and <b>Weight(KG)</b> in <b>C4</b>
            to see how GridWeb control performs calculations and updates Cell <b>C5</b> and
            <b>C6</b> with results utilizing AJAX-Style updates. Also, <b>Number Validation</b>
            is appplied on Input Cells(<b>C3</b>,<b>C4</b>). You can refresh the GridWeb control
            any time by pressing the <b>Reload</b> button.
        </p>
        <p>                            
            <asp:Button ID="btnReload" runat="server" Text="Reload" OnClick="btnReload_Click"></asp:Button>    
        </p>    
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                    
        <acw:GridWeb ID="GridWeb1" runat="server" Width="630px" Height="236px" ShowLoading="false"                        
            ActiveCellBgColor="#DDDDFF" ActiveHeaderBgColor="#0088BB" ActiveHeaderColor="#CCCCFF"                        
            ActiveTabStyle-BackColor="#CCCCFF" ActiveTabStyle-BorderColor="#004466" ActiveTabStyle-BorderStyle="Solid"                        
            ActiveTabStyle-BorderWidth="1px" ActiveTabStyle-Font-Names="Arial" ActiveTabStyle-Font-Size="10pt"                        
            ActiveTabStyle-ForeColor="#003344" ActiveTabStyle-Height="15pt" ActiveTabStyle-NumberType="0"                        
            ActiveTabStyle-Rotation="0" ActiveTabStyle-Wrap="False" BottomTableStyle-BackColor="#BBBBFF"                        
            BottomTableStyle-BorderCollapse="Collapse" BottomTableStyle-BorderWidth="0px"                        
            BottomTableStyle-Height="20pt" BottomTableStyle-LayoutFixed="Fixed" BottomTableStyle-TopBorderStyle-BorderColor="#006699"                        
            BottomTableStyle-TopBorderStyle-BorderStyle="Solid" BottomTableStyle-TopBorderStyle-BorderWidth="1px"                        
            DefaultGridLineColor="#CFCFFF" EnableAJAX="True" EnableSmartNavigation="True"                        
            FrameTableStyle-BackColor="White" FrameTableStyle-BorderCollapse="Collapse" FrameTableStyle-BorderColor="#0077AA"                        
            FrameTableStyle-BorderStyle="Solid" FrameTableStyle-BorderWidth="1px" FrameTableStyle-LayoutFixed="Fixed"                        
            HeaderBarStyle-BackColor="#006699" HeaderBarStyle-BorderColor="#CCCCFF" HeaderBarStyle-BorderStyle="Solid"                        
            HeaderBarStyle-BorderWidth="1px" HeaderBarStyle-Font-Names="Arial" HeaderBarStyle-Font-Size="10pt"                        
            HeaderBarStyle-ForeColor="#CCCCFF" HeaderBarStyle-HorizontalAlign="Center" HeaderBarStyle-NumberType="0"                        
            HeaderBarStyle-Rotation="0" HeaderBarStyle-VerticalAlign="Middle" HeaderBarStyle-Wrap="False"                        
            HeaderBarTableStyle-BorderCollapse="Collapse" HeaderBarTableStyle-BorderWidth="0px"                        
            HeaderBarTableStyle-LayoutFixed="Fixed" ScrollBarArrowColor="White" ScrollBarBaseColor="#CCCCFF"                        
            SelectCellBgColor="#EEEEFF" TabStyle-BackColor="#006699" TabStyle-BorderColor="#004466"                        
            TabStyle-BorderStyle="Solid" TabStyle-BorderWidth="1px" TabStyle-Font-Names="Arial"                        
            TabStyle-Font-Size="10pt" TabStyle-ForeColor="White" TabStyle-Height="15pt" TabStyle-NumberType="0"                        
            TabStyle-Rotation="0" TabStyle-Wrap="False" ViewTableStyle-BorderCollapse="Collapse"                        
            ViewTableStyle-BorderWidth="0px" ViewTableStyle-LayoutFixed="Fixed">                     
        </acw:GridWeb>                
    </div>
</asp:Content>
