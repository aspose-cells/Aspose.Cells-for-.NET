using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.Cells.Live.Demos.UI.Models
{
	///<Summary>
	/// License class to set apose products license
	///</Summary>
	public static class License
	{
		private static string _licenseFileName = "Aspose.Total.lic";


		///<Summary>
		/// SetAsposeCellsLicense method to Aspose.Words License
		///</Summary>
		public static void SetAsposeCellsLicense()
		{
			try
			{
				Aspose.Cells.License acLic = new Aspose.Cells.License();
				acLic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		
		
	}
}
