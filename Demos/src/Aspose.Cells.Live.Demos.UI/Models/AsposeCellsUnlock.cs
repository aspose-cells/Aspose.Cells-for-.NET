using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Cells.Live.Demos.UI.Models;
using Aspose.Cells;
using License = Aspose.Cells.Live.Demos.UI.Models.License;
using LoadOptions = Aspose.Cells.LoadOptions;

namespace Aspose.Cells.Live.Demos.UI.Models
{
	/// <summary>
	/// AsposeCellsUnlock
	/// </summary>
	public class AsposeCellsUnlock : CellsBase
	{
		/// <summary>
		/// Unlock
		/// </summary>
		/// <param name="passw"></param>
		/// <returns></returns>
		
		public Response Unlock(DocumentInfo[] files,  string passw)
		{
			
			if (files == null)
				return new Response
				{
					Status = "Invalid password.",
					StatusCode = 500
				};
			if (files.Length == 0 || files.Length > MaximumUploadFiles)
				return MaximumFileLimitsResponse;

			SetDefaultOptions(files, "");
			Opts.AppName = "UnlockApp";
			Opts.MethodName = "Unlock";
			Opts.ZipFileName = "Unlocked files";
			

			var fileName = Path.GetFileName(files[0].FileName);
			var folderName = files[0].FolderName;
			var outputType = Path.GetExtension(fileName).ToLower();

			return  UnlockCells(fileName, folderName, passw, outputType);
		}

		private Response UnlockCells(string fileName, string folderName, string password, string outputType)
		{
			License.SetAsposeCellsLicense();
			return  Process(GetType().Name, fileName, folderName, outputType, false, false,
				 "UnlockCells",
				(inFilePath, outPath, zipOutFolder) =>
				{
					var workbook = new Workbook(inFilePath, new LoadOptions {Password = password});
					workbook.Settings.Password = "";
					workbook.Save(outPath);
				});
		}
	}
}
