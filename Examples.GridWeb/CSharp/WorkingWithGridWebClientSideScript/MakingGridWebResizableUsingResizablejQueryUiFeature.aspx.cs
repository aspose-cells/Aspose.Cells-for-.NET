using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Cells.GridWeb.Examples.CSharp.WorkingWithGridWebClientSideScript
{
    public partial class MakingGridWebResizableUsingResizablejQueryUiFeature : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false && this.GridWeb1.IsPostBack == false)
            {
                string filePath = Server.MapPath("~/01_SourceDirectory/sampleResizableGridWeb.xlsx"); 

                GridWeb1.ImportExcelFile(filePath);
            }
        }
    }
}