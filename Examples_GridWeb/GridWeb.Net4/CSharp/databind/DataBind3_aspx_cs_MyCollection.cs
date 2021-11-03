//====================================================================
// This file is generated as part of Web project conversion.
// The extra class 'MyCollection' in the code behind file in 'databind\DataBind3.aspx.cs' is moved to this file.
//====================================================================


using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Aspose.Cells.GridWeb.Data;


namespace Aspose.Cells.GridWeb.DemosCS.DataBind
 {


	public class MyCollection: CollectionBase
	{
		// This Item property is used by GridWeb control to determine the collection's type.
		public MyCustomRecord this[int index]
		{
			get { return (MyCustomRecord)this.List[index]; }
		}
	}

}