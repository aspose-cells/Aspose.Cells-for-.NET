<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResizeGridWebUsingResizeMethod.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.WorkingWithGridWebClientSideScript.ResizeGridWebUsingResizeMethod" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        .fullheight {
            display: inline-block;
            min-height: 80%;
            height: 90%;
            padding: 0;
            position: relative;
            margin-right: -0.3em;
            vertical-align: top;
        }

        html, body, form {
            background: #b6b7bc;
            font-size: .80em;
            font-family: "Helvetica Neue", "Lucida Grande", "Segoe UI", Arial, Helvetica, Verdana, sans-serif;
            margin: 0px;
            padding: 0px;
            color: #000000;
            min-height: 99%;
            height: 100%;
            overflow: visible;
        }
    </style>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function doResizing() {
            //alert("I'm done resizing for the moment");
            $("#GridWeb1")[0].resize();
        };
        var resizeTimer;
        $(window).resize(function () {
            clearTimeout(resizeTimer);
            resizeTimer = setTimeout(doResizing, 100);
        });
    </script>
    <title>Using GridWeb’s resize method</title> 
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%; height: 100%; overflow: visible;">
            <span id="gridwebpanel" class="fullheight">
                <acw:GridWeb ID="GridWeb1" runat="server" Width="100%" Height="100%" ShowLoading="true" XhtmlMode="true"
                    PresetStyle="Standard" EnableAJAX="true">
                </acw:GridWeb>
            </span>
        </div>
    </form> 
</body>
</html>
