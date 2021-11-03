<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.Worksheets.ImportDataView"
    MasterPageFile="~/Site.Master" Title="Import DataView - Aspose.Cells Grid Suite Examples"
    CodeBehind="ImportDataView.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                 
            Import DataView - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Load</b> to see how data is imported from a DataView Object (data stored
            in a database table is fetched to DataView Object) and displayed in the GridWeb
            Control.
        </p>
        <p>                                    
            Import from DataView:&nbsp;&nbsp;                        
            <asp:Button ID="Button1" runat="server" Text="Load" OnClick="Button1_Click"></asp:Button>&nbsp;
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">
        <acw:GridWeb ID="GridWeb1" runat="server" XhtmlMode="true" Height="300px" Width="657px"
            ShowLoading="false" PresetStyle="Colorful1" MaxColumn="3" OnSaveCommand="GridWeb1_SaveCommand">
        </acw:GridWeb>
    </div>
</asp:Content>
