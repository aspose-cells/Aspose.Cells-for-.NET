using System.Web;
using System.Threading;
using Aspose.Cells.UI.Models;

namespace Aspose.Cells.UI.Config
{
	/// <summary>
	/// Wrapper class for Words Aspose Tools context access to Pages and controls
	/// </summary>
	public class AsposeToolsContext : Context
	{
		/// <summary>
		/// The context data is directly picked up from the Application Thread's data slots, this is required to share the context between
		/// independent threads working for this application, e.g. AsyncHttpRequestHandlers and other assemblies as well, this will also 
		/// eliminate the need for extra copies and object cloning b/w assemblies
		/// </summary>
		/// <param name="hc"></param>
		internal AsposeToolsContext(HttpContext hc) : base(hc) { Thread.SetData(Thread.GetNamedDataSlot(Configuration.ResourceFileSessionName + hc.Request.Url.Host.Trim().Replace(".", "") + "ContextSlot"), hc); }
		private static AsposeToolsContext atc;
		/// <summary>
		///  Use for internal syncing of the context
		/// </summary>
		internal static AsposeToolsContext atcc { set { atc = value; } }
		internal static AsposeToolsContext Current
		{
			get { return atc; }
		}

		FlexibleResources _FlexibleResources;

		internal FlexibleResources Resources
		{
			get
			{
				if (_FlexibleResources == null)
					_FlexibleResources = new FlexibleResources(_context, Locale, BaseResources);

				return _FlexibleResources;
			}
		}
	}
}
