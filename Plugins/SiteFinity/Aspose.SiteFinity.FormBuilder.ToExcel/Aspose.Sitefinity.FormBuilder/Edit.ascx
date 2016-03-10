<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="Aspose.Sitefinity.FormBuilder.AsposeFormBuilder" %>


<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">


<style type="text/css">
    .Success {
        color: #3c763d;
        background-color: #dff0d8;
        border-color: #d6e9c6;
        padding: 8px;
        margin-bottom: 20px;
        border: 1px solid transparent;
        border-radius: 4px;
    }

    .alertdanger {
        color: #a94442;
        background-color: #f2dede;
        border-color: #ebccd1;
        padding: 8px;
        margin-bottom: 20px;
        border: 1px solid transparent;
        border-radius: 4px;
    }

    .alertupdate {
        color: #31708f;
        background-color: #d9edf7;
        border-color: #bce8f1;
        padding: 8px;
        margin-bottom: 20px;
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

	

	.table>thead>tr>th
	{
		vertical-align: bottom;
		border-bottom: 0px solid #ddd;
	}
	
	.table>thead>tr>th, .table>tbody>tr>th, .table>tfoot>tr>th, .table>thead>tr>td, .table>tbody>tr>td, .table>tfoot>tr>td
	{
		padding: 4px;
		line-height: 1.42857143;
		vertical-align: top;
		border-top: 0px solid #ddd;
	}
    .fieldset {
            width: auto;
		border: 1px solid #222;
        align: "center";
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

     .clslabel 
     {
             display: inline-block;
             margin-bottom: 5px;
             font-weight: normal;
     }

    .form-horizontal .control-label1 {
        padding-top: 10px !important;
        text-align: right;
    }
</style>




  <div class="form form-horizontal" role="form" align="center">
        <fieldset class="fieldset">
            <legend align="center" class="legend">
                <img src="Addons/Aspose.SiteFinity.FormBuilder.ToExcel/Uploads/Images/aspose_logo.gif" style="vertical-align: bottom;" /><label class="clslabel">Manage Form Fields</label></legend>

            <div class="form-groupMessage">
                <div>
                    <asp:label id="lbl_Msg" runat="server" text=""></asp:label>
                </div>
            </div>

            <table class="table">
                <thead>
                    <tr>
                        <th>Field Name</th>
                        <th>Field Type</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Field Type : </td>
                        <td>
                            <asp:dropdownlist id="ddlFieldType" class="textboxclass" runat="server">
                                        <asp:ListItem Text="TextBox" Selected="True" Value="Text"></asp:ListItem>
                                        <asp:ListItem Text="Multiline TextBox" Value="MultiText"></asp:ListItem>
                                        <asp:ListItem Text="Title" Value="Title"></asp:ListItem>
                                        <asp:ListItem Text="Success Message" Value="Success"></asp:ListItem>
                                        <asp:ListItem Text="Radio Button" Value="Radio"></asp:ListItem>
                                        <asp:ListItem Text="CheckBox Button" Value="Check"></asp:ListItem>
                                        <asp:ListItem Text="DropDown List" Value="DropDown"></asp:ListItem>
                            </asp:dropdownlist>
                        </td>
                    </tr>

                    <tr>
                        <td>Field ID : </td>
                        <td>
                            <asp:textbox id="txtFieldId" class="input" runat="server" tooltip="(Seprate Multiple Ids with ';' for Radio/Check)"></asp:textbox>
                        </td>
                    </tr>


                    <tr>
                        <td>Field Label Text :</td>
                        <td>
                            <asp:textbox id="txtFieldLableText" class="input" runat="server"></asp:textbox>
                        </td>
                    </tr>

                    <tr>
                        <td>Field Values : </td>
                        <td>
                            <asp:textbox id="txtFieldValues" cssclass="input" runat="server" tooltip="(Seprate Multiple Values with ';' for Radio/Check/Dropdown)"></asp:textbox>
                        </td>
                    </tr>

                    <tr>
                        <td>Display on Form : </td>
                        <td>
                            <asp:checkbox id="chkIsDisplay" runat="server" text="Display on Form" checked="true" />
                        </td>
                    </tr>

                    <tr>
                        <td>Sort # : </td>
                        <td>
                            <asp:textbox id="txtSortId" runat="server" class="input"></asp:textbox>
                        </td>
                    </tr>


                    <tr>
                        <td>Actions : </td>
                        <td>
                            <asp:button id="ProcessButton" cssclass="btn3" runat="server" visible="true" onclick="ProcessButton_Click" text="Add"></asp:button>
                            <asp:button id="ClearFormButton" cssclass="btn3" runat="server" visible="true" onclick="ClearFormButton_Click" text="Clear"></asp:button>
                            <asp:button id="btnUpdate" cssclass="btn3" runat="server" visible="true" onclick="btnUpdate_OnClick" text="Update"></asp:button>
                            <asp:button id="btnBack" cssclass="btn3" runat="server" visible="true" onclick="btnBack_OnClick" text="Back"></asp:button>
                        </td>
                    </tr>


                </tbody>
            </table>

            <div>
                <asp:gridview id="GridView1" class="table table-striped table-bordered table-hover datatable table-responsive" runat="server" autogeneratecolumns="false" showheader="true" onrowcommand="GridView1_RowCommand" onrowdeleting="PendingRecordsGridview_RowDeleting" onpageindexchanging="GridView1_RowCommand_OnPageIndexChanging" datakeynames="Field ID" allowsorting="True" allowpaging="true" pagesize="10" emptydatatext="There is no record found.">
                                <Columns>

                                    <asp:BoundField DataField="Sort ID" HeaderText="Sort Id" ItemStyle-HorizontalAlign="Center"
                                        ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="Field Type" HeaderText="Field Type" ItemStyle-HorizontalAlign="Left"
                                        ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Left" HeaderStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="Field ID" HeaderText="Field ID" ItemStyle-HorizontalAlign="Left"
                                        ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Left" HeaderStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="Field Label Text" HeaderText="Field Label Text" ItemStyle-HorizontalAlign="Left"
                                        ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Left" HeaderStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="Field Values" HeaderText="Field Values" ItemStyle-HorizontalAlign="Left"
                                        ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Left" HeaderStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="Is Display" HeaderText="Is Display" ItemStyle-HorizontalAlign="Left"
                                        ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Left" HeaderStyle-VerticalAlign="Middle" />
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                        HeaderText="Action" Visible="true" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEditCommand" runat="server" Text="<i class='fa fa-edit'></i> Edit" Style="border: 0px solid #FFF; padding: 1px 5px;"
                                                CssClass="btn btn-xs btn-success" ToolTip="Click here to edit record" CausesValidation="false"
                                                CommandArgument='<%# Eval("Field ID") %>' CommandName="EditSetupValue">  
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="lnkDeleteCommand" runat="server" Text="<i class='fa fa-remove'></i>Delete</a>" Style="border: 0px solid #FFF; padding: 1px 5px;"
                                                CssClass="btn btn-xs btn-danger" ToolTip="Click here to delete record" CausesValidation="false"
                                                CommandArgument='<%# Container.DataItemIndex%>' CommandName="Delete">  
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:gridview>
            </div>
        </fieldset>
    </div>

<script>



    $(document).ready(function () {

        $("tr:even").css("background-color", "#f5f5f5");
        $("tr:odd").css("background-color", "#fff");
        $("td").addClass('setColor');
        $("tr").addClass('setColor');

    });


</script>