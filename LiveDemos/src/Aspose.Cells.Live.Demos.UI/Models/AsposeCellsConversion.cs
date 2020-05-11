using System;
using System.IO;
using System.Web.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using Aspose.Cells;
using Aspose.Cells.Live.Demos.UI.Controllers;

namespace Aspose.Cells.Live.Demos.UI.Models
{
	///<Summary>
	/// AsposeCellsConversion class to convert words files to different formats
	///</Summary>
	public class AsposeCellsConversion : CellsBase
	{ 

    public Response ConvertFile(DocumentInfo[] docs, string outputType)
		{			
			if (docs == null)
				return PasswordProtectedResponse;
			if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
				return MaximumFileLimitsResponse;
			SetDefaultOptions(docs, outputType);
			Opts.AppName = "Conversion";
			Opts.MethodName = "Convert";
			Opts.ZipFileName = docs.Length > 1 ? "Converted documents" : Path.GetFileNameWithoutExtension(docs[0].FileName);
			

			var saveOpt = GetSaveOptions(outputType.Trim().ToLower());
			return  Process((inFilePath, outPath, zipOutFolder) =>
			{
				var tasks = docs.Select(doc =>
					Task.Factory.StartNew(() => SaveDocument(doc, outPath, zipOutFolder, saveOpt))).ToArray();
				Task.WaitAll(tasks);
			});

			
		}

		
  }
}
