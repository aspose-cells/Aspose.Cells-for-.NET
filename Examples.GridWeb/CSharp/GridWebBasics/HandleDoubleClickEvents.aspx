<%@ Page Language="C#" AutoEventWireup="true" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics.HandleDoubleClickEvents" MasterPageFile="~/Site.Master"
    Title="Handling Double Click Events - Aspose.Cells Grid Suite Examples" CodeBehind="HandleDoubleClickEvents.aspx.cs" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                           
            Handling Double Click Events - Aspose.Cells Grid Suite Examples                    
        </h2>                
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Enable all double click events</b> to see how demo demonstrates handling events (double
            click demo cells to see JavaScript alert) in the GridWeb Control.
        </p>    
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Checked="false" Text="Enable all double click events"                            
            OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server" Width="635px" Height="250px" HeaderBarWidth="100pt"                            
            EnableDoubleClickEvent="False" PresetStyle="Professional1" OnSaveCommand="GridWeb1_SaveCommand"                            
            OnSheetTabClick="GridWeb1_SheetTabClick" OnSubmitCommand="GridWeb1_SubmitCommand"                            
            OnUndoCommand="GridWeb1_UndoCommand" OnCellDoubleClick="GridWeb1_CellDoubleClick"                            
            OnColumnDoubleClick="GridWeb1_ColumnDoubleClick" OnRowDoubleClick="GridWeb1_RowDoubleClick"                            
            ShowLoading="false">                        
        </acw:GridWeb>           
    </div>
</asp:Content>
