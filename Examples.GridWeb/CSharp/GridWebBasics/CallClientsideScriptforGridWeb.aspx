<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallClientsideScriptforGridWeb.aspx.cs" Inherits="Aspose.Cells.GridWeb.Examples.CSharp.GridWebBasics.CallClientsideScriptforGridWeb" %>
<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test GridWeb</title>
    <script type="text/javascript" >
        function MyOnPageChange(index) {
            console.log("current page is:" + index);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <b>GridWeb Version:&nbsp </b>
                <asp:Label ID="lblVersion" runat="server" Text="Label"></asp:Label>
                <br />
            </div>
            <acw:GridWeb ID="gridweb"
            runat="server" XhtmlMode="True"
            Height="504px" Width="1119px" EnablePaging="true"
            OnPageChangeClientFunction ="MyOnPageChange">
            </acw:GridWeb>
        </div>
    </form>
</body>
</html>
