using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Cells;

namespace Aspose.Cells.Live.Demos.UI.Models
{
	/// <summary>
	///
	/// </summary>
	public class AsposeCellsProtect : CellsBase
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="password"></param>
		/// <returns></returns>
		
		public Response Protect( DocumentInfo[] files, string password)
		{
			
			if (files.Length == 0 || files.Length > MaximumUploadFiles)
				return MaximumFileLimitsResponse;

			SetDefaultOptions(files, "");
			Opts.AppName = "UnlockApp";
			Opts.MethodName = "Unlock";
			Opts.ZipFileName = "Unlocked documents";

			var fileName = Path.GetFileName(files[0].FileName);
			var folderName = files[0].FolderName;

			var outputType = Path.GetExtension(fileName).ToLower();

			return  ProtectCells(fileName, folderName, password, outputType);
		}

		private Response ProtectCells(string fileName, string folderName, string password, string outputType)
		{
			License.SetAsposeCellsLicense();
			return  Process(GetType().Name, fileName, folderName, outputType, false, false,
				 "ProtectCells",
				(inFilePath, outPath, zipOutFolder) =>
				{
					var workbook = new Workbook(inFilePath);
					workbook.Settings.Password = password;
					workbook.Save(outPath);
				});
		}
	}
}
