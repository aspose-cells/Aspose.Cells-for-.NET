<%@ Page Title="Get GridWeb Version - Aspose.Cells Grid Suite Examples" Language="C#" 
    MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetGridWebVersion.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics.GetGridWebVersion" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">   
    <script type="text/javascript">
        // ExStart:GetClientSideGridWebVersion
        function GetVersion()
        {
            alert(acw_version);
            console.log(acw_version);
            return false;
        }
        // ExEnd:GetClientSideGridWebVersion
    </script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                           
            Get GridWeb Version - Aspose.Cells Grid Suite Examples                    
        </h2>                
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">            
        <p>            
            Click <b>Get GridWeb Version</b> to see GridWeb version or <br /> click <b>Get Client Side GridWeb Version</b> to see version for GridWeb's client side script.                      
        </p>    
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">                    
        <p>                           
            <asp:Label ID="Label1" runat="server"></asp:Label>                            
            <br />                           
            <asp:Button ID="btnGetGridWebVersion" runat="server" Text="Get GridWeb Version" OnClick="btnGetGridWebVersion_Click" />                            
            <asp:Button ID="btnGetClientSideVersion" runat="server" Text="Get Client Side GridWeb Version" OnClientClick="return GetVersion();" />                        
        </p>            
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server"                            
            OnSaveCommand="GridWeb1_SaveCommand" ShowLoading="false">                        
        </acw:GridWeb>
    </div>
</asp:Content>



