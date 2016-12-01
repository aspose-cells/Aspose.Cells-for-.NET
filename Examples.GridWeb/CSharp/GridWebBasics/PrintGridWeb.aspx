<%@ Page Title="Print GridWeb - Aspose.Cells Grid Suite Examples" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
     CodeBehind="PrintGridWeb.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics.PrintGridWeb" %>

<%@ Register Assembly="Aspose.Cells.GridWeb" Namespace="Aspose.Cells.GridWeb" TagPrefix="acw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <!-- ExStart:PrintGridWebJS -->
    <script>
        function Print(grid) {
            // Get Id of GridWeb
            var grid = document.getElementById('<%= GridWeb1.ClientID %>');
            // Call print
            grid.print();
        }
    </script>
    <!-- ExEnd:PrintGridWebJS -->
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                                                  
            Print GridWeb - Aspose.Cells Grid Suite Examples                    
        </h2>        
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
            Click <b>Print</b> button to see how the contents of GridWeb can be printed.
        </p>        
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">               
        <!-- ExStart:PrintGridWeb -->                   
        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="Print();return false;" />                   
        <!-- ExEnd:PrintGridWeb -->            
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server"                           
            OnSaveCommand="GridWeb1_SaveCommand" ShowLoading="false">                        
        </acw:GridWeb>        
    </div>
</asp:Content>