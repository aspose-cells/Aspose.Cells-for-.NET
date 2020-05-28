using System.Web.Mvc;
using System.Threading.Tasks;
using Aspose.Cells.Drawing;
using Aspose.Cells;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Aspose.Cells.Live.Demos.UI.Models
{
	/// <summary>
	///
	/// </summary>
	public class AsposeCellsWatermark : CellsBase
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="watermarkText"></param>
		/// <param name="watermarkColor"></param>
		/// <returns></returns>

		public Response AddTextWatermark(DocumentInfo[] workbooks, string watermarkText, string watermarkColor)
		{
			
			if (workbooks == null)
				return PasswordProtectedResponse;
			if (workbooks.Length == 0 || workbooks.Length > MaximumUploadFiles)
				return MaximumFileLimitsResponse;
			var fileName = Path.GetFileName(workbooks[0].FileName);
			var folderName = Path.GetDirectoryName(workbooks[0].FileName);
			var color = GetColor(watermarkColor);

			foreach (var docInfo in workbooks)
			{
				var workbook = docInfo.Workbook;
				foreach (var sheet in workbook.Worksheets)
				{
					//// Add Watermark
					Aspose.Cells.Drawing.Shape wordart = sheet.Shapes.AddTextEffect(MsoPresetTextEffect.TextEffect1,
					 watermarkText, "Arial Black", 60, true, true
					  , 18, 8, 1, 1, 130, 800);
					wordart.Fill.FillType = FillType.Solid;
					wordart.Fill.SolidFill.Color = color;
				}
			}

			SetDefaultOptions(workbooks, "");
			Opts.AppName = "WatermarkApp";
			Opts.MethodName = "AddTextWatermark";
			Opts.ZipFileName = workbooks.Length > 1 ? "Converted workbooks" : Path.GetFileNameWithoutExtension(workbooks[0].FileName);

			var saveOpt = GetSaveOptions("xlsx");
			return  Process((inFilePath, outPath, zipOutFolder) =>
			{
				var tasks = workbooks.Select(doc =>
					Task.Factory.StartNew(() => SaveDocument(doc, outPath, zipOutFolder, saveOpt))).ToArray();
				Task.WaitAll(tasks);
			});

		}

		private System.Drawing.Color GetColor(string watermarkColor)
		{
			if (watermarkColor != "")
			{
				if (!watermarkColor.StartsWith("#"))
				{
					watermarkColor = "#" + watermarkColor;
				}
				return System.Drawing.ColorTranslator.FromHtml(watermarkColor);
			}

			return System.Drawing.Color.Black;
		}
	}
}
