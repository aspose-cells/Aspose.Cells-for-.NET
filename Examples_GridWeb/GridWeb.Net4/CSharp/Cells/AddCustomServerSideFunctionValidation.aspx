<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCustomServerSideFunctionValidation.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.AddCustomServerSideFunctionValidation" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="/Scripts/jquery-ui.css" />
    <script src="/Scripts/jquery-2.1.1.js"></script>
    <script src="/Scripts/jquery-ui.js"></script>
    <script type="text/javascript">
        var lastselectvalue = null;
        var localvalue = {};

        function myCellSelect(cell) {

            //Get the selected cell.
            var value = this.getCellValueByCell(cell);

            //Get the value to store.
            lastselectvalue = value;
            var key = this.acttab + "_" + this.getCellRow(cell) + "_" + this.getCellColumn(cell);

            //Store the respective cell's value.
            localvalue[key] = lastselectvalue;
            console.log("OnCellSelect: value:" + value + " row:" + this.getCellRow(cell) + ",col:" + this.getCellColumn(cell));
            console.log("Last selected value:" + lastselectvalue);
        }

        function ValidationErrorClientFunctionCallback(cell, msg) {

            //Get the error message string.
            var errmsg1 = getattr(cell, "errmsg");

            //Show the error message in the client dialog.
            alert(errmsg1);

            //Showing an alert message where "this" refers to GridWeb
            alert(this.id + "----> " + msg + " Previous value will be restored.");
            $("#errmsg").text(msg);
            console.log("Selected cell:" + " row:" + this.getCellRow(cell) + ",col:" + this.getCellColumn(cell));

            //Get the GridWeb.
            var who = this;

            //Restore to valid value/previous value. 
            who.setValid(cell);
            var key = this.acttab + "_" + this.getCellRow(cell) + "_" + this.getCellColumn(cell);
            lastselectvalue = localvalue[key];
            setInnerText(cell.children[0], lastselectvalue);
        }
    </script>

    <title>Add Custom Server-side Function Validation</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <b>GridWeb Version:&nbsp</b>
                <asp:Label ID="lblVersion" runat="server" Text="Label"></asp:Label>
                <br />

                <acw:GridWeb ID="GridWeb1" runat="server" OnCellSelectedClientFunction="myCellSelect" Width="44%" Height="384px" ShowLoading="true" XhtmlMode="true"
                    PresetStyle="Standard" EnableAJAX="true" EnableAsync="true" RenderHiddenRow="true" MaxColumn="15" MaxRow="21">
                </acw:GridWeb>

            </div>
        </div>

        <span id="errmsg" style="color: red;"></span>
    </form>
</body>
</html>
