<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakingGridWebResizableUsingResizablejQueryUiFeature.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.WorkingWithGridWebClientSideScript.MakingGridWebResizableUsingResizablejQueryUiFeature" %>

<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#resizable").resizable(
                 {
                     resize: function () {
                         $("#GridWeb1").height($("#resizable").height());
                         $("#GridWeb1").width($("#resizable").width());
                         $("#GridWeb1")[0].resize();
                     }
                 }
              );
        });
    </script>
    <title>Making GridWeb resizable using resizable jquery ui feature</title> 
</head>
<body>
    <form id="form1" runat="server">
        <div id="resizable" class="ui-widget-content">
            <acw:GridWeb ID="GridWeb1" runat="server" XhtmlMode="True" Height="400px" Width="100%">
            </acw:GridWeb>
        </div>
    </form> 
</body>
</html>
