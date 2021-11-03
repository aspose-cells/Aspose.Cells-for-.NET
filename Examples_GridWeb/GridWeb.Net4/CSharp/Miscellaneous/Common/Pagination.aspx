<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Miscellaneous.Common.Pagination"
    MasterPageFile="~/Site.Master" Title="Paginating Sheet - Aspose.Cells Grid Suite Examples"
    CodeBehind="Pagination.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                         
            Paginating Sheet - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Reload</b> to see how data is loaded from data source and divided it into
            several pages to improve performance or support logical data division for subsequent
            data preview in the GridWeb Control.
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Reload" OnClick="Button1_Click"></asp:Button>
        </p>        
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server" PageSize="20" EnablePaging="True" Width="637px"                            
            Height="400px" HeaderBarWidth="100pt" MaxColumn="6" MaxRow="6" PresetStyle="Colorful2"                            
            ShowLoading="false" OnSaveCommand="GridWeb1_SaveCommand">                        
        </acw:GridWeb>         
    </div>
</asp:Content>
