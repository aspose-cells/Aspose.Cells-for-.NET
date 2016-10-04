using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Aspose.Cells.GridWeb;
using Aspose.Cells.GridWeb.Data;
using System.Collections.Specialized;

public partial class demos_Common_HyperlinkDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if first visit this page clear GridWeb1 
        if (!IsPostBack&&!GridWeb1.IsPostBack)
        {
            InitData();
        }
    }

    private void InitData()
    {
        // Gets the web application's path.
        string path = Server.MapPath("~");

        // Upper level.
        path = path.Substring(0, path.LastIndexOf("\\"));
        string fileName = path + "\\File\\Hyperlink.xls";

        // Clears datasheets first.
        GridWeb1.WorkSheets.Clear();
        // Imports from a excel file.
        GridWeb1.ImportExcelFile(fileName);
        GridHyperlinkCollection  ghc=GridWeb1.WorkSheets[0].Hyperlinks;
        //Adds a text hyperlink that gos to Aspose site and opens in new window
        int i = ghc.Add("B1", "http://www.aspose.com");
        GridHyperlink linkOfText1 = ghc[i];
        linkOfText1.Target = "_blank";
        linkOfText1.TextToDisplay = "Aspose site";
        linkOfText1.ScreenTip = "Go to Aspose site and open in new window";

        ////Adds a text hyperlink that gos to Aspose site and opens in current window
        GridHyperlink linkOfText2 = ghc[ghc.Add("B2", "http://localhost:40056/grid/common/Pagination.aspx")];
        linkOfText2.TextToDisplay = "Paginatind sheet Demo";
        linkOfText2.Target = "_self";
        linkOfText2.ScreenTip = "Go to Aspose site and open in current window";

        //Adds a text hyperlink that gos to Aspose site and opens in top window
        GridHyperlink linkOfText3 =ghc[ghc.Add("B3","http://www.aspose.com/categories/.net-components/aspose.cells-for-.net/default.aspx")];
        linkOfText3.TextToDisplay = "Aspose.Cells.GridWeb Product";
        linkOfText3.Target = "_top";
        linkOfText3.ScreenTip = "Go to Aspose site and open in top window";

        //Adds a text hyperlink that gos to Aspose site and opens in parent window
        GridHyperlink linkOfText4 = ghc[ghc.Add("B4", "http://www.aspose.com/Community/Forums/258/ShowForum.aspx")];
        linkOfText4.TextToDisplay = "Aspose.Cells.GridWeb Forums";
        linkOfText4.Target = "_parent";
        linkOfText4.ScreenTip = "Go to Aspose site and open in parent window";

        //Adds a image hyperlink that gos to Aspose site and opens in current window
        GridHyperlink linkOfImage1 = ghc[ghc.Add("B6", "http://www.aspose.com")];
        linkOfImage1.ImageURL = "../../Images/Aspose.Banner.gif";
        linkOfImage1.Target = "_blank";
        linkOfImage1.ScreenTip = "Go to Aspose site and open in new window";

        //Adds a image hyperlink that gos to Aspose.Cells.GridWeb site and opens in new window
        GridHyperlink linkOfImage2 = ghc[ghc.Add("B7", "http://www.aspose.com/categories/.net-components/aspose.cells-for-.net/default.aspx")];
        linkOfImage2.ImageURL = "../../Images/Aspose.Grid.gif";
        linkOfImage1.Target = "_blank";
        linkOfImage2.ScreenTip = "Go to Aspose site and open in new window";
       

        //Adds a CellImage
        GridHyperlink image = ghc[ghc.Add("B8", "")];
        image.ImageURL = "../../Images/Aspose.Grid.gif";
        //image.ActionType = HyperlinkActionType.CellCommand;
        image.ScreenTip = "A simple CellImage.";
        GridWeb1.WorkSheets[0].Cells["A8"].PutValue("Creates a CellImage:");
        GridWeb1.WorkSheets[0].Cells.SetRowHeight(7,100);

        //Picture pi = GridWeb1.WebWorksheets[0].Pictures.AddPicture("B8");
        //pi.Image = "";

        GridCells cells = GridWeb1.WorkSheets[1].Cells;
        GridValidationCollection gvc = GridWeb1.WorkSheets[1].Validations;
        GridValidation validation=gvc.Add("B13");
        validation.ValidationType = GridValidationType.DropDownList;
        StringCollection value = new StringCollection();
        value.Add("1996");
        value.Add("1997");
        value.Add("1998");
        validation.ValueList = value;
        cells["B13"].PutValue("1996");

        //Adds a cell command hyperlink 
        GridHyperlink linkOfCellCommand1 =  ghc[ghc.Add("C13","")];
        linkOfCellCommand1.Command = "Year";
        linkOfCellCommand1.ScreenTip = "Summarizes Sales by Year";
        linkOfCellCommand1.ImageURL = "../../Images/button1.bmp";

        GridValidation validationB14 = gvc.Add("B14");
        validationB14.ValidationType = GridValidationType.DropDownList;
        validationB14.Formula1 = "1,2,3,4";
        cells["B14"].PutValue("1");

        //Adds a cell command hyperlink 
        GridHyperlink linkOfCellCommand2 = ghc[ghc.Add("C14", "")];
        linkOfCellCommand2.Command = "Quarter";
        linkOfCellCommand2.ScreenTip = "Summarizes Sales by Quater";
        linkOfCellCommand2.ImageURL = "../../Images/button2.bmp";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        InitData();
    }

    protected void GridWeb1_SaveCommand(object sender, EventArgs e)
    {
        // Generates a temporary file name.
        string filename = System.IO.Path.GetTempPath() + Session.SessionID + ".xls";

        // Saves to the file.
        this.GridWeb1.SaveToExcelFile(filename);

        // Sents the file to browser.
        Response.ContentType = "application/vnd.ms-excel";

        //Adds header.
        Response.AddHeader("content-disposition", "attachment; filename=book1.xls");

        // Writes file content to the response stream.
        Response.WriteFile(filename);

        // OK.
        Response.End();
    }

    protected void GridWeb1_CellCommand(object sender, Aspose.Cells.GridWeb.CellEventArgs e)
    {
        GridWeb1.ActiveSheetIndex = 1;
        GridCells cells = GridWeb1.WorkSheets[1].Cells;
        int sumOfOrder;
        double sumOfSales;
        //Handles summary of sales by year
        if (e.Argument.ToString() == "Year")
        {
            cells["B11"].PutValue("Totals for Year " + cells["B13"].Value);
            if (cells["B13"].Value.ToString() == "1996")
            {
                sumOfOrder = int.Parse(cells["D3"].Value.ToString()) + int.Parse(cells["D4"].Value.ToString());
                cells["D11"].PutValue(sumOfOrder);

                sumOfSales = double.Parse(cells["E3"].Value.ToString()) + double.Parse(cells["E4"].Value.ToString());
                cells["E11"].PutValue(sumOfSales);
            }
            else if (cells["B13"].Value.ToString() == "1997")
            {
                sumOfOrder = int.Parse(cells["D5"].Value.ToString()) + int.Parse(cells["D6"].Value.ToString())
                  + int.Parse(cells["D7"].Value.ToString()) + int.Parse(cells["D8"].Value.ToString());
                cells["D11"].PutValue(sumOfOrder);

                sumOfSales = double.Parse(cells["E5"].Value.ToString()) + double.Parse(cells["E6"].Value.ToString())
                  + double.Parse(cells["E7"].Value.ToString()) + double.Parse(cells["E8"].Value.ToString());
                cells["E11"].PutValue(sumOfSales);
            }
            else if (cells["B13"].Value.ToString() == "1998")
            {
                sumOfOrder = int.Parse(cells["D9"].Value.ToString()) + int.Parse(cells["D10"].Value.ToString());
                cells["D11"].PutValue(sumOfOrder);

                sumOfSales = double.Parse(cells["E9"].Value.ToString()) + double.Parse(cells["E10"].Value.ToString());
                cells["E11"].PutValue(sumOfSales);
            }
        }
        //Handles summary of sales by quarter
        else if (e.Argument.ToString() == "Quarter")
        {
            cells["B12"].PutValue("Totals for Quarter " + cells["B14"].Value);
            if (cells["B14"].Value.ToString() == "1")
            {
                sumOfOrder = int.Parse(cells["D5"].Value.ToString()) + int.Parse(cells["D9"].Value.ToString());
                cells["D12"].PutValue(sumOfOrder);

                sumOfSales = double.Parse(cells["E5"].Value.ToString()) + double.Parse(cells["E9"].Value.ToString());
                cells["E12"].PutValue(sumOfSales);
            }
            else if (cells["B14"].Value.ToString() == "2")
            {
                sumOfOrder = int.Parse(cells["D6"].Value.ToString()) + int.Parse(cells["D10"].Value.ToString());
                cells["D12"].PutValue(sumOfOrder);

                sumOfSales = double.Parse(cells["E6"].Value.ToString()) + double.Parse(cells["E10"].Value.ToString());
                cells["E12"].PutValue(sumOfSales);
            }
            else if (cells["B14"].Value.ToString() == "3")
            {
                sumOfOrder = int.Parse(cells["D3"].Value.ToString()) + int.Parse(cells["D7"].Value.ToString());
                cells["D12"].PutValue(sumOfOrder);

                sumOfSales = double.Parse(cells["E3"].Value.ToString()) + double.Parse(cells["E7"].Value.ToString());
                cells["E12"].PutValue(sumOfSales);
            }
            else if (cells["B14"].Value.ToString() == "4")
            {
                sumOfOrder = int.Parse(cells["D4"].Value.ToString()) + int.Parse(cells["D8"].Value.ToString());
                cells["D12"].PutValue(sumOfOrder);

                sumOfSales = double.Parse(cells["E4"].Value.ToString()) + double.Parse(cells["E8"].Value.ToString());
                cells["E12"].PutValue(sumOfSales);
            }
        }
    }
}
