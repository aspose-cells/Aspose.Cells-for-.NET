using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cells.Common.Config
{
    public enum AppNames
    {
		Merger,
		Viewer,
		Editor,
		Parser,
		Annotation,
		Watermark,
		Search,
		Unlock,
		Protect,
		Conversion,
		Comparison,
		Splitter,
		Metadata,
		Compress,
		Translation,
		Assembly,
		Chart,
		Repair,
		Esign,
		MortgageCalculator
	}

	public static class AppNamesEx
	{
		public static string ToRouteName(this Enum appName)
		{
			return appName.ToString().ToLower();
		}
	}
}
