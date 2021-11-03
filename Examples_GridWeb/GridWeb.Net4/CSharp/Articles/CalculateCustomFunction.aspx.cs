using Aspose.Cells.GridWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Articles
{
    public partial class CalculateCustomFunction : System.Web.UI.Page
    {
        // ExStart:CalculateCustomFunction
        private class GridWebCustomCalculationEngine : GridAbstractCalculationEngine
        {
            public override void Calculate(GridCalculationData data)
            {
                // Calculate MYTESTFUNC() with your own logic. i.e Multiply MYTESTFUNC() parameter with 2 so MYTESTFUNC(3.0) = 6
                if ("MYTESTFUNC".Equals(data.FunctionName.ToUpper()))
                {
                    data.CalculatedValue = (decimal)(2.0 * (double)data.GetParamValue(0));
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false && GridWeb1.IsPostBack == false)
            {
                // Assign your own custom calculation engine to GridWeb
                GridWeb1.CustomCalculationEngine = new GridWebCustomCalculationEngine();

                // Access the active worksheet and add your custom function in cell B3
                GridWorksheet sheet = GridWeb1.ActiveSheet;
                GridCell cell = sheet.Cells["B3"];
                cell.Formula = "=MYTESTFUNC(9.0)";

                // Calculate the GridWeb formula
                GridWeb1.CalculateFormula();
            }
        }
        // ExEnd:CalculateCustomFunction
    }
}