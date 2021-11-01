using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Charts;
using System.Globalization;
using Aspose.Cells.Tables;
using Aspose.Cells.Pivot;

namespace CellsExplorer
{
    internal class StyleUtil
    {
        internal static string GetStyleContent(Style style)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("\nNumber: " + style.Number);
            if (!string.IsNullOrEmpty(style.CultureCustom))
            {
                builder.Append("\nCultureCustom: " + style.CultureCustom);
            }

            if (!string.IsNullOrEmpty(style.Custom))
            {
                builder.Append("\nCustom: " + style.Custom);
            }

            if (!string.IsNullOrEmpty(style.InvariantCustom))
            {
                builder.Append("\nInvariantCustom: " + style.InvariantCustom);
            }

            builder.Append("\n" + GetHTextAlignStr(style.HorizontalAlignment));
            builder.Append("\n" + GetVTextAlignStr(style.VerticalAlignment));
            builder.Append("\nIndent: " + style.IndentLevel);
            builder.Append("\nRotationAngle: " + style.RotationAngle);

            builder.Append("\nPattern: " + GetPatternStyleStr(style.Pattern));
            builder.Append("\nBackgroundColor: " + SysColorToRGBHexStr(style.BackgroundColor));
            builder.Append("\nForegroundColor: " + SysColorToRGBHexStr(style.ForegroundColor));

            builder.Append("\nFont: " + GetFontStr(style.Font));

            builder.Append(GetBordersStr(style));

            return builder.ToString();
        }

        internal static String GetPatternStyleStr(BackgroundType val)
        {
            switch (val)
            {
                case BackgroundType.None:
                    return "";
                case BackgroundType.Solid:
                    return "none";
                case BackgroundType.Gray75:
                    return "gray-75";
                case BackgroundType.Gray50:
                    return "gray-50";
                case BackgroundType.Gray25:
                    return "gray-25";
                case BackgroundType.Gray12:
                    return "gray-125";
                case BackgroundType.Gray6:
                    return "gray-0625";
                case BackgroundType.HorizontalStripe:
                    return "horz-stripe";
                case BackgroundType.VerticalStripe:
                    return "vert-stripe";
                case BackgroundType.ReverseDiagonalStripe:
                    return "reverse-diag-stripe";
                case BackgroundType.DiagonalStripe:
                    return "diag-stripe";
                case BackgroundType.DiagonalCrosshatch:
                    return "diag-cross";
                case BackgroundType.ThickDiagonalCrosshatch:
                    return "thick-diag-cross";
                case BackgroundType.ThinHorizontalStripe:
                    return "thin-horz-stripe";
                case BackgroundType.ThinVerticalStripe:
                    return "thin-vert-stripe";
                case BackgroundType.ThinReverseDiagonalStripe:
                    return "thin-reverse-diag-stripe";
                case BackgroundType.ThinDiagonalStripe:
                    return "thin-diag-stripe";
                case BackgroundType.ThinHorizontalCrosshatch:
                    return "thin-horz-cross";
                case BackgroundType.ThinDiagonalCrosshatch:
                    return "thin-diag-cross";
                default:
                    return "";
            }
        }

        internal static string GetFontStr(Font font)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("\n{\nName:" + font.Name);
            builder.Append("\nSize:" + font.DoubleSize);
            string colorHex = SysColorToRGBHexStr(font.Color);
            builder.Append("\ncolor:" + colorHex);

            builder.Append("\nIsBold:" + font.IsBold);
            builder.Append("\nIsItalic:" + font.IsItalic);
            builder.Append("\nIsStrikeout:" + font.IsStrikeout);
            builder.Append("\nIsSubscript:" + font.IsSubscript);
            builder.Append("\nIsSuperscript:" + font.IsSuperscript);
            builder.Append("\nUnderline:" + font.Underline);
            builder.Append("\n}");
            return builder.ToString();
        }

        internal static string GetBordersStr(Style style)
        {
            string top = GetBorderStr(style, BorderType.TopBorder);
            StringBuilder builder = new StringBuilder();
            builder.Append("\nborder-top:" + top);

            string right = GetBorderStr(style, BorderType.RightBorder);
            builder.Append("\nborder-right:" + right);

            string bottom = GetBorderStr(style, BorderType.BottomBorder);
            builder.Append("\nborder-bottom:" + bottom);

            string left = GetBorderStr(style, BorderType.LeftBorder);

            builder.Append("\nborder-left:" + left);

            string diagonalDown = GetBorderStr(style, BorderType.DiagonalDown);
            builder.Append("\nmso-diagonal-down:" + diagonalDown);

            string diagonalUp = GetBorderStr(style, BorderType.DiagonalUp);
            builder.Append("\nmso-diagonal-up:" + diagonalUp);

            return builder.ToString();
        }

        public static string GetBorderStr(Style style, BorderType borderType)
        {
            Border border = style.Borders[borderType];
            CellBorderType lineStyle = border.LineStyle;
            if (lineStyle == CellBorderType.None)
            {
                return "none";
            }
            StringBuilder borderStr = new StringBuilder(GetBorderLineStyleStrPixel(lineStyle));

            borderStr.Append(" #" + SysColorToRGBHexStr(border.Color));

            return borderStr.ToString();
        }

        public static String GetBorderLineStyleStrPixel(CellBorderType val)
        {
            switch (val)
            {
                case CellBorderType.None:
                    return "none";
                case CellBorderType.Thin:
                    return "1px solid";
                case CellBorderType.Medium:
                    return "2px solid";
                case CellBorderType.Dashed:
                    return "1px dashed";
                case CellBorderType.Dotted:
                    return "1px dotted";
                case CellBorderType.Thick:
                    return "3px solid";
                case CellBorderType.Double:
                    return "4px double";
                case CellBorderType.Hair:
                    return "1px hairline";
                case CellBorderType.MediumDashed:
                    return "2px dashed";
                case CellBorderType.DashDot:
                    return "1px dot-dash";
                case CellBorderType.MediumDashDot:
                    return "2px dot-dash";
                case CellBorderType.DashDotDot:
                    return "1px dot-dot-dash";
                case CellBorderType.MediumDashDotDot:
                    return "2px dot-dot-dash";
                case CellBorderType.SlantedDashDot:
                    return "2px dot-dash-slanted";
                default:
                    return "";
            }
        }

        internal static string SysColorToRGBHexStr(System.Drawing.Color color)
        {
            Int32 val = color.ToArgb();
            string s = "0x" + val.ToString("X8", CultureInfo.InvariantCulture).Substring(2);
            return s;
        }


        internal static String GetHTextAlignStr(TextAlignmentType val)
        {
            switch (val)
            {
                case TextAlignmentType.Center:
                    return "text-align: center";
                case TextAlignmentType.Distributed:
                    return "text-align: distributed";
                case TextAlignmentType.Justify:
                    return "text-align: justify";
                case TextAlignmentType.Left:
                    return "text-align: left";
                case TextAlignmentType.Right:
                    return "text-align: right";
                case TextAlignmentType.CenterAcross:
                    return "text-align: center-across";
                case TextAlignmentType.Fill:
                    return "text-align: fill";
                case TextAlignmentType.General:
                    return "text-align: general";
                default:
                    return "";
            }
        }

        internal static String GetVTextAlignStr(TextAlignmentType val)
        {
            switch (val)
            {
                case TextAlignmentType.Bottom:
                    return "vertical-align: bottom";
                case TextAlignmentType.Center:
                    return "vertical-align: middle";
                case TextAlignmentType.Distributed:
                    return "vertical-align: distributed";
                case TextAlignmentType.Justify:
                    return "vertical-align: justify";
                case TextAlignmentType.Top:
                    return "vertical-align: top";
                default:
                    return "";
            }
        }
    }
}
