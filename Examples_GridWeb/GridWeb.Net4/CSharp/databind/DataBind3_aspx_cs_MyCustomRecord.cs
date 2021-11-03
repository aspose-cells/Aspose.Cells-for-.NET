//====================================================================
// This file is generated as part of Web project conversion.
// The extra class 'MyCustomRecord' in the code behind file in 'databind\DataBind3.aspx.cs' is moved to this file.
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


	public class MyCustomRecord
	{
		private string stringfield1;
		private string stringfield2 = "ABC";
		private DateTime datefield1;
		private int intfield1;
		private double doublefield1;

		public string StringField1
		{
			get { return stringfield1;}
			set { stringfield1 = value;}
		}

		// a readonly field.
		public string ReadonlyField2
		{
			get { return stringfield2; }
		}

		public DateTime DateField1
		{
			get { return datefield1; }
			set { datefield1 = value; }
		}

		public int IntField1
		{
			get { return intfield1; }
			set { intfield1 = value; }
		}

		public double DoubleField1
		{
			get { return doublefield1; }
			set { doublefield1 = value; }
		}
	}

}