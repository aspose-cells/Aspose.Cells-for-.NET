using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tools.Foundation.Models.DTO.LoggingApi
{
	public class Log
	{
		public string Level { get; set; }
		public string Callsite { get; set; }
		public string Type { get; set; }
		public string Message { get; set; }
		public string Stacktrace { get; set; }
		public string InnerException { get; set; }
		public string AdditionalInfo { get; set; }
		public DateTimeOffset? LoggedonDate { get; set; }
		public string Product { get; set; }
		public string Productfamily { get; set; }
		public string Filename { get; set; }
	}
}
