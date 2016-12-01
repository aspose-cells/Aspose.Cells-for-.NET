<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.XHTML.EnableXHTMLMode" MasterPageFile="~/Site.Master"
    Title="XHTML 1.0 Support - Aspose.Cells Grid Suite Examples" CodeBehind="EnableXHTMLMode.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                 
            XHTML 1.0 Support - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            This example demonstrates Grid control in <b>Xhtml</b>-compliant mode. Depending on
            the <b>DOCTYPE</b> of your HTML document, you may need to use either <b>XhtmlMode="True"</b>
            or <b>XhtmlMode="False"</b>.
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">
        <acw:GridWeb ID="GridWeb1" runat="server" XhtmlMode="True" PresetStyle="Colorful1"
            ShowLoading="false">
        </acw:GridWeb>      
    </div>
</asp:Content>
