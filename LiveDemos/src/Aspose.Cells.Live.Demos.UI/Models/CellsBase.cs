using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells.Live.Demos.UI.Models;
using Aspose.Cells.Live.Demos.UI.Services;
using Aspose.Cells;
using Aspose.Cells.Rendering;
using File = System.IO.File;
using Aspose.Cells.Live.Demos.UI.Helpers;

namespace Aspose.Cells.Live.Demos.UI.Models
{
	///<Summary>
	/// CellsBase class 
	///</Summary>

	public class CellsBase : ModelBase
	{
		
		/// <summary>
		/// Maximum number of files which can be uploaded for MVC Aspose.Words apps
		/// </summary>
		protected const int MaximumUploadFiles = 10;

    /// <summary>
    /// Original file format SaveAs option for multiple files uploading. By default, "-"
    /// </summary>
    protected const string SaveAsOriginalName = ".-";
    
    /// <summary>
    /// Response when uploaded files exceed the limits
    /// </summary>
    protected Response MaximumFileLimitsResponse = new Response()
    {
      Status = $"Number of files should be less {MaximumUploadFiles}",
      StatusCode = 500
    };
		/// <summary>
		/// Response when uploaded files exceed the limits
		/// </summary>
		protected Response PasswordProtectedResponse = new Response()
		{
			Status = "Some of your documents are password protected",
			StatusCode = 500
		};
		/// <summary>
		/// Response when uploaded files exceed the limits
		/// </summary>
		protected Response BadDocumentResponse = new Response()
		{
			Status = "Some of your documents are corrupted",
			StatusCode = 500
		};


		///<Summary>
		/// Aspose Cells Options Class
		///</Summary>
		protected class Options
		{
			///<Summary>
			/// AppName
			///</Summary>
			public string AppName;

			///<Summary>
			/// FolderName
			///</Summary>
			public string FolderName;

			///<Summary>
			/// FileName
			///</Summary>
			public string FileName;

			private string _outputType;

			/// <summary>
			/// By default, it is the extension of FileName
			/// </summary>
			public string OutputType
			{
				get => _outputType;
				set
				{
					if (!value.StartsWith("."))
						value = "." + value;
					_outputType = value;
				}
			}

			/// <summary>
			/// Check if OuputType is a picture extension
			/// </summary>
			public bool IsPicture
			{
				get
				{
					switch (_outputType.ToLower())
					{
						case ".bmp":
						case ".png":
						case ".jpg":
						case ".jpeg":
							return true;
						default:
							return false;
					}
				}
			}

			///<Summary>
			/// ResultFileName
			///</Summary>
			public string ResultFileName;

			///<Summary>
			/// MethodName
			///</Summary>
			public string MethodName;

			///<Summary>
			/// ModelName
			///</Summary>
			public string ModelName;

			///<Summary>
			/// CreateZip
			///</Summary>
			public bool CreateZip;

			///<Summary>
			/// CheckNumberOfPages
			///</Summary>
			public bool CheckNumberOfPages = false;

			///<Summary>
			/// DeleteSourceFolder
			///</Summary>
			public bool DeleteSourceFolder = false;

			///<Summary>
			/// CalculateZipFileName
			///</Summary>
			public bool CalculateZipFileName = true;

			/// <summary>
			/// Output zip filename (without '.zip'), if CreateZip property is true
			/// By default, FileName + AppName
			/// </summary>
			public string ZipFileName;

			/// <summary>
			/// AppSettings.WorkingDirectory + FolderName + "/" + FileName
			/// </summary>
			public string WorkingFileName
			{
				get
				{
					if (File.Exists(Config.Configuration.WorkingDirectory + FolderName + "/" + FileName))
						return Config.Configuration.WorkingDirectory + FolderName + "/" + FileName;
					return Config.Configuration.OutputDirectory + FolderName + "/" + FileName;
				}
			}
		}
		/// <summary>
		/// init Options
		/// </summary>
		protected Options Opts = new Options();
    
    /// <summary>
    /// UTF8WithoutBom
    /// </summary>
    protected static readonly Encoding UTF8WithoutBom = new UTF8Encoding(false);

		

		

		/// <summary>
		/// Set default parameters into Opts
		/// </summary>
		/// <param name="docs"></param>
		protected void SetDefaultOptions(DocumentInfo[] docs, string outputType)
		{
			if (docs.Length <= 0) return;
			SetDefaultOptions(Path.GetFileName(docs[0].FileName), outputType);
			Opts.CreateZip = docs.Length > 1 || Opts.IsPicture;
		}



		/// <summary>
		/// Set default parameters into Opts
		/// </summary>
		/// <param name="filename"></param>
		private void SetDefaultOptions(string filename, string outputType)
		{
			//Opts.FolderName = FolderName;
			Opts.ResultFileName = filename;
			Opts.FileName = Path.GetFileName(filename);

			//var query = Request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);

			//if (query.ContainsKey("outputType"))
			//outputType = query["outputType"];
			Opts.OutputType = !string.IsNullOrEmpty(outputType)
			  ? outputType
			  : Path.GetExtension(Opts.FileName);

			Opts.ResultFileName = Opts.OutputType == SaveAsOriginalName
			  ? Opts.FileName
			  : Path.GetFileNameWithoutExtension(Opts.FileName) + Opts.OutputType;
		}

		/// <summary>
		/// GetSaveOptions
		/// </summary>
		/// <param name="outputType"></param>
		/// <returns></returns>
		protected SaveFormatType GetSaveOptions(string outputType)
		{
			var saveFormat = new SaveFormatType { SaveOptions = null };
			switch (outputType)
			{
				case "ods":
					{
						saveFormat.SaveOptions = new OdsSaveOptions();
						saveFormat.SaveType = SaveType.ods;
						break;
					}
				case "pdf":
					{
						saveFormat.SaveOptions = new PdfSaveOptions();
						saveFormat.SaveType = SaveType.pdf;
						break;
					}
				case "xps":
					{
						saveFormat.SaveOptions = new XpsSaveOptions();
						saveFormat.SaveType = SaveType.xps;
						break;
					}
				case "xlsx":
					{
						saveFormat.SaveType = SaveType.xlsx;
						break;
					}
				case "xls":
					{
						saveFormat.SaveType = SaveType.xls;
						break;
					}
				case "xlsm":
					{
						saveFormat.SaveType = SaveType.xlsm;
						break;
					}
				case "xlsb":
					{
						saveFormat.SaveType = SaveType.xlsb;
						break;
					}
				case "xlam":
					{
						saveFormat.SaveType = SaveType.xlam;
						break;
					}
				case "csv":
					{
						saveFormat.SaveType = SaveType.csv;
						break;
					}
				case "html":
					{
						saveFormat.SaveOptions = new HtmlSaveOptions();
						saveFormat.SaveType = SaveType.html;
						break;
					}
				case "svg":
					{
						saveFormat.SaveOptions = new SvgSaveOptions();
						saveFormat.SaveType = SaveType.svg;
						break;
					}
				case "bmp":
					{
						saveFormat.SaveType = SaveType.bmp;
						break;
					}
				case "png":
					{
						saveFormat.SaveType = SaveType.png;
						break;
					}
				case "tiff":
					{
						saveFormat.SaveType = SaveType.tiff;
						break;
					}
				case "jpg":
					{
						saveFormat.SaveType = SaveType.jpg;
						break;
					}
				case "tabdelimited":
					{
						saveFormat.SaveType = SaveType.tabdelimited;
						break;
					}
				default:
					saveFormat.SaveType = null;
					break;
			}

			return saveFormat;
		}

		/// <summary>
		/// Prepare upload files and return DocumentInfo[]
		/// </summary>
		protected async Task<DocumentInfo[]> UploadFiles(string password)
		{
			try
			{
				var folderName = Guid.NewGuid().ToString();
				var pathProcessor = new PathProcessor(folderName);
				var uploadProvider = new MultipartFormDataStreamProviderSafe(pathProcessor.SourceFolder);
				await Request.Content.ReadAsMultipartAsync(uploadProvider);
				return uploadProvider.FileData.Select(x => new DocumentInfo
				{
					FolderName = folderName,
					FileName = x.LocalFileName,
					Workbook = new Workbook(x.LocalFileName, new LoadOptions { Password = password })
				}).ToArray();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
		}

		/// <summary>
		/// Process
		/// </summary>
		protected Response Process(ActionDelegate action)
		{
			if (string.IsNullOrEmpty(Opts.OutputType))
				Opts.OutputType = Path.GetExtension(Opts.FileName);
			if (Opts.OutputType.ToLower() == ".html" || Opts.OutputType == ".SVG" || Opts.IsPicture)
				Opts.CreateZip = true;
			if (string.IsNullOrEmpty(Opts.ZipFileName) && Opts.CalculateZipFileName)
				Opts.ZipFileName = Path.GetFileNameWithoutExtension(Opts.FileName) + Opts.AppName;


			return Process(GetType().Name, Opts.ResultFileName, Opts.FolderName, Opts.OutputType, Opts.CreateZip,
				Opts.CheckNumberOfPages,
				 Opts.MethodName, action,
				Opts.DeleteSourceFolder, Opts.ZipFileName);
		}

		/// <summary>
		/// Check if the OutputType is a picture and saves the document
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="outPath"></param>
		/// <param name="zipOutFolder"></param>
		/// <param name="saveOptions"></param>
		protected void SaveDocument(DocumentInfo doc, string outPath, string zipOutFolder, SaveFormatType saveOptions)
		{
			string filename;
			if (Opts.CreateZip)
				filename = zipOutFolder + "/" +
						   (Opts.OutputType == SaveAsOriginalName
							   ? Path.GetFileName(doc.FileName)
							   : Path.GetFileNameWithoutExtension(doc.FileName) + Opts.OutputType);
			else
				filename = outPath;
			SaveDocument(doc, filename, saveOptions);
		}

		/// <summary>
		/// Check if the OutputType is a picture and saves the document
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="filename">The output full FileName</param>
		/// <param name="saveOptions"></param>
		protected void SaveDocument(DocumentInfo doc, string filename, SaveFormatType saveOptions)
		{
			string outPath;
			var zipOutFolder = $"{Path.GetDirectoryName(filename)}\\{Path.GetFileNameWithoutExtension(filename)}";
			if (Opts.CreateZip)
				Directory.CreateDirectory(zipOutFolder);
			// saveoption已知
			if (saveOptions.SaveOptions != null)
			{
				// svg
				if (saveOptions.SaveType == SaveType.svg)
				{
					var imgOptions = new ImageOrPrintOptions { SaveFormat = SaveFormat.SVG, OnePagePerSheet = true };
					var sheetCount = doc.Workbook.Worksheets.Count;
					//string outfileName = Path.GetFileNameWithoutExtension(filename) + "_{0}";
					// Loop through all the pages
					foreach (var sheet in doc.Workbook.Worksheets)
					{
						var sr = new SheetRender(sheet, imgOptions);
						var srPageCount = sr.PageCount;
						for (var i = 0; i < sr.PageCount; i++)
						{
							string outfileName;
							if ((sheetCount > 1) || (srPageCount > 1))
							{
								outfileName = sheet.Name + "_" + (i + 1) + ".svg";
								outPath = zipOutFolder + "/" + outfileName;
								Opts.CreateZip = true;
							}
							else
							{
								outfileName = Path.GetFileNameWithoutExtension(filename) + ".svg";
								outPath = zipOutFolder + "/" + outfileName;
							}

							sr.ToImage(i, outPath);
						}
					}
				}
				else
				{
					doc.Workbook.Save(filename, saveOptions.SaveOptions);
				}
			}
			else
			{
				var format = ImageFormat.Bmp;
				var imgOptions = new ImageOrPrintOptions();
				var worksheetCount = doc.Workbook.Worksheets.Count;
				var outfileName = Path.GetFileNameWithoutExtension(doc.FileName) + "_{0}";
				outPath = zipOutFolder;
				switch (saveOptions.SaveType)
				{
					case SaveType.xls:
						outPath += ".xls";
						doc.Workbook.Save(outPath, SaveFormat.Excel97To2003);
						break;
					case SaveType.xlsx:
						outPath += ".xlsx";
						doc.Workbook.Save(outPath, SaveFormat.Xlsx);
						break;
					case SaveType.xlsm:
						outPath += ".xlsm";
						doc.Workbook.Save(outPath, SaveFormat.Xlsm);
						break;
					case SaveType.xlsb:
						outPath += ".xlsb";
						doc.Workbook.Save(outPath, SaveFormat.Xlsb);
						break;
					case SaveType.xlam:
						outPath += ".xlam";
						doc.Workbook.Save(outPath, SaveFormat.Xlam);
						break;
					case SaveType.csv:
						outPath += ".csv";
						doc.Workbook.Save(outPath, SaveFormat.CSV);
						break;
					case SaveType.tabdelimited:
						outPath += ".tabdelimited";
						doc.Workbook.Save(outPath, SaveFormat.TabDelimited);
						break;
					case SaveType.tiff:
						outPath += ".tiff";
						doc.Workbook.Save(outPath, SaveFormat.TIFF);
						break;
					case SaveType.png:
						format = ImageFormat.Png;
						imgOptions.ImageFormat = format;
						imgOptions.OnePagePerSheet = true;
						foreach (var sheet in doc.Workbook.Worksheets)
						{
							if (worksheetCount > 1)
							{
								outPath = zipOutFolder + "/" + outfileName;
								outPath = string.Format(outPath, sheet.Name + ".png");
							}
							else
							{
								outPath = zipOutFolder + "/" + Path.GetFileNameWithoutExtension(doc.FileName) + ".png";
							}

							var sr = new SheetRender(sheet, imgOptions);
							var bitmap = sr.ToImage(0);
							bitmap?.Save(outPath);
						}

						break;
					case SaveType.jpg:
						format = ImageFormat.Jpeg;
						imgOptions.ImageFormat = format;
						imgOptions.OnePagePerSheet = true;
						foreach (var sheet in doc.Workbook.Worksheets)
						{
							if (worksheetCount > 1)
							{
								outPath = zipOutFolder + "/" + outfileName;
								outPath = string.Format(outPath, sheet.Name + ".jpg");
							}
							else
							{
								outPath = zipOutFolder + "/" + Path.GetFileNameWithoutExtension(doc.FileName) + ".jpg";
							}

							var sr = new SheetRender(sheet, imgOptions);
							var bitmap = sr.ToImage(0);
							bitmap?.Save(outPath);
						}

						break;
					case SaveType.bmp:
						imgOptions.ImageFormat = format;
						imgOptions.OnePagePerSheet = true;
						foreach (var sheet in doc.Workbook.Worksheets)
						{
							if (worksheetCount > 1)
							{
								outPath = zipOutFolder + "/" + outfileName;
								outPath = string.Format(outPath, sheet.Name + ".bmp");
							}
							else
							{
								outPath = zipOutFolder + "/" + Path.GetFileNameWithoutExtension(doc.FileName) + ".bmp";
							}

							var sr = new SheetRender(sheet, imgOptions);
							var bitmap = sr.ToImage(0);
							bitmap?.Save(outPath);
						}

						break;
				}
			}
		}

		

		/// <summary>
		/// SaveFormatType
		/// </summary>
		public class SaveFormatType
		{
			/// <summary>
			/// SaveOptions
			/// </summary>
			public SaveOptions SaveOptions { get; set; }

			/// <summary>
			/// SaveType
			/// </summary>
			public SaveType? SaveType { get; set; }
		}

		/// <summary>
		/// SaveType
		/// </summary>
		public enum SaveType
		{
			ods,
			pdf,
			xps,
			html,
			jpg,
			png,
			bmp,
			tiff,
			svg,
			xls,
			xlsx,
			xlsm,
			xlsb,
			xlam,
			csv,
			tabdelimited
		}

		/// <summary>
		/// DocumentInfo
		/// </summary>
		public class DocumentInfo
		{
			/// <summary>
			/// FolderName
			/// </summary>
			public string FolderName { get; set; }

			/// <summary>
			/// FileName
			/// </summary>
			public string FileName { get; set; }

			/// <summary>
			/// Workbook
			/// </summary>
			public Workbook Workbook { get; set; }
		}

		/// <summary>
		/// Prepare upload files and return as documents
		/// </summary>
		protected async Task<DocumentInfo[]> UploadWorkBooks()
		{
			
			try
			{
				var folderName = Guid.NewGuid().ToString();
				var pathProcessor = new PathProcessor(folderName);
				var uploadProvider = new MultipartFormDataStreamProviderSafe(pathProcessor.SourceFolder);
				await Request.Content.ReadAsMultipartAsync(uploadProvider);
				return uploadProvider.FileData.Select(x => new DocumentInfo
				{
					FolderName = folderName,
					FileName = x.LocalFileName,
					Workbook = new Workbook(x.LocalFileName)
				}).ToArray();
			}
			catch (Exception ex)
			{

				return new DocumentInfo[0];
			}
		}
	}
}
