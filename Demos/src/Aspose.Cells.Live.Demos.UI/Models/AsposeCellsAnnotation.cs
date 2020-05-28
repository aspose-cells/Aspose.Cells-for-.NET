using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Cells;
using File = System.IO.File;

namespace Aspose.Cells.Live.Demos.UI.Models
{
	///<Summary>
	/// AsposeCellsAnnotation class to parse excel file
	///</Summary>
	public class AsposeCellsAnnotation : CellsBase
	{
		///<Summary>
		/// Remove method to remove annotations from Excel File
		///</Summary>
		
		public Response Remove(DocumentInfo[] docs)
		{

			if (docs == null)
				return PasswordProtectedResponse;
			if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
				return MaximumFileLimitsResponse;

			SetDefaultOptions(docs, "");
			Opts.AppName = "AnnotationApp";
			Opts.MethodName = "Remove";
			Opts.ZipFileName = docs.Length > 1 ? "Removed Annotations" : Path.GetFileNameWithoutExtension(docs[0].FileName);
			Opts.CreateZip = true;

			var fileName = Path.GetFileName(docs[0].FileName);
			var folderName = docs[0].FolderName;

			return  Remove(fileName, folderName);
		}

		///<Summary>
		/// Remove method to remove annotation from excel file
		///</Summary>
		public Response Remove(string fileName, string folderName)
		{
			Opts.AppName = "AnnotationApp";
			Opts.MethodName = MethodBase.GetCurrentMethod().Name;
			Opts.FolderName = folderName;
			Opts.FileName = fileName;
			Opts.CreateZip = true;
			Opts.OutputType = Path.GetExtension(fileName);
			Opts.ResultFileName = Path.GetFileNameWithoutExtension(fileName) + " Removed Annotations";

			return  Process((inFilePath, outPath, zipOutFolder) => { RemoveAnnotationFromExcelFile(outPath, zipOutFolder); });
		}
		private void RemoveAnnotationFromExcelFile(string outPath, string zipOutFolder)
		{
			var wb = new Workbook(Opts.WorkingFileName);

			var sb = new StringBuilder();

			foreach (var ws in wb.Worksheets)
			{
				foreach (var cm in ws.Comments)
				{
					var cellName = CellsHelper.CellIndexToName(cm.Row, cm.Column);

					var str = $"Sheet Name: \"{ws.Name}\", Cell Name: {cellName}, Comment Note: \r\n\"{cm.Note}\"";

					sb.AppendLine(str);
					sb.AppendLine();
				}
			}

			File.WriteAllText(zipOutFolder + "\\comments.txt", sb.ToString());


			foreach (var ws in wb.Worksheets)
			{
				ws.Comments.Clear();
			}

			wb.Save(outPath);
		}
	}
}
