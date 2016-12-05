<%@ Page Title="Calculate Custom Functions - Aspose.Cells Grid Suite Examples" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CalculateCustomFunction.aspx.vb"
     Inherits="Aspose.Cells.GridWeb.Examples.VisualBasic.Articles.CalculateCustomFunction" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="componentDescriptionTxt" style="text-align: center; width: 100%; font-size: small;">                            
        <h2 class="demos-heading-bg">                               
            Calculate Custom Functions - Aspose.Cells Grid Suite Examples                    
        </h2>
    </div>
    <div style="text-align: left; font-size: small;" class="componentDescriptionTxt">
        <p>
           A custom function is added to cell B3, which multiples a given number by 2.
        </p>        
    </div>
    <div style="text-align: center; font-size: small;" class="componentDescriptionTxt">                        
        <acw:GridWeb ID="GridWeb1" runat="server">                        
        </acw:GridWeb>
    </div>
</asp:Content>
