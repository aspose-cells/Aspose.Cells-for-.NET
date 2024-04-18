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
    internal class CellsNodeContentUtil
    {
        internal static string GetWorksheetNodeContent(Worksheet sheet)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Name: " + sheet.Name);
            builder.Append("\nHidden: " + !sheet.IsVisible);

            return builder.ToString();
        }

        internal static string GetRowNodeContent(Row row)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Index: " + row.Index);
            builder.Append("\nHidden: " + row.IsHidden);

            builder.Append("\nHeight: " + row.Height + "pt");

            builder.Append(StyleUtil.GetStyleContent(row.GetStyle()));
            return builder.ToString();
        }

        internal static string GetColumnNodeContent(Column col)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Index: " + col.Index);
            builder.Append("\nHidden: " + col.IsHidden);

            builder.Append("\nWidth: " + col.Width + "pt");

            builder.Append(StyleUtil.GetStyleContent(col.GetStyle()));
            return builder.ToString();
        }

        internal static string GetCellNodeContent(Cell cell)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Name: " + cell.Name);
            builder.Append("\nValue: " + cell.StringValue);
            builder.Append("\nValueType: " + CellValueTypeToStr(cell.Type));
            builder.Append("\nIsFormula: " + cell.IsFormula);
            builder.Append("\nIsArrayFormula: " + cell.IsArrayFormula);
            builder.Append("\nIsSharedFormula: " + cell.IsSharedFormula);
            builder.Append("\nIsTableFormula: " + cell.IsTableFormula);
            
            builder.Append(StyleUtil.GetStyleContent(cell.GetStyle()));
            return builder.ToString();
        }

        internal static string CellValueTypeToStr(CellValueType type)
        {
            switch (type)
            {
                case CellValueType.IsBool:
                    return "bool";
                case CellValueType.IsDateTime:
                    return "datetime";
                case CellValueType.IsError:
                    return "error";
                case CellValueType.IsNull:
                    return "null";
                case CellValueType.IsNumeric:
                    return "numeric";
                case CellValueType.IsString:
                    return "string";
                default:
                    return "unknown";
            }
        }

        internal static string CellAreaToName(CellArea area)
        {
            return RangeToName(area.StartRow, area.StartColumn, area.EndRow, area.EndColumn);
        }
        

        internal static string RangeToName(int startRow, int startColumn, int endRow, int endColumn)
        {
            StringBuilder sb = new StringBuilder();
            ColumnIndexToName(sb, startColumn);
            sb.Append(startRow + 1);
            if (startRow != endRow
                     || startColumn != endColumn)
            {
                sb.Append(":");
                ColumnIndexToName(sb, endColumn);
                sb.Append(endRow + 1);

            }
            return sb.ToString();
        }

        internal static void ColumnIndexToName(StringBuilder sb, int column)
        {
            if (column < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (column < 26)
            {
                sb.Append((char)(column + 'A'));
            }
            else if (column < 702)
            {
                char c1 = (char)((column % 26) + 'A');

                column = column / 26 - 1;
                sb.Append((char)(column + 'A'));
                sb.Append(c1);
            }
            else if (column <= 16383)
            {
                char c1 = (char)((column % 26) + 'A');
                column = column / 26 - 1;
                char c2 = (char)((column % 26) + 'A');
                column = column / 26 - 1;
                sb.Append((char)(column + 'A'));
                sb.Append(c2);
                sb.Append(c1);

            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        internal static string GetFormatConditionsNodeContent(FormatConditionCollection formats)
        {
            StringBuilder builder = new StringBuilder();
            int rangeCount = formats.RangeCount;

            builder.Append("FormatCondition count: " + formats.Count);

            builder.Append("\nRange:");
            for (int i = 0; i < rangeCount; i++)
            {
                CellArea area = formats.GetCellArea(i);
                builder.Append("\n" + CellAreaToName(area));
            }
            return builder.ToString();
        }

        internal static string GetFormatConditionNodeContent(FormatCondition format)
        {
            StringBuilder builder = new StringBuilder();

            string type = GetFormatConditionName(format.Type);
            if (!string.IsNullOrEmpty(type))
            {
                builder.Append("FormatConditionType: " + type);
            }

            string operType = ConditionOperatorToString(format.Operator);
            if (!string.IsNullOrEmpty(operType))
            {
                builder.Append("\nOperator Type: " + operType);
            }
            if (!string.IsNullOrEmpty(format.Formula1))
            {
                builder.Append("\nFormula1: " + format.Formula1);
            }
            if (!string.IsNullOrEmpty(format.Formula2))
            {
                builder.Append("\nFormula1: " + format.Formula2);
            }

            IconSet iconset = format.IconSet;
            if (iconset != null && format.Type == FormatConditionType.IconSet)
            {
                builder.Append("\nIconSet:");
                string iconsetType = IconSetTypeToString(iconset.Type);
                if (!string.IsNullOrEmpty(iconsetType))
                {
                    builder.Append("\nIconSetType: " + iconsetType);
                }
            }

            ColorScale colorscale = format.ColorScale;
            if (colorscale != null && format.Type == FormatConditionType.ColorScale)
            {
                builder.Append("\nColorScale:");
                if (colorscale.MaxColor != null)
                {
                    builder.Append("\nMaxColor: 0x" + StyleUtil.SysColorToRGBHexStr(colorscale.MaxColor));
                }
                if (colorscale.MidColor != null)
                {
                    builder.Append("\nMidColor: 0x" + StyleUtil.SysColorToRGBHexStr(colorscale.MidColor));
                }
                if (colorscale.MinColor != null)
                {
                    builder.Append("\nMinColor: 0x" + StyleUtil.SysColorToRGBHexStr(colorscale.MinColor));
                }
            }

            DataBar databar = format.DataBar;

            if (databar != null && format.Type == FormatConditionType.DataBar)
            {
                builder.Append("\nDataBar:");
                if (databar.AxisColor != null)
                {
                    builder.Append("\nAxisColor: 0x" + StyleUtil.SysColorToRGBHexStr(databar.AxisColor));
                }
                if (databar.Color != null)
                {
                    builder.Append("\nColor: 0x" + StyleUtil.SysColorToRGBHexStr(databar.Color));
                }

                string direction = DataBarTextDirectionTypeToString(databar.Direction);
                if (!string.IsNullOrEmpty(direction))
                {
                    builder.Append("\nDirection: " + direction);
                }

                if (databar.BarFillType == DataBarFillType.Gradient)
                {
                    builder.Append("\nBarFillType: " + "Gradient");
                }
                else
                {
                    builder.Append("\nBarFillType: " + "Solid");
                }
            }

            if (format.Style != null)
            {                
                StyleUtil.GetStyleContent(format.Style);
            }
            
            
          
            return builder.ToString();
        }


        internal static string DataBarTextDirectionTypeToString(TextDirectionType type)
        {
            switch (type)
            {
                case TextDirectionType.LeftToRight:
                    return "leftToRight";
                case TextDirectionType.RightToLeft:
                    return "rightToLeft";
                default:
                    return null;
            }
        }

        internal static string IconSetTypeToString(IconSetType type)
        {
            switch (type)
            {
                case IconSetType.Arrows3:
                    return "3Arrows";
                case IconSetType.Arrows4:
                    return "4Arrows";
                case IconSetType.Arrows5:
                    return "5Arrows";
                case IconSetType.ArrowsGray3:
                    return "3ArrowsGray";
                case IconSetType.ArrowsGray4:
                    return "4ArrowsGray";
                case IconSetType.ArrowsGray5:
                    return "5ArrowsGray";
                case IconSetType.Flags3:
                    return "3Flags";
                case IconSetType.Quarters5:
                    return "5Quarters";
                case IconSetType.Rating4:
                    return "4Rating";
                case IconSetType.Rating5:
                    return "5Rating";
                case IconSetType.RedToBlack4:
                    return "4RedToBlack";
                case IconSetType.Signs3:
                    return "3Signs";
                case IconSetType.Symbols3:
                    return "3Symbols";
                case IconSetType.Symbols32:
                    return "3Symbols2";
                case IconSetType.TrafficLights31:
                    return "3TrafficLights1";
                case IconSetType.TrafficLights32:
                    return "3TrafficLights2";
                case IconSetType.TrafficLights4:
                    return "4TrafficLights";
                case IconSetType.Stars3:
                    return "3Stars";
                case IconSetType.Boxes5:
                    return "5Boxes";
                case IconSetType.Triangles3:
                    return "3Triangles";
                case IconSetType.None:
                    return "NoIcons";
                case IconSetType.Smilies3:
                    return "3Smilies";
                case IconSetType.ColorSmilies3:
                    return "3ColorSmilies";
                default:
                    return "";
            }
        }

        internal static string ConditionOperatorToString(OperatorType type)
        {
            switch (type)
            {
                case OperatorType.Between:
                    return "Between";
                case OperatorType.Equal:
                    return "Equal";
                case OperatorType.GreaterOrEqual:
                    return "GreaterOrEqual";
                case OperatorType.GreaterThan:
                    return "greater";
                case OperatorType.LessOrEqual:
                    return "LessOrEqual";
                case OperatorType.LessThan:
                    return "less";
                case OperatorType.NotBetween:
                    return "notBetween";
                case OperatorType.NotEqual:
                    return "notEqual";
                default:
                    return "";
            }
        }

        internal static string GetFormatConditionName(FormatConditionType type)
        {
            switch (type)
            {
                case FormatConditionType.CellValue:
                    return "cellIs";
                case FormatConditionType.Expression:
                    return "expression";
                case FormatConditionType.ColorScale:
                    return "colorScale";
                case FormatConditionType.DataBar:
                    return "dataBar";
                case FormatConditionType.IconSet:
                    return "iconSet";
                case FormatConditionType.AboveAverage:
                    return "aboveAverage";
                case FormatConditionType.BeginsWith:
                    return "beginsWith";
                case FormatConditionType.ContainsBlanks:
                    return "containsBlanks";
                case FormatConditionType.ContainsErrors:
                    return "containsErrors";
                case FormatConditionType.ContainsText:
                    return "containsText";
                case FormatConditionType.DuplicateValues:
                    return "duplicateValues";
                case FormatConditionType.EndsWith:
                    return "endsWith";
                case FormatConditionType.NotContainsBlanks:
                    return "notContainsBlanks";
                case FormatConditionType.NotContainsErrors:
                    return "notContainsErrors";
                case FormatConditionType.NotContainsText:
                    return "notContainsText";
                case FormatConditionType.TimePeriod:
                    return "timePeriod";
                case FormatConditionType.Top10:
                    return "top10";
                case FormatConditionType.UniqueValues:
                    return "uniqueValues";
                default:
                    return "";
            }

        }

        internal static string GetValidationNodeContent(Validation validation)
        {
            StringBuilder builder = new StringBuilder();

            string validationTypeStr = ValidationTypeToString(validation.Type);
            if (!string.IsNullOrEmpty(validationTypeStr))
            {
                builder.Append("ValidationType: " + validationTypeStr);
            }

            CellArea[]  areas = validation.Areas;
            builder.Append("\nAreas: ");
            int len = areas.Length;
            if (areas != null && areas.Length > 0)
            {
                for (int i=0; i <len;i++)
                {
                    builder.Append("\n" + CellAreaToName(areas[i]));
                }
                
            }

            string operType = ConditionOperatorToString(validation.Operator);
            if (!string.IsNullOrEmpty(operType))
            {
                builder.Append("\nOperator Type: " + operType);
            }

            if (validation.Value1 != null)
            {
                builder.Append("\nValue1: " + validation.Value1);
            }

            if (validation.Value2 != null)
            {
                builder.Append("\nValue2: " + validation.Value2);
            }

            

            return builder.ToString();
        }

        internal static string ValidationTypeToString(ValidationType type)
        {
            switch (type)
            {
                case ValidationType.Custom:
                    return "custom";
                case ValidationType.AnyValue:
                    return "none";
                case ValidationType.Date:
                    return "date";
                case ValidationType.Decimal:
                    return "decimal";
                case ValidationType.List:
                    return "list";
                case ValidationType.TextLength:
                    return "textLength";
                case ValidationType.Time:
                    return "time";
                case ValidationType.WholeNumber:
                    return "whole";
                default:
                    return "";
            }
        }

        internal static string GetPivotTableNodeContent(PivotTable table)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Name: " + table.Name);
            builder.Append("\nPivotTable Range(include page fields): " + CellAreaToName(table.TableRange2));
            builder.Append("\nDataRange: " + CellAreaToName(table.TableRange1));
            if (!string.IsNullOrEmpty(table.PivotTableStyleName))
            {
                builder.Append("\nPivotTableStyleName: " + table.PivotTableStyleName);
            }

            return builder.ToString();
        }

        internal static string GetTableNodeContent(ListObject table)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Name: " + table.DisplayName);
       
            builder.Append("\nDataRange: " + table.DataRange.Address);
            if (!string.IsNullOrEmpty(table.TableStyleName))
            {
                 builder.Append("\nTableStyleName: " + table.TableStyleName);                  
            }
           
            return builder.ToString();
        }

        internal static string GetHyperlinkNodeContent(Hyperlink hyperlink)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Address: " + hyperlink.Address);
            builder.Append("\nArea: ");
            builder.Append(hyperlink.Area.ToString());

            return builder.ToString();
        }

        internal static string GetOLEObjectNodeContent(OleObject oleObj)
        {
            StringBuilder builder = new StringBuilder();
            GetCommenProperties(builder, oleObj);

            return builder.ToString();
        }

        internal static string GetCommentNodeContent(Comment comment)
        {
            StringBuilder builder = new StringBuilder();
            GetCommenProperties(builder, comment.CommentShape);

            return builder.ToString(); 
        }

        internal static string GetChartNodeContent(Chart chart)
        {
            StringBuilder builder = new StringBuilder();
            GetCommenProperties(builder, chart.ChartObject);

            return builder.ToString();
        }

        internal static string GetPictureNodeContent(Picture shape)
        {
            StringBuilder builder = new StringBuilder();
            GetCommenProperties(builder, shape);

            return builder.ToString();     
        }


        internal static string GetShapeNodeContent(Shape shape)
        {
            StringBuilder builder = new StringBuilder();
            GetCommenProperties(builder, shape);            

            return builder.ToString();
        }

        private static void GetCommenProperties(StringBuilder builder, Shape shape)
        {
            builder.Append("Name: " + shape.Name);
            builder.Append("\nUpperLeftRow: ");
            builder.Append(shape.UpperLeftRow);
            builder.Append("\nUpperLeftColumn: ");
            builder.Append(shape.UpperLeftColumn);

            builder.Append("\nX: ");
            builder.Append(shape.X + "px   ");
            builder.Append("Y: ");
            builder.Append(shape.Y + "px");

            builder.Append("\nWidth: ");
            builder.Append(shape.Width + "px   ");
            builder.Append("Height: ");
            builder.Append(shape.Height + "px");
        }

    }
}
