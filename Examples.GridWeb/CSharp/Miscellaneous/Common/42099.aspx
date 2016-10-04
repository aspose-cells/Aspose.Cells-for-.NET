<%@ Page Language="C#" AutoEventWireup="true" Debug="true" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="Aspose.Cells.GridWeb" %>
<%@ Import Namespace="Aspose.Cells.GridWeb.Data" %>
<%@ Register TagPrefix="agw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<html>
<script runat="server">
    private void Page_Load(object Sender, EventArgs e)
    {
        if (!Page.IsPostBack && !activities.IsPostBack)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            CustomCommandButton ccb_button = new CustomCommandButton();
            ccb_button.Width = 20;
            ccb_button.ImageUrl = "CBT.gif";
            ccb_button.CommandType = CustomCommandButtonType.CommandButton;
            ccb_button.Command = "CommandTest";
            ccb_button.ToolTip = "click me!";
            activities.CustomCommandButtons.Add(ccb_button);
           // activities.WebWorksheets.Clear();
            activities.ShowCommandBarAtTop = true;
            WebWorksheet wws = activities.WebWorksheets[activities.WebWorksheets.Add()];

            WebCells cells = this.activities.WebWorksheets[0].Cells;

            cells[1, 1].PutValue("Test value");


            Aspose.Cells.GridWeb.TableItemStyle style = cells[1, 1].GetStyle();

            style.IndentLevel = 1;

            cells[1, 1].SetStyle(style);
           // wws.Cells.Clear();
        }
    }

    public void CustomCommands(object sender, String strCommand)
    {
        errors.Text = string.Format("Event was received! {0} {1}", DateTime.Now, strCommand);
    }

</script>

<body bgcolor="ivory" style="font-family:arial;font-size:x-small">
<form id="Form1" runat="server">

<agw:gridweb ID="activities" runat="server" editmode="false" OnCustomCommand="CustomCommands" />
<p>
<asp:label runat="server" ID="errors" style="color:Red" />
    <asp:Button ID="Button1" runat="server" Text="Button" />
</p>

</form>
</body>
</html>
