using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Cells;

namespace Aspose.Cells.Live.Demos.UI.Models
{
	///<Summary>
	/// AsposeCellsParser class to parse excel file
	///</Summary>
	public class AsposeCellsParser : CellsBase
	{
		///<Summary>
		/// Parse method to call parser controller basd on product name
		///</Summary>
		
		public Response Parse(DocumentInfo[] docs)
		{
			
			if (docs == null)
				return PasswordProtectedResponse;
			if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
				return MaximumFileLimitsResponse;

			SetDefaultOptions(docs, "");
			Opts.AppName = "ParserApp";
			Opts.MethodName = "Parse";
			Opts.ZipFileName = docs.Length > 1 ? "Parser" : Path.GetFileNameWithoutExtension(docs[0].FileName);
			Opts.OutputType = ".txt";
			Opts.CreateZip = true;

			var fileName = Path.GetFileName(docs[0].FileName);
			var folderName = docs[0].FolderName;

			return  Parse(fileName, folderName);
		}

		/// <summary>
		/// It will return true, if there is just one worksheet and it does not have any images.
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="folderName"></param>
		/// <returns></returns>
		public bool IsSingleSheetWithoutAnyImages(string fileName, string folderName)
		{
			fileName = Config.Configuration.WorkingDirectory + folderName + "/" + fileName;
			// fileName = folderName + "/" + fileName;

			var wb = new Workbook(fileName);

			if (wb.Worksheets.Count > 1)
				return false;

			var ws = wb.Worksheets[0];

			return ws.Pictures.Count <= 0;
		}

		///<Summary>
		/// Parse method to parse excel file
		///</Summary>
		public Response Parse(string fileName, string folderName)
		{
			Models.License.SetAsposeCellsLicense();

			bool extractOnlyText;
			try
			{
				extractOnlyText = IsSingleSheetWithoutAnyImages(fileName, folderName);
			}
			catch (Exception ex)
			{
				

				return new Response
				{
					FileName = "",
					FolderName = "",
					Status = "500 " + ex.Message,
					StatusCode = 500,
				};
			}

			if (extractOnlyText) // extracting only text
				return  Process(this.GetType().Name, fileName, folderName, ".txt", false, false,  "Parse",
					// return await Process(this.GetType().Name, fileName, folderName, "", false, false, AsposeCells + ParserApp, ProductFamilyNameKeysEnum.cells, "Parse",
					(inFilePath, outPath, zipOutFolder) =>
					{
						var wb = new Workbook(inFilePath);
						wb.Save(outPath);
						// wb.Save($"{folderName}/{Path.GetFileNameWithoutExtension(fileName)}.txt");
					});

			// extracting text and images
			return  Process(this.GetType().Name, fileName, folderName, "", true, false, "Parse",
				(inFilePath, outPath, zipOutFolder) =>
				{
					var wb = new Workbook(inFilePath);

					var sheetCount = wb.Worksheets.Count;

					var strSheetIndexFormat = (sheetCount < 10) ? "0" : ((sheetCount < 100) ? "00" : ((sheetCount < 1000) ? "000" : "0000"));

					for (var i = 0; i < sheetCount; i++)
					{
						wb.Worksheets.ActiveSheetIndex = i;

						var sheetName = wb.Worksheets[i].Name;
						wb.Save(outPath + "__" + (i + 1).ToString(strSheetIndexFormat) + "_" + sheetName + ".txt");
					}

					for (var i = 0; i < sheetCount; i++)
					{
						var ws = wb.Worksheets[i];
						var picsCount = ws.Pictures.Count;

						for (var j = 0; j < picsCount; j++)
						{
							var pic = ws.Pictures[j];
							var picData = pic.Data;
							var fmt = pic.ImageType.ToString().ToLower();

							var outFilePath = outPath + "__" + (i + 1).ToString(strSheetIndexFormat) + "_" + ws.Name + "__Pic" + j + "." + fmt;
							var flout = new FileStream(outFilePath, FileMode.OpenOrCreate, FileAccess.Write);
							flout.Write(picData, 0, picData.Length);
							flout.Close();
						}
					} //for
				});
		}
	}
}
