<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Format.ApplyCustomFormats"
    MasterPageFile="~/Site.Master" Title="Custom Formats - Aspose.Cells Grid Suite Examples"
    CodeBehind="ApplyCustomFormats.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                
            Custom Formats - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Input custom data format, your cell value (text) and click <b>Submit</b> to see
            how custom formats are applied to a grid cell and your values are displayed.
        </p>    
        <p>
            Reload data:
            <asp:Button ID="Button1" runat="server" Text="Reload" OnClick="Button1_Click"></asp:Button>
        </p>
        <p>
            Custom Format:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            Input Value:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><asp:Button ID="Button2"
                 runat="server" Text="Submit" OnClick="Button2_Click"></asp:Button>
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                
        <acw:GridWeb ID="GridWeb1" runat="server" HeaderBarWidth="100pt" ShowLoading="false"                            
            Height="310px" Width="668px" PresetStyle="Colorful2" OnSaveCommand="GridWeb1_SaveCommand">                        
        </acw:GridWeb>
    </div>    
    <div style="text-align: left; font-size: small;margin-top:10px" class="componentDescriptionTxt">
        <p>
            For the NumberType detail information please see: 
            <a href="http://www.aspose.com/docs/display/cellsnet/List+of+Supported+Number+Formats">
            List of Supported Number Formats</a>
        </p>
    </div>
</asp:Content>
