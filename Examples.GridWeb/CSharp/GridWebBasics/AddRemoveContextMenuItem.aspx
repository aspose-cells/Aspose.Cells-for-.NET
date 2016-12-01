<%@ Page Title="Add/Remove Context Menu Item - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master"
     AutoEventWireup="true" CodeBehind="AddRemoveContextMenuItem.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics.AddRemoveContextMenuItem" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                         
            Add/Remove Context Menu Item Command - Aspose.Cells Grid Suite Examples                    
        </h2>                
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
          Click <b>Add Context Menu Item Command</b> to add a new context menu item command. <br />
          Click <b>Remove Context Menu Item Command</b> to remove context menu item command. <br />
          Verify the results by right clicking the cells on the GridWeb.
        </p>
    </div>
    <div style="padding:10px">                       
        <asp:Button ID="btnAddContextMenuItem" runat="server" Text="Add Context Menu Item Command" OnClick="btnAddContextMenuItem_Click" />                        
        <asp:Button ID="btnRemoveContextMenuItem" runat="server" Text="Remove Context Menu Item Command" OnClick="btnRemoveContextMenuItem_Click" />        
    </div>
    <div style="text-align:center">                   
           <acw:GridWeb ID="GridWeb1" runat="server" XhtmlMode="True" EnableAJAX="true" OnCustomCommand="GridWeb1_CustomCommand" EnableClientColumnOperations="False" EnableClientFreeze="False" EnableClientMergeOperations="False" EnableClientRowOperations="False" EnableStyleDialogbox="False">						                                          
               <CustomCommandButtons>                                
                   <acw:CustomCommandButton Command="MyContextMenuItemCommand" Text="ContextMenuItemText" CommandType="ContextMenuItem"></acw:CustomCommandButton>                             
               </CustomCommandButtons>						                 
           </acw:GridWeb>          
    </div>
</asp:Content>
