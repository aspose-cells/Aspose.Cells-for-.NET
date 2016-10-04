<%@ Page Language="C#" AutoEventWireup="true" Debug="true" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="Aspose.Cells.GridWeb" %>
<%@ Import Namespace="Aspose.Cells.GridWeb.Data" %>
<%@ Register TagPrefix="acw" Namespace="Aspose.Cells.GridWeb" Assembly="Aspose.Cells.GridWeb" %>
<html>
<script runat="server">
    private void Page_Load(object Sender, EventArgs e)
    {
        if (!Page.IsPostBack && !activitiesborder.IsPostBack)
        {
            string path = Server.MapPath("~");

            // Upper level.
            path = path.Substring(0, path.LastIndexOf("\\"));
            string fileName = path + "\\File\\List.xls";

            // Imports from a excel file.
            activitiesborder.ImportExcelFile(fileName);
         
           
        }
    }





 

    protected void setborders(object sender, EventArgs e)
    {
       
        
           
           GridCells wc = activitiesborder.WorkSheets[0].Cells;
         //  wc.SetBorders()
           int firstrow = int.Parse(TextBox3.Text);
           int firstcol = int.Parse(TextBox4.Text);
           int rows = int.Parse(TextBox5.Text);
           int cols = int.Parse(TextBox6.Text);
           WebBorderStyle border = new WebBorderStyle();
           Color bcolor = Color.FromName(bordercolorname.Text);
           BorderStyle bs = (BorderStyle)Enum.Parse(typeof(BorderStyle), borderlinetype.Text);
           border.BorderColor = bcolor;
           border.BorderStyle = bs;
           SetBorderPosition position = (SetBorderPosition)Enum.Parse(typeof(SetBorderPosition), borderposition.Text);
           
           wc.SetBorders(firstrow, firstcol, rows, cols, position, border);
       
      

    }

    

    
</script>

<body bgcolor="ivory" style="font-family:arial;font-size:x-small">
<script>
  
</script>
<form id="Form1" runat="server" title="Set Borders">



<p>
    <asp:Label ID="Label1" runat="server" Text="fristrow"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server"  >1</asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="firstcol"></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server">2</asp:TextBox>
    <asp:Label ID="Label3" runat="server" Text="rows"></asp:Label>
    <asp:TextBox ID="TextBox5" runat="server">4</asp:TextBox>
    <asp:Label ID="Label4" runat="server" Text="cols"></asp:Label>
    <asp:TextBox ID="TextBox6" runat="server">5</asp:TextBox>
  
</p>
<p>
  
    <asp:DropDownList ID="borderposition" runat="server">
        <asp:ListItem>Top</asp:ListItem>
        <asp:ListItem>Bottom</asp:ListItem>
        <asp:ListItem>Left</asp:ListItem>
        <asp:ListItem>Right</asp:ListItem>
        <asp:ListItem>VerticalMiddle</asp:ListItem>
        <asp:ListItem>HorizontalMiddle</asp:ListItem>
        <asp:ListItem>Outline</asp:ListItem>
        <asp:ListItem>Cross</asp:ListItem>
        <asp:ListItem>None</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="bordercolorname" runat="server">
        <asp:ListItem>Red</asp:ListItem>
        <asp:ListItem>Green</asp:ListItem>
        <asp:ListItem>Yellow</asp:ListItem>
        <asp:ListItem>Blue</asp:ListItem>
        <asp:ListItem>Coral</asp:ListItem>
        <asp:ListItem>Peru</asp:ListItem>
        <asp:ListItem>Violet</asp:ListItem>
    </asp:DropDownList>
 
    <asp:DropDownList ID="borderlinetype" runat="server">
        <asp:ListItem>Dotted</asp:ListItem>
        <asp:ListItem>Dashed</asp:ListItem>
        <asp:ListItem>Solid</asp:ListItem>
        <asp:ListItem>Double</asp:ListItem>
        
    </asp:DropDownList>
  
  <asp:button ID="Button1" runat="server" text="setborders" 
        onclick="setborders" />
  
</p>
 <acw:gridweb ID="activitiesborder" runat="server"   EnableAJAX="True" 
    Height="401px" Width="1073px" 
       />
</form>
</body>
</html>
