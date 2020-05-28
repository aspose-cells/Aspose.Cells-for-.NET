using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Cells.Live.Demos.UI.Models;

namespace Aspose.Cells.Live.Demos.UI.Models
{
	///<Summary>
	/// AsposeCellsSearch class to perform search on excel files
	///</Summary>
	public class AsposeCellsSearch : CellsBase
	{
		/// <summary>
		/// Search method call search controller based on product name
		/// </summary>

		public Response Search(DocumentInfo[] docs,   string query)
		{
			
			if (docs == null)
				return PasswordProtectedResponse;
			if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
				return MaximumFileLimitsResponse;

			SetDefaultOptions(docs, "");
			Opts.AppName = "Search";
			Opts.MethodName = "Search";
			Opts.OutputType = ".xlsx";
			Opts.ResultFileName = "Search Results";
			Opts.CreateZip = false;
			

			var fileName = Path.GetFileName(docs[0].FileName);
			var folderName = docs[0].FolderName;

			return  Search(fileName, folderName, query);
		}

		bool m_FoundNothing = true;

		///<Summary>
		/// SearchQuery
		///</Summary>
		public void SearchQuery(string fileName, string folderName, string query, string outPath)
		{
			var fn = Config.Configuration.WorkingDirectory + folderName + "/" + fileName;

			// Load the input Excel file.
			Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook(fn);

			// Specify the find options.
			Aspose.Cells.FindOptions opts = new Aspose.Cells.FindOptions();
			opts.LookAtType = Aspose.Cells.LookAtType.Contains;
			opts.LookInType = Aspose.Cells.LookInType.Values;

			string findText = query;
			System.Text.StringBuilder found = new System.Text.StringBuilder();

			found.AppendLine("Searched Text: " + query);
			found.AppendLine("===========================================");
			found.AppendLine();

			//Check if found nothing
			this.m_FoundNothing = true;

			Aspose.Cells.Cell cell = null;

			for (int i = 0; i < wb.Worksheets.Count; i++)
			{
				Aspose.Cells.Worksheet ws = wb.Worksheets[i];

				found.AppendLine("Sheet Name: " + ws.Name);
				found.AppendLine();

				do
				{
					cell = ws.Cells.Find(findText, cell);

					if (cell == null)
						break;

					this.m_FoundNothing = false;
					found.AppendLine("Cell Name: " + cell.Name);
					found.AppendLine("Cell Value: " + cell.StringValue);
					found.AppendLine();
				} while (true);

				found.AppendLine("===========================================");
				found.AppendLine();
			}

			if (this.m_FoundNothing)
			{
				string dn = System.IO.Path.GetDirectoryName(outPath);
				System.IO.Directory.Delete(dn);
				return;
			}

			string strFound = found.ToString();
			System.IO.File.WriteAllText(outPath, strFound);
		}

		///<Summary>
		/// Search method to perform search
		///</Summary>
		public Response Search(string fileName, string folderName, string query)
		{
			Aspose.Cells.Live.Demos.UI.Models.License.SetAsposeCellsLicense();

			Response taskResp = null;

			taskResp = Process(this.GetType().Name, "SearchResults", folderName, ".txt", false, false,
				 "Search",
				(inFilePath, outPath, zipOutFolder) => { SearchQuery(fileName, folderName, query, outPath); });

			if (this.m_FoundNothing)
			{
				taskResp.FileProcessingErrorCode = FileProcessingErrorCode.NoSearchResults;
			}

			return  taskResp;
		}
	}
}
