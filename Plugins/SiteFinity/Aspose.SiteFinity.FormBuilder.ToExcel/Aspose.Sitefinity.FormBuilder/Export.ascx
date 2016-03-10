<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Export.ascx.cs" Inherits="Aspose.Sitefinity.FormBuilder.Export" %>
 
<style type="text/css">
        .Success {
        color: #3c763d;
        background-color: #dff0d8;
        border-color: #d6e9c6;
        padding: 15px;
        margin-bottom: 20px;
        border: 1px solid transparent;
        border-radius: 4px;
    }
	
	.bottomPadding
	{
	    margin-bottom: 10px;
	
	}

    .alertdanger {
        color: #a94442;
        background-color: #f2dede;
        border-color: #ebccd1;
        padding: 15px;
        margin-bottom: 20px;
        border: 1px solid transparent;
        border-radius: 4px;
    }

    .alertupdate {
        color: #31708f;
        background-color: #d9edf7;
        border-color: #bce8f1;
        padding: 15px;
        margin-bottom: 20px;
        border: 1px solid transparent;
        border-radius: 4px;
    }

    .setColor {
        border-collapse: collapse;
        -webkit-print-color-adjust: exact;
        border: 1px solid #ddd;
        padding: 8px;
        line-height: 1.42857143;
        vertical-align: top;
        border-top: 1px solid #ddd;
        text-align: left;
    }

    .table td,
    .table th {
        text-align: left;
    }


        .table th + th {
            text-align: center;
        }

    .btn {
        display: inline-block;
        color: #FFF !important;
        text-shadow: 0 -1px 0 rgba(0,0,0,0.25) !important;
        border: 5px solid #FFF;
        border-radius: 0;
        box-shadow: none !important;
        cursor: pointer;
        vertical-align: middle;
        position: relative;
        padding: 2px 7px;
        border-color: #87b87f;
    }

    .btn3 {
        display: inline-block;
        color: #FFF !important;
        text-shadow: 0 -1px 0 rgba(0,0,0,0.25) !important;
        border: 5px solid #FFF;
        border-radius: 0;
        box-shadow: none !important;
        cursor: pointer;
        vertical-align: middle;
        position: relative;
        padding: 0px 2px;
        background-color: #428bca !important;
        border-color: #428bca;
    }



    .form-control {
        background-color: #fff;
        border: 1px solid #d5d5d5;
        box-shadow: none !important;
        color: #666;
        padding: 5px 4px;
        border-radius: 0 !important;
        line-height: 1.42857143;
        margin-top: 10px;
        margin-bottom: 5px;
    }

    .legend {
        line-height: inherit;
        color: black;
        border: 0;
        font-size: 1.1em;
        margin-bottom: 10px;
        height: auto;
        width: auto;
        margin-bottom: 0px;
        padding-right: 0px;
        padding-left: 0px;
        border-right-width: 1px;
        margin-right: 1px;
        height: 32px;
    }


    .form-horizontal .control-label1 {
        padding-top: 10px !important;
        text-align: right;
    }


    .clsImage {
        vertical-align: bottom;
    }

    .clslabel {
        display: inline-block;
        margin-bottom: 5px;
        font-weight: normal;
    }

    .fieldset {
        width: auto;
        border: 1px solid #222;
        align: "center";
    }

    .clsdropdown {
        
        margin-bottom: 5px;
    }


</style>



 

    <div class="form form-horizontal" role="form" align="center">
        <fieldset class="fieldset" align="center">
            <legend align="center" class="legend">
                <img src="Addons/Aspose.SiteFinity.FormBuilder.ToExcel/Uploads/Images/aspose_logo.gif" class="clsImage" /><label class="clslabel">Manage Form Fields</label></legend>


            <div>
                 
                  <label class="clslabel">Select Export Type </label>

                <br/>
                <asp:dropdownlist id="ExportTypeDropDown" class="clsdropdown" runat="server" >
                <asp:ListItem Text="Excel Workbook (*.xlsx)" Selected="True" Value="xlsx"></asp:ListItem>
                <asp:ListItem Text="Excel Binary Workbook (*.xlsb)" Value="xlsb"></asp:ListItem>
                <asp:ListItem Text="Excel 97-2003 Workbook (*.xls)" Value="xls"></asp:ListItem>
                <asp:ListItem Text="Text (Tab delimited) (*.txt)" Value="txt"></asp:ListItem>
                <asp:ListItem Text="CSV (Comma delimited) (*.csv)" Value="csv"></asp:ListItem>
                <asp:ListItem Text="OpenDocument Spreadsheet (*.ods)" Value="ods"></asp:ListItem>
                </asp:dropdownlist>
                <br />

				<div class="bottomPadding">
                <asp:button id="btnExport" cssclass="btn3" runat="server" visible="true" onclick="btnExport_OnClick" text="Export Data"></asp:button>
                <asp:button id="btnback" cssclass="btn3" runat="server" visible="true" onclick="btnback_OnClick" text="Back"></asp:button>
                </div>
            </div>

        </fieldset>
    </div>
 