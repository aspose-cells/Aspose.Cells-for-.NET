<%@ Page Title="Session Modes - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="ApplySessionModes.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics.ApplySessionModes" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                           
            Session Modes - Aspose.Cells Grid Suite Examples                    
        </h2>            
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p class="componentDescriptionTxt">
            Click <b>Enable Session</b> to see how GridWeb toggles session / sessionless mode.
        </p>    
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">                        
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Enable Session" Checked="True"                            
            AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">       
        <acw:GridWeb ID="GridWeb1" runat="server" PresetStyle="Colorful2" ShowLoading="false"                            
            Height="226px" Width="632px" OnSaveCommand="GridWeb1_SaveCommand">                        
        </acw:GridWeb>        
    </div>
</asp:Content>