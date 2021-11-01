using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Charts;
using System.IO;
using Aspose.Cells.Tables;
using Aspose.Cells.Pivot;

namespace CellsExplorer
{
    internal class WorksheetUtil
    {
        private Worksheet sheet;
        private CellsNode sheetNode;
        internal WorksheetUtil(Worksheet currSheet, CellsNode parentNode)
        {
            this.sheet = currSheet;
            this.sheetNode = parentNode;
        }

        internal void AddWorksheetNode()
        {
            AddColumnNodes(sheet, sheetNode);
            AddRowNodes(sheet, sheetNode);

            AddShapeNodes(sheet, sheetNode);
            AddPictureNodes(sheet, sheetNode);
            AddChartNodes(sheet, sheetNode);
            AddCommentNodes(sheet, sheetNode);
            AddOleObjectNodes(sheet, sheetNode);
            AddHyperlinkNodes(sheet, sheetNode);
            AddMergedAreasNode(sheet, sheetNode);
            AddTablesNode(sheet, sheetNode);
            AddPivotTablesNode(sheet, sheetNode);


            AddValidationsNode(sheet, sheetNode);

            AddConditionalFormattingsNode(sheet, sheetNode);
        }

        private void AddConditionalFormattingsNode(Worksheet currSheet, CellsNode parent)
        {
            ConditionalFormattingCollection confitionalFormats = currSheet.ConditionalFormattings;
            int confitionalFormatsCount = confitionalFormats.Count;
            if (confitionalFormatsCount > 0)
            {
                CellsNode conditionalFormatsNode = new CellsNode();
                conditionalFormatsNode.NodeName = "ConditionalFormattings";
                conditionalFormatsNode.NodeContent = "FormatConditionCollection count: " + confitionalFormatsCount; ;
                conditionalFormatsNode.NodeType = CellsNodeType.StructureNode;
                conditionalFormatsNode.ChildList = new ObservableCollection<CellsNode>();

                parent.AddChild(conditionalFormatsNode);

                for (int i = 0; i < confitionalFormatsCount; i++)
                {
                    AddFormatConditionsNode(confitionalFormats[i], conditionalFormatsNode, i + 1);

                }
            }
        }

        private void AddFormatConditionsNode(FormatConditionCollection formats, CellsNode parent, int index)
        {
            int formatCount = formats.Count;
            if (formatCount > 0)
            {
                CellsNode formatsNode = new CellsNode();
                formatsNode.NodeName = "FormatConditions " + index;
                formatsNode.NodeContent = CellsNodeContentUtil.GetFormatConditionsNodeContent(formats);
                formatsNode.NodeType = CellsNodeType.StructureNode;
                formatsNode.ChildList = new ObservableCollection<CellsNode>();

                parent.AddChild(formatsNode);

                for (int i = 0; i < formatCount; i++)
                {
                    AddFormatConditionNode(formats[i], formatsNode, i + 1);

                }
            }
        }

        private void AddFormatConditionNode(FormatCondition format, CellsNode parent, int index)
        {
            CellsNode tableNode = new CellsNode();
            tableNode.NodeName = "FormatCondition " + index;
            tableNode.NodeContent = CellsNodeContentUtil.GetFormatConditionNodeContent(format);
            tableNode.NodeType = CellsNodeType.LeafNode;
            tableNode.ChildList = new ObservableCollection<CellsNode>();

            parent.AddChild(tableNode);
        }

        private void AddValidationsNode(Worksheet currSheet, CellsNode parent)
        {
            ValidationCollection validations = currSheet.Validations;
            int validationCount = validations.Count;
            if (validationCount > 0)
            {
                CellsNode validationsNode = new CellsNode();
                validationsNode.NodeName = "Validations";
                validationsNode.NodeContent = "Validation count: " + validationCount; ;
                validationsNode.NodeType = CellsNodeType.StructureNode;
                validationsNode.ChildList = new ObservableCollection<CellsNode>();

                parent.AddChild(validationsNode);

                for (int i = 0; i < validationCount; i++)
                {
                    AddValidationNode(validations[i], validationsNode, (i + 1));

                }
            }
        }

        private void AddValidationNode(Aspose.Cells.Validation validation, CellsNode parent, int index)
        {
            CellsNode validationNode = new CellsNode();
            validationNode.NodeName = "Validation " + index;
            validationNode.NodeContent = CellsNodeContentUtil.GetValidationNodeContent(validation);
            validationNode.NodeType = CellsNodeType.LeafNode;
            validationNode.ChildList = new ObservableCollection<CellsNode>();

            parent.AddChild(validationNode);
        }


        private void AddPivotTablesNode(Worksheet currSheet, CellsNode parent)
        {
            PivotTableCollection tables = currSheet.PivotTables;
            int tableCount = tables.Count;
            if (tableCount > 0)
            {
                CellsNode tablesNode = new CellsNode();
                tablesNode.NodeName = "PivotTables";
                tablesNode.NodeContent = "PivotTable count: " + tableCount; ;
                tablesNode.NodeType = CellsNodeType.StructureNode;
                tablesNode.ChildList = new ObservableCollection<CellsNode>();

                parent.AddChild(tablesNode);

                for (int i = 0; i < tableCount; i++)
                {
                    AddPivotTableNode(tables[i], tablesNode);

                }
            }
        }

        private void AddPivotTableNode(PivotTable table, CellsNode parent)
        {
            CellsNode tableNode = new CellsNode();
            tableNode.NodeName = table.Name;
            tableNode.NodeContent = CellsNodeContentUtil.GetPivotTableNodeContent(table);
            tableNode.NodeType = CellsNodeType.LeafNode;
            tableNode.ChildList = new ObservableCollection<CellsNode>();

            parent.AddChild(tableNode);
        }

        private void AddTablesNode(Worksheet currSheet, CellsNode parent)
        {
            ListObjectCollection tables = currSheet.ListObjects;
            int tableCount = tables.Count;
            if (tableCount > 0)
            {
                CellsNode tablesNode = new CellsNode();
                tablesNode.NodeName = "Tables";
                tablesNode.NodeContent = "Table count: " + tableCount; ;
                tablesNode.NodeType = CellsNodeType.StructureNode;
                tablesNode.ChildList = new ObservableCollection<CellsNode>();

                parent.AddChild(tablesNode);

                for (int i = 0; i < tableCount; i++)
                {
                    AddTableNode(tables[i], tablesNode);

                }
            }
        }

        private void AddTableNode(ListObject table, CellsNode parent)
        {
            CellsNode tableNode = new CellsNode();
            tableNode.NodeName = table.DisplayName;
            tableNode.NodeContent = CellsNodeContentUtil.GetTableNodeContent(table);
            tableNode.NodeType = CellsNodeType.LeafNode;
            tableNode.ChildList = new ObservableCollection<CellsNode>();

            parent.AddChild(tableNode);
        }

        private void AddMergedAreasNode(Worksheet currSheet, CellsNode parent)
        {
            ArrayList mergedCells = currSheet.Cells.MergedCells;
            int mergedCellsCount = mergedCells.Count;
            if (mergedCellsCount > 0)
            {
                CellsNode mergedCellsNode = new CellsNode();
                mergedCellsNode.NodeName = "MergedAreas";
                mergedCellsNode.NodeContent = "MergedArea count: " + mergedCellsCount; ;
                mergedCellsNode.NodeType = CellsNodeType.StructureNode;
                mergedCellsNode.ChildList = new ObservableCollection<CellsNode>();

                parent.AddChild(mergedCellsNode);

                for (int i = 0; i < mergedCellsCount; i++)
                {
                    AddMergedAreaNode((CellArea)mergedCells[i], mergedCellsNode);

                }
            }
        }

        private void AddMergedAreaNode(CellArea area, CellsNode parent)
        {
            CellsNode oleNode = new CellsNode();

            string range = CellsNodeContentUtil.RangeToName(area.StartRow, area.StartColumn, area.EndRow, area.EndColumn);
            oleNode.NodeName = range;
            oleNode.NodeContent = range;
            oleNode.NodeType = CellsNodeType.LeafNode;
            oleNode.ChildList = new ObservableCollection<CellsNode>();

            parent.AddChild(oleNode);
        }



        private void AddHyperlinkNodes(Worksheet currSheet, CellsNode parent)
        {
            HyperlinkCollection hyperlinks = currSheet.Hyperlinks;
            int hyperlinkCount = hyperlinks.Count;
            if (hyperlinkCount > 0)
            {
                CellsNode hyperlinksNode = new CellsNode();
                hyperlinksNode.NodeName = "Hyperlinks";
                hyperlinksNode.NodeContent = "Hyperlink count: " + hyperlinkCount; ;
                hyperlinksNode.NodeType = CellsNodeType.StructureNode;
                hyperlinksNode.ChildList = new ObservableCollection<CellsNode>();

                parent.AddChild(hyperlinksNode);

                for (int i = 0; i < hyperlinkCount; i++)
                {
                    AddHyperlinkNode(hyperlinks[i], hyperlinksNode);

                }
            }
        }

        private void AddHyperlinkNode(Hyperlink hyperlink, CellsNode parent)
        {
            CellsNode oleNode = new CellsNode();
            oleNode.NodeName = hyperlink.TextToDisplay;
            oleNode.NodeContent = CellsNodeContentUtil.GetHyperlinkNodeContent(hyperlink);
            oleNode.NodeType = CellsNodeType.LeafNode;
            oleNode.ChildList = new ObservableCollection<CellsNode>();

            parent.AddChild(oleNode);
        }


        private void AddOleObjectNodes(Worksheet currSheet, CellsNode parent)
        {
            OleObjectCollection oles = currSheet.OleObjects;
            int oleCount = oles.Count;
            if (oleCount > 0)
            {
                CellsNode olesNode = new CellsNode();
                olesNode.NodeName = "OleObjects";
                olesNode.NodeContent = "OleObject count: " + oleCount; ;
                olesNode.NodeType = CellsNodeType.StructureNode;
                olesNode.ChildList = new ObservableCollection<CellsNode>();

                parent.AddChild(olesNode);

                for (int i = 0; i < oleCount; i++)
                {
                    AddOleObjectNode(oles[i], olesNode);

                }
            }
        }

        private void AddOleObjectNode(OleObject oleObj, CellsNode parent)
        {
            CellsNode oleNode = new CellsNode();
            oleNode.NodeName = oleObj.Name;
            oleNode.NodeContent = CellsNodeContentUtil.GetOLEObjectNodeContent(oleObj);
            oleNode.NodeType = CellsNodeType.LeafNode;
            oleNode.ChildList = new ObservableCollection<CellsNode>();

            parent.AddChild(oleNode);
        }

        private void AddCommentNodes(Worksheet currSheet, CellsNode parent)
        {
            CommentCollection comments = currSheet.Comments;
            int commentCount = comments.Count;
            if (commentCount > 0)
            {
                CellsNode commentsNode = new CellsNode();
                commentsNode.NodeName = "Comments";
                commentsNode.NodeContent = "Comment count: " + commentCount; ;
                commentsNode.NodeType = CellsNodeType.StructureNode;
                commentsNode.ChildList = new ObservableCollection<CellsNode>();

                parent.AddChild(commentsNode);

                for (int i = 0; i < commentCount; i++)
                {
                    AddCommentNode(comments[i], commentsNode);

                }
            }
        }

        private void AddCommentNode(Comment comment, CellsNode parent)
        {
            CellsNode commentNode = new CellsNode();
            commentNode.NodeName = comment.CommentShape.Name;
            commentNode.NodeContent = CellsNodeContentUtil.GetCommentNodeContent(comment);
            commentNode.NodeType = CellsNodeType.LeafNode;
            commentNode.ChildList = new ObservableCollection<CellsNode>();

            parent.AddChild(commentNode);
        }

        private void AddColumnNodes(Worksheet currSheet, CellsNode parent)
        {
            ColumnCollection cols = currSheet.Cells.Columns;
            int colCount = cols.Count;
            if (colCount > 0)
            {
                CellsNode colsNode = new CellsNode();
                colsNode.NodeName = "Columns";
                colsNode.NodeContent = "Column count: " + colCount; ;
                colsNode.NodeType = CellsNodeType.StructureNode;
                colsNode.ChildList = new ObservableCollection<CellsNode>();
                parent.AddChild(colsNode);

                IEnumerator iter = cols.GetEnumerator();
                while (iter.MoveNext())
                {
                    Column curr = (Column)iter.Current;
                    CellsNode currRowNode = GetColumnNode(curr, colsNode);
                    colsNode.AddChild(currRowNode);
                }


            }
        }

        private CellsNode GetColumnNode(Column col, CellsNode parent)
        {
            CellsNode colNode = new CellsNode();
            colNode.NodeName = "Column " + CellsHelper.ColumnIndexToName(col.Index);
            colNode.NodeContent = CellsNodeContentUtil.GetColumnNodeContent(col);
            colNode.NodeType = CellsNodeType.LeafNode;
            colNode.ChildList = new ObservableCollection<CellsNode>();

            return colNode;
        }

        private void AddRowNodes(Worksheet currSheet, CellsNode parent)
        {
            RowCollection rows = currSheet.Cells.Rows;
            int rowCount = rows.Count;
            if (rowCount > 0)
            {
                CellsNode rowsNode = new CellsNode();
                rowsNode.NodeName = "Rows";
                rowsNode.NodeContent = "Row count: " + rowCount; ;
                rowsNode.NodeType = CellsNodeType.StructureNode;
                rowsNode.ChildList = new ObservableCollection<CellsNode>();
                parent.AddChild(rowsNode);

                IEnumerator iter = rows.GetEnumerator();
                while (iter.MoveNext())
                {
                    Row curr = (Row)iter.Current;
                    CellsNode currRowNode = GetRowNode(curr, rowsNode);
                    rowsNode.AddChild(currRowNode);

                    IEnumerator rowIter = curr.GetEnumerator();
                    while (rowIter.MoveNext())
                    {
                        AddCellNode((Cell)rowIter.Current, currRowNode);
                    }
                }


            }
        }

        private CellsNode GetRowNode(Row row, CellsNode parent)
        {
            CellsNode rowNode = new CellsNode();
            rowNode.NodeName = "Row " + (row.Index + 1);
            rowNode.NodeContent = CellsNodeContentUtil.GetRowNodeContent(row);
            rowNode.NodeType = CellsNodeType.StructureNode;
            rowNode.ChildList = new ObservableCollection<CellsNode>();

            return rowNode;
        }

        private void AddCellNode(Cell currCell, CellsNode parent)
        {
            CellsNode cellNode = new CellsNode();
            cellNode.NodeName = currCell.Name;
            cellNode.NodeContent = CellsNodeContentUtil.GetCellNodeContent(currCell);
            cellNode.NodeType = CellsNodeType.LeafNode;
            cellNode.ChildList = new ObservableCollection<CellsNode>();

            parent.AddChild(cellNode);
        }

        private void AddChartNodes(Worksheet currSheet, CellsNode parent)
        {
            ChartCollection charts = currSheet.Charts;
            int chartCount = charts.Count;
            if (chartCount > 0)
            {
                CellsNode chartsNode = new CellsNode();
                chartsNode.NodeName = "Charts";
                chartsNode.NodeContent = "Chart count: " + chartCount; ;
                chartsNode.NodeType = CellsNodeType.StructureNode;
                chartsNode.ChildList = new ObservableCollection<CellsNode>();

                parent.AddChild(chartsNode);

                for (int i = 0; i < chartCount; i++)
                {
                    AddChartNode(charts[i], chartsNode);

                }
            }
        }

        private void AddChartNode(Chart chart, CellsNode parent)
        {
            CellsNode chartNode = new CellsNode();
            chartNode.NodeName = chart.Name;
            chartNode.NodeContent = CellsNodeContentUtil.GetChartNodeContent(chart);
            chartNode.NodeType = CellsNodeType.LeafNode;
            chartNode.ChildList = new ObservableCollection<CellsNode>();

            parent.AddChild(chartNode);
        }

        private void AddPictureNodes(Worksheet currSheet, CellsNode parent)
        {
            PictureCollection picts = currSheet.Pictures;
            int pictsCount = picts.Count;
            if (pictsCount > 0)
            {
                CellsNode pictsNode = new CellsNode();
                pictsNode.NodeName = "Pictures";
                pictsNode.NodeContent = "Picture count: " + pictsCount; ;
                pictsNode.NodeType = CellsNodeType.StructureNode;
                pictsNode.ChildList = new ObservableCollection<CellsNode>();

                parent.AddChild(pictsNode);

                for (int i = 0; i < pictsCount; i++)
                {
                    AddPictureNode(picts[i], pictsNode);

                }
            }
        }

        private void AddPictureNode(Picture pict, CellsNode parent)
        {
            CellsNode pictNode = new CellsNode();
            pictNode.NodeName = pict.Name;
            pictNode.NodeContent = CellsNodeContentUtil.GetPictureNodeContent(pict);
            pictNode.NodeType = CellsNodeType.LeafNode;
            pictNode.ChildList = new ObservableCollection<CellsNode>();

            parent.AddChild(pictNode);
        }

        private void AddShapeNodes(Worksheet currSheet, CellsNode parent)
        {
            ShapeCollection shapes = currSheet.Shapes;
            int shapeCount = shapes.Count;
            if (shapeCount > 0)
            {
                CellsNode shapesNode = new CellsNode();
                shapesNode.NodeName = "Shapes";
                shapesNode.NodeContent = "Shape count: " + shapeCount; ;
                shapesNode.NodeType = CellsNodeType.StructureNode;
                shapesNode.ChildList = new ObservableCollection<CellsNode>();

                parent.AddChild(shapesNode);

                for (int i = 0; i < shapeCount; i++)
                {
                    Shape shape = shapes[i];
                    if (IsNeedAddShape(shape))
                    {
                        AddShapeNode(shape, shapesNode, false);
                    }

                }
            }

        }

        private void AddShapeNode(Shape shape, CellsNode parent, bool groupIn)
        {
            if (shape.Group != null && !groupIn)
            {
                return;
            }
            bool isGroupShape = shape is GroupShape;

            CellsNode shapeNode = new CellsNode();
            shapeNode.NodeName = shape.Name;
            shapeNode.NodeContent = CellsNodeContentUtil.GetShapeNodeContent(shape);

            if (isGroupShape)
            {
                shapeNode.NodeType = CellsNodeType.StructureNode;
            }
            else
            {
                shapeNode.NodeType = CellsNodeType.LeafNode;
            }

            shapeNode.ChildList = new ObservableCollection<CellsNode>();

            parent.AddChild(shapeNode);

            if (isGroupShape)
            {
                GroupShape groupShape = (GroupShape)shape;
                Shape[] children = groupShape.GetGroupedShapes();
                int childCount = children.Length;
                for (int i = 0; i < childCount; i++)
                {
                    Shape child = children[i];
                    AddShapeNode(child, shapeNode, true);
                }
            }
        }

        private bool IsNeedAddShape(Shape shape)
        {
            bool isPict = shape is Picture;

            bool isChart = shape is ChartShape;

            bool isOle = shape is OleObject;

            bool isComment = shape is CommentShape;

            return !(isPict || isChart || isOle || isComment);
        }

    }
}
