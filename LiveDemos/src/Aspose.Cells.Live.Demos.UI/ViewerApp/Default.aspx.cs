using Aspose.Cells.Live.Demos.UI.Config;
using System;
using System.Web;
using System.Web.UI;

namespace Aspose.Cells.Live.Demos.UI.ViewerApp
{
	public partial class Default : BasePage
	{
		public string fileName = "";
		public string downloadFileName = "";
		public string productName = "";
		public string fileFormat = "";
		public string folderName = "";
		public string callbackURL = "";
        public string apiUrl = "";

        protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				fileName = Get("filename");

				if (fileName != string.Empty)
					downloadFileName = HttpUtility.UrlEncode(fileName);                

				
				folderName = Get("foldername");
				callbackURL = Get("callbackURL");

                apiUrl = Configuration.AsposeCellsLiveDemosPath;

                Page.Title = Resources["cellsViewerPageTitle"];
				Page.MetaDescription = Resources["cellsViewerMetaDescription"];
			}
		}

		private string Get(string key)
		{
			return Page.RouteData.Values[key]?.ToString() ?? Request.QueryString[key];
		}
	}
}
