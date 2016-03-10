<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Aspose.Sitefinity.FormBuilder.View" %>
 
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
 
<style type="text/css">
    .Success {
        color: #3c763d;
        background-color: #dff0d8;
        border-color: #d6e9c6;
        padding: 8px;
        border: 1px solid transparent;
        border-radius: 4px;
    }

    .panel-primary {
        border-color: none;
    }

    .imagecls {
        width: 18px;
    }

    .alertdanger {
        color: #a94442;
        background-color: #f2dede;
        border-color: #ebccd1;
        padding: 8px;
        border: 1px solid transparent;
        border-radius: 4px;
    }

    .alertupdate {
        color: #31708f;
        background-color: #d9edf7;
        border-color: #bce8f1;
        padding: 8px;
        border: 1px solid transparent;
        border-radius: 4px;
    }


    .table {
        width: auto;
        margin-bottom: 20px;
    }

        .table td,
        .table th {
            border-collapse: collapse;
            width: auto;
            font-size: 12px !important;
            text-align: left;
            background-color: white;
        }


            .table th + th {
                text-align: left;
                background-color: white;
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

    .divleft {
        float: left;
    }

    .ajust {
        padding-top: 10px;
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


    .title {
        font-size: 12px;
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

    .form-horizontal .form-group {
        margin-right: 0px;
        margin-left: 10px;
    }

    .form-group {
        margin-bottom: 0px;
    }

    .form-groupMessage {
        height: 41px;
        margin-left: 12px;
        padding-top: 10px;
    }

    .myinput {
        width: 100%;
    }


    .table > thead > tr > th {
        vertical-align: bottom;
        border-bottom: 0px solid #ddd;
    }

    .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
        padding: 4px;
        line-height: 1.42857143;
        vertical-align: top;
        border-top: 0px solid #ddd;
    }

    .fieldset {
        width: auto;
        border: 1px solid #222;
        align: "center";
        border: 1px solid black;
        width: 98%;
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

    .textboxclass {
        width: 100% !important;
        font-family: inherit;
        font-size: inherit;
        line-height: inherit;
    }

    .clslabel {
        display: inline-block;
        margin-bottom: 5px;
        font-weight: normal;
    }

    .form-horizontal .control-label1 {
        padding-top: 10px !important;
        text-align: right;
    }
</style>
 
<div class="ajust" role="form" align="center">
    <fieldset class="fieldset">
        <legend align="center" class="legend">
            <img src="Addons/Aspose.SiteFinity.FormBuilder.ToExcel/Uploads/Images/aspose_logo.gif" />
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </legend>
        <div class="form-group">
            <table class="table">
                <thead>
                    <tr>
                        <th>Field Name</th>
                        <th>Field Type</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Options : </td>
                        <td>
                            <asp:LinkButton ID="lnkbtnEdit" runat="server" Text="<img src='Addons/Aspose.SiteFinity.FormBuilder.ToExcel/Uploads/Images/editIcon.png' class='imagecls'/>Edit" OnClick="lnkbtnEdit_OnClick"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnExport" runat="server" Text="<img src='Addons/Aspose.SiteFinity.FormBuilder.ToExcel/Uploads/Images/exportIcon.png' class='imagecls' /> Export" OnClick="lnkbtnExport_OnClick"></asp:LinkButton>
                        </td>
                    </tr>

                    <asp:PlaceHolder runat="server" ID="myPlaceHolder"></asp:PlaceHolder>

                    <tr>
                        <td>Actions : </td>
                        <td>
                            <asp:Button ID="ProcessButton" CssClass="btn3" runat="server" Visible="true" OnClick="ProcessButton_Click" Text="Submit"></asp:Button>
                            <asp:Button ID="ClearFormButton" CssClass="btn3" runat="server" Visible="true" OnClick="ClearFormButton_Click" Text="Clear"></asp:Button>

                            <br />
                            <br />
                            <div style="clear: both;"></div>
                            <span id="success_msg" runat="server" visible="false" class="Success"></span>
                            <span id="info_msg" runat="server" visible="false" class="alertupdate"></span>
                            <span id="error_msg" runat="server" visible="false" class="alertdanger"></span>

                        </td>
                    </tr>
            </table>
        </div>
    </fieldset>
</div>
