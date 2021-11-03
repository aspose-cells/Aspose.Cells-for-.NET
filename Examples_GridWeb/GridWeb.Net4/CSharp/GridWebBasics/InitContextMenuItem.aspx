<%@ Page Title="Init Context Menu Item Command - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InitContextMenuItem.aspx.cs"
     Inherits="Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics.InitContextMenuItem" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                  
            Init Context Menu Item Command - Aspose.Cells Grid Suite Examples                    
        </h2>        
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Right click on the GridWeb to see the custom command item added to context menu. <br />
            Try clicking custom command <b>ContextMenuItemText</b> to execute it.                    
        </p>
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <!-- ExStart:InitContextMenuItem -->                        
        <acw:GridWeb ID="GridWeb1" runat="server" XhtmlMode="True" EnableAJAX="true" OnCustomCommand="GridWeb1_CustomCommand" EnableClientColumnOperations="False" EnableClientFreeze="False" EnableClientMergeOperations="False" EnableClientRowOperations="False" EnableStyleDialogbox="False">                             
            <CustomCommandButtons>                                
                <acw:CustomCommandButton Command="MyContextMenuItemCommand" Text="ContextMenuItemText" CommandType="ContextMenuItem"></acw:CustomCommandButton>                             
            </CustomCommandButtons>                        
        </acw:GridWeb>                        
        <!-- ExEnd:InitContextMenuItem -->
    </div>
</asp:Content>




