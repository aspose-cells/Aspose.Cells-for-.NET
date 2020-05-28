using Aspose.Cells;
using Aspose.Cells.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Aspose.Cells.Live.Demos.UI.Models;

namespace Aspose.Cells.Live.Demos.UI.Controllers
{
	/// <summary>
	/// AsposeCellsMetadataController class
	/// </summary>
	public class AsposeCellsMetadataController : CellsBase
	{
		///<Summary>
		/// Properties method to get metadata
		///</Summary>
		///
		[HttpPost]
		public HttpResponseMessage Properties(string folderName, string fileName)
		{
			

			try
			{
				
				Workbook workbook = new Workbook(Path.Combine(Config.Configuration.WorkingDirectory, folderName, fileName));
				return Request.CreateResponse(HttpStatusCode.OK, new PropertiesResponse(workbook));
			}
			catch (Exception e)
			{
				
				return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
			}
		}

		///<Summary>
		/// Properties method. Should include 'FileName', 'id', 'properties' as params
		///</Summary>
		[HttpPost]
		[AcceptVerbs("GET", "POST")]
		public Response Download()
		{
			Opts.AppName = "MetadataApp";
			Opts.MethodName = "Download";
			try
			{
				var request = Request.Content.ReadAsAsync<JObject>().Result;
				Opts.FileName = Convert.ToString(request["FileName"]);
				Opts.ResultFileName = Opts.FileName;
				Opts.FolderName = Convert.ToString(request["id"]);
				Workbook workbook = new Workbook(Opts.WorkingFileName);

				var pars = request["properties"]["BuiltIn"].ToObject<List<DocProperty>>();
				SetBuiltInProperties(workbook, pars);
				pars = request["properties"]["Custom"].ToObject<List<DocProperty>>();
				SetCustomProperties(workbook, pars);

				return  Process((inFilePath, outPath, zipOutFolder) => { workbook.Save(outPath); });
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return new Response
				{
					Status = "500 " + ex.Message,
					StatusCode = 500
				};
			}
		}

		///<Summary>
		/// Properties method. Should include 'FileName', 'id' as params
		///</Summary>
		[HttpPost]
		[AcceptVerbs("GET", "POST")]
		public Response Clear()
		{
			Opts.AppName = "MetadataApp";
			Opts.MethodName = "Clear";
			try
			{
				var request = Request.Content.ReadAsAsync<JObject>().Result;
				Opts.FileName = Convert.ToString(request["FileName"]);
				Opts.ResultFileName = Opts.FileName;
				Opts.FolderName = Convert.ToString(request["id"]);

				Workbook workbook = new Workbook(Opts.WorkingFileName);
				workbook.BuiltInDocumentProperties.Clear();
				workbook.CustomDocumentProperties.Clear();

				return  Process((inFilePath, outPath, zipOutFolder) => { workbook.Save(outPath); });
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return new Response
				{
					Status = "500 " + ex.Message,
					StatusCode = 500
				};
			}
		}

		/// <summary>
		/// SetBuiltInProperties
		/// </summary>
		/// <param name="workbook"></param>
		/// <param name="pars"></param>
		private void SetBuiltInProperties(Workbook workbook, List<DocProperty> pars)
		{
			var builtin = workbook.BuiltInDocumentProperties;
			var t = builtin.GetType();
			foreach (var par in pars)
			{
				var prop = t.GetProperty(par.Name);
				if (prop != null)
					switch (par.Type)
					{
						case PropertyType.String:
							prop.SetValue(builtin, Convert.ToString(par.Value));
							break;
						case PropertyType.Boolean:
							prop.SetValue(builtin, Convert.ToBoolean(par.Value));
							break;
						case PropertyType.Number:
							prop.SetValue(builtin, Convert.ToInt32(par.Value));
							break;
						case PropertyType.DateTime:
							prop.SetValue(builtin, Convert.ToDateTime(par.Value));
							break;
						case PropertyType.Double:
							prop.SetValue(builtin, Convert.ToDouble(par.Value));
							break;
					}
			}
		}


		/// <summary>
		/// SetCustomProperties
		/// </summary>
		/// <param name="workbook"></param>
		/// <param name="pars"></param>
		private void SetCustomProperties(Workbook workbook, List<DocProperty> pars)
		{
			var custom = workbook.CustomDocumentProperties;
			custom.Clear();
			foreach (var par in pars)
				switch (par.Type)
				{
					case PropertyType.String:
						custom.Add(par.Name, Convert.ToString(par.Value));
						break;
					case PropertyType.Boolean:
						custom.Add(par.Name, Convert.ToBoolean(par.Value));
						break;
					case PropertyType.Number:
						custom.Add(par.Name, Convert.ToInt32(par.Value));
						break;
					case PropertyType.DateTime:
						custom.Add(par.Name, Convert.ToDateTime(par.Value));
						break;
					case PropertyType.Double:
						custom.Add(par.Name, Convert.ToDouble(par.Value));
						break;
				}
		}

		/// <summary>
		/// PropertiesResponse
		/// </summary>
		private class PropertiesResponse
		{
			public BuiltInDocumentPropertyCollection BuiltIn { get; set; }
			public CustomDocumentPropertyCollection Custom { get; set; }

			public PropertiesResponse(Workbook workbook)
			{
				BuiltIn = workbook.BuiltInDocumentProperties;
				Custom = workbook.CustomDocumentProperties;
			}
		}

		/// <summary>
		/// The same fields as in DocumentProperty
		/// </summary>
		private class DocProperty
		{
			public string Name { get; set; }
			public object Value { get; set; }
			public PropertyType Type { get; set; }
		}

	}

}
