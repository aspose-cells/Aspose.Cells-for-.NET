using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.Worksheets
{
    public partial class ChangeDecimalSeparatorFromNumericKeypad : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !this.GridWeb1.IsPostBack)
            {
                //Change the numeric decimal separator to "^" char.
                GridWeb1.WorkSheets.NumberDecimalSeparator = '^';
            }
        }
    }
}