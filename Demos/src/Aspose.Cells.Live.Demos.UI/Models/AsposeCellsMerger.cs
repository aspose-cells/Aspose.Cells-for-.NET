using System.Threading.Tasks;
using System.Web.Mvc;

namespace Aspose.Cells.Live.Demos.UI.Models
{
	/// <summary>
	///
	/// </summary>
	public class AsposeCellsMerger : CellsBase
	{
		///<Summary>
		/// Merge method to call merger controller based on product name
		///</Summary>

		public Response Merge(DocumentInfo[] docs)
		{
			
			if (docs == null)
				return PasswordProtectedResponse;
			if (docs.Length <= 1 || docs.Length > MaximumUploadFiles)
				return MaximumFileLimitsResponse;

			SetDefaultOptions(docs, "");
			Opts.AppName = "MergerApp";
			Opts.MethodName = "Merge";
			Opts.ResultFileName = $"Merged document{Opts.OutputType}";
			Opts.CreateZip = false;
			Opts.ZipFileName = "Merged document";

			return  Process((inFilePath, outPath, zipOutFolder) =>
			{
				var doc = docs[0];
				for (var i = 1; i < docs.Length; i++)
					doc.Workbook.Combine(docs[i].Workbook);

				doc.Workbook.Save(outPath);
			});
		}
	}
}
