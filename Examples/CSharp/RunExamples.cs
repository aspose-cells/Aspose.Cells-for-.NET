using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using Aspose.Cells.Examples.CSharp.Articles;
using Aspose.Cells.Examples.CSharp.Articles.ApplyConditionalFormatting;
using Aspose.Cells.Examples.CSharp.Articles.ConvertExcelChartToImage;
using Aspose.Cells.Examples.CSharp.Articles.ConvertingWorksheetToImage;
using Aspose.Cells.Examples.CSharp.Articles.CopyRowsColumns;
using Aspose.Cells.Examples.CSharp.Articles.CopyShapesBetweenWorksheets;
using Aspose.Cells.Examples.CSharp.Articles.CreatePivotTablesPivotCharts;
using Aspose.Cells.Examples.CSharp.Articles.DeleteBlankRowsColumns;
using Aspose.Cells.Examples.CSharp.Articles.LineBreakTextWrapping;
using Aspose.Cells.Examples.CSharp.Articles.ModifyExistingStyle;
using Aspose.Cells.Examples.CSharp.Articles.OptimizingMemoryUsage;
using Aspose.Cells.Examples.CSharp.Articles.WorkbookScopedNamedRanges;
using Aspose.Cells.Examples.CSharp.CellsHelperClass;
using Aspose.Cells.Examples.CSharp.Charts;
using Aspose.Cells.Examples.CSharp.Charts.InsertingControlsintoCharts;
using Aspose.Cells.Examples.CSharp.Charts.ManipulateChart;
using Aspose.Cells.Examples.CSharp.Charts.SettingChartsAppearance;
using Aspose.Cells.Examples.CSharp.Data.AddOn.Hyperlinks;
using Aspose.Cells.Examples.CSharp.Data.AddOn.Merging;
using Aspose.Cells.Examples.CSharp.Data.AddOn.NamedRanges;
using Aspose.Cells.Examples.CSharp.Data.Handling;
using Aspose.Cells.Examples.CSharp.Data.Handling.AccessingCells;
using Aspose.Cells.Examples.CSharp.Data.Handling.Find;
using Aspose.Cells.Examples.CSharp.Data.Handling.Importing;
using Aspose.Cells.Examples.CSharp.Data.Processing;
using Aspose.Cells.Examples.CSharp.Data.Processing.FilteringAndValidation;
using Aspose.Cells.Examples.CSharp.DrawingObjects;
using Aspose.Cells.Examples.CSharp.DrawingObjects.Comments;
using Aspose.Cells.Examples.CSharp.DrawingObjects.Controls;
using Aspose.Cells.Examples.CSharp.DrawingObjects.OLE;
using Aspose.Cells.Examples.CSharp.DrawingObjects.Pictures;
using Aspose.Cells.Examples.CSharp.DrawingObjects.Pictures.PositioningPictures;
using Aspose.Cells.Examples.CSharp.Files.Handling;
using Aspose.Cells.Examples.CSharp.Files.Utility;
using Aspose.Cells.Examples.CSharp.Formatting;
using Aspose.Cells.Examples.CSharp.Formatting.ApproachesToFormatData;
using Aspose.Cells.Examples.CSharp.Formatting.Borders;
using Aspose.Cells.Examples.CSharp.Formatting.ConfiguringAlignmentSettings;
using Aspose.Cells.Examples.CSharp.Formatting.DealingWithFontSettings;
using Aspose.Cells.Examples.CSharp.Formatting.Excel2007Themes;
using Aspose.Cells.Examples.CSharp.Formatting.FormatRowsColumns;
using Aspose.Cells.Examples.CSharp.Formatting.SettingDisplayFormats;
using Aspose.Cells.Examples.CSharp.Formulas;
using Aspose.Cells.Examples.CSharp.PivotTableExamples;
using Aspose.Cells.Examples.CSharp.RowsColumns;
using Aspose.Cells.Examples.CSharp.RowsColumns.Grouping;
using Aspose.Cells.Examples.CSharp.RowsColumns.HeightAndWidth;
using Aspose.Cells.Examples.CSharp.RowsColumns.Hiding;
using Aspose.Cells.Examples.CSharp.RowsColumns.InsertingAndDeleting;
using Aspose.Cells.Examples.CSharp.SmartMarkers;
using Aspose.Cells.Examples.CSharp.Tables;
using Aspose.Cells.Examples.CSharp.Worksheets.Display;
using Aspose.Cells.Examples.CSharp.Worksheets.Management;
using Aspose.Cells.Examples.CSharp.Worksheets.Security;
using Aspose.Cells.Examples.CSharp.Worksheets.Value;
using Aspose.Cells.Examples.CSharp.Worksheets.PageSetupFeatures;
using Aspose.Cells.Examples.CSharp.Worksheets.Security.Protecting;
using Aspose.Cells.Examples.CSharp.Worksheets.Security.Unprotect;


namespace Aspose.Cells.Examples.CSharp
{
    internal class RunExamples
    {
        [STAThread()]
        public static void Main()
        {
            Console.WriteLine("Open RunExamples.cs. \nIn Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");
            // Uncomment the one you want to try out        


            // =====================================================
            // =====================================================
            // Articles
            // =====================================================
            // =====================================================

            //AccessTextBoxName.Run();;
            //AddConditionalIconsSet.Run();
            //AddImageHyperlinks.Run();
            //AddingAnonymousCustomObject.Run();
            //AddLibraryReferenceToVbaProject.Run();
            //AddPDFBookmarks.Run();
            //AddPictureToExcelComment.Run();
            //AddWordArtWatermarkToWorksheet.Run();
            //AssignMacroToFormControl.Run();
            //AutoFitRowsMergedCells.Run();
            //AvoidExponentialNotationWhileImportingFromHtml.Run();
            //ChangeHtmlLinkTarget.Run();
            //ChangeTextDirection.Run();
            //CheckVbaProjectSigned.Run();
            //CombineMultipleWorkbooksSingleWorkbook.Run();
            //CombineMultipleWorksheetsSingleWorksheet.Run();
            //ConvertXLSFileToPDF.Run();
            //CopyRangeDataOnly.Run();
            //CopyRangeDataWithStyle.Run();
            //CopyRangeStyleOnly.Run();
            //CreateManipulateRemoveScenarios.Run();
            //CreateTransparentImage.Run();
            //CustomizingRibbonXML.Run();
            //CustomSliceSectorColorsPieChart.Run();
            //DataValidationRules.Run();
            //DeleteRedundantSpacesWhileImportingFromHtml.Run();
            //DetectMergedCells.Run();
            //DisableCompatibilityChecker.Run();
            //ErrorCheckingOptions.Run();           
            //ExportRangeofCells.Run();
            //ExportVisibleRowsData.Run();
            //ExtractImagesFromWorksheets.Run();
            //FindCellsWithSpecificStyle.Run();
            //FindIfCellValueStartsWithSingleQuote.Run();
            //FindQueryTablesAndListObjectsOfExternalDataConnections.Run();
            //FitAllWorksheetColumns.Run();
            //FormatPivotTableCells.Run();
            //FormatWorksheetCells.Run();
            //GenerateThumbnailOfWorksheet.Run();
            //GetDataConnection.Run();
            //GetIconSetsDataBars.Run();
            //HidingDisplayOfZeroValues.Run();
            //HtmlExportFrameScripts.Run();
            //IgnoreHiddenColumnsDataTable.Run();
            //Implement1904DateSystem.Run();
            //ImplementCustomCalculationEngine.Run();
            //ImplementingNonSequencedRanges.Run();
            //InsertDeleteRows.Run();
            //InsertingWAVFile.Run();
            //InsertLinkedPicture.Run();
            //InsertPictureCellReference.Run();
            //LimitNumberOfPagesGenerated.Run();
            //LoadSpecificSheets.Run();
            //LoadWebImage.Run();
            //MergeUnmergeRangeOfCells.Run();
            //MoveRangeOfCells.Run();
            //PopulateData.Run();
            //ReadingCSVMultipleEncodings.Run();
            //RemoveWhitespaceAroundData.Run();
            //RenderOnePdfPagePerExcelWorksheet.Run();
            //ResamplingAddedImages.Run();
            //RetrievingSQLConnectionData.Run();
            //SaveEachWorksheetToDifferentPDF.Run();
            //SearchReplaceDataInRange.Run();
            //SecurePDFDocuments.Run();
            //SetBackgroundPicture.Run();
            //SetExternalLinksInFormulas.Run();
            //SetPictureBackGroundFillChart.Run();
            //SetPixelFormatRenderedImage.Run();
            //SettingFormulaCalculationModeWorkbook.Run();
            //SettingSharedFormula.Run();
            //SettingStrongEncryptionType.Run();
            //SetWorksheetTabColor.Run();
            //ShowFormulasInsteadOfValues.Run();
            //SortData.Run();
            //UpdateRichTextCells.Run();
            //UsePresentationPreferenceOption.Run();
            //UsingCustomXmlParts.Run();
            //UsingImageMarkersWhileGroupingDataInSmartMarkers.Run();
            //UsingLightCellsAPI.Run();
            //UsingWorkbookMetadata.Run();
            //RenderUnicodeInOutput.Run();
            //UpdateReferenceInWorksheets.Run();
            //SettingTextEffectsShadowOfShapeOrTextbox.Run();
            //ImplementDirectCalculationOfCustomFunction.Run();
            //FilterDataWhileLoadingWorkbook.Run(); 
            //AddActiveXControls.Run();
            //ChangeTextBoxOrShareCharacterSpacing.Run();
            //LoadExcelFileWithoutChart.Run();
            //ExportToHTMLWithGridLines.Run();
            //DivTagsLayout.Run();
            //ChartLegendEntry.Run();
            //LoadWorkbookWithPrinterSize.Run();
            //CreateTextBoxWithDifferentHorizontalAlignment.Run();
            SetTextboxOrShapeParagraphLineSpacing.Run();

            //// Apply-Conditional-Formatting
            //// =====================================================
            //ApplyConditionalFormattingCellValue.Run();
            //ApplyConditionalFormattingFormula.Run();

            //// Apply-Superscript And Subscript
            //// =====================================================
            //Articles.ApplySuperscriptAndSubscript.SettingSubscriptEffect.Run();
            //Articles.ApplySuperscriptAndSubscript.SettingSuperscripteffect.Run();

            //// ConvertExcelChartToImage
            //// =====================================================
            //ConvertingColumnChartToImage.Run();
            //ConvertingPieChartToImageFile.Run();

            //// ConvertingWorksheetToImage
            //// =====================================================
            //ConvertWorksheetToImageByPage.Run();
            //ConvertWorksheettoImageFile.Run();

            //// CopyRowsColumns
            //// =====================================================
            //CopyingColumns.Run();
            //CopyingRows.Run();

            //// CopyShapesBetweenWorksheets
            //// =====================================================
            // CopyChart.Run();
            //CopyControls.Run();
            //CopyingPicture.Run();

            //// CreatePivotTablesPivotCharts
            //// =====================================================
            //CreatePivotChart.Run();
            //Articles.CreatePivotTablesPivotCharts.CreatePivotTable.Run();

            //// DeleteBlankRowsColumns
            //// =====================================================
            //DeletingBlankColumns.Run();
            //DeletingBlankRows.Run();

            //// LineBreakTextWrapping
            //// =====================================================
            //UseExplicitLineBreaks.Run();
            //WrapText.Run();

            //// ModifyExistingStyle
            //// =====================================================
            //ModifyThroughSampleExcelFile.Run();
            //ModifyThroughStyleObject.Run();

            //// OptimizingMemoryUsage
            //// =====================================================
            //ReadingLargeExcelFiles.Run();

            //// WorkbookScopedNamedRanges
            //// =====================================================
            //AddWorkbookScopedNamedRange.Run();
            //WorksheetNamedRange.Run();

            // =====================================================
            // =====================================================
            // CellsHelperClass
            // =====================================================
            // =====================================================

            //IndexToName.Run();
            //MergeFiles.Run();
            //NameToIndex.Run();

            // =====================================================
            // =====================================================
            // Charts
            // =====================================================
            // =====================================================

            //Applying3DFormat.Run();
            // ChangeChartPosition.Run();
            //HowToCreateChart.Run();
            //SettingCategoryData.Run();
            //SettingChartsData.Run();
            //UsingSparklines.Run();

            //// InsertingControlsintoCharts
            //// =====================================================
            // Charts.InsertingControlsintoCharts.AddingLabelControl.Run();
            //AddingPictureToChart.Run();
            // Charts.InsertingControlsintoCharts.AddingTextBoxControl.Run();

            //// ManipulateChart
            //// =====================================================
            //HowToCreateBubbleChart.Run();
            //HowToCreateCustomChart.Run();
            //HowToCreateLineChart.Run();
            //HowToCreatePieChart.Run();
            //HowToCreatePyramidChart.Run();
            //MicrosoftTheme.Run();
            //ModifyLineChart.Run();
            //ModifyPieChart.Run();

            //// SettingChartsAppearance
            //// =====================================================
            //ApplyingThemes.Run();
            // ChangingMajorGridlines.Run();
            //MajorGridlines.Run();
            //SettingChartArea.Run();
            //SettingChartLines.Run();
            //SettingTitlesAxes.Run();

            // =====================================================
            // =====================================================
            // Data
            // =====================================================
            // =====================================================

            /// AddOn
            /// =====================================================

            ////// Hyperlinks
            ////// =====================================================
            //AddingLinkToAnotherCell.Run();
            //AddingLinkToExternalFile.Run();
            //AddingLinkToURL.Run();

            ////// Merging
            ///// =====================================================
            //MergingCellsInWorksheet.Run();
            //UnMergingtheMergedCells.Run();

            ////// NamedRanges
            ////// =====================================================
            //AccessAllNamedRanges.Run();
            //AccessSpecificNamedRange.Run();
            // CopyNamedRanges.Run();
            // CreateNamedRangeofCells.Run();
            //FormatRanges1.Run();
            //FormatRanges2.Run();
            //IdentifyCellsinNamedRange.Run();
            //InputDataInCellsInRange.Run();
            //IntersectionofRanges.Run();
            //MergeCellsInNamedRange.Run();
            //RemoveANamedRange.Run();
            //RenameNamedRange.Run();
            //UnionOfRanges.Run();

            //// Handling
            //// =====================================================
            //AddingDataToCells.Run();
            //DataSorting.Run();
            //ExportColumnContainingNonStronglyTypedData.Run();
            //ExportColumnContainingStronglyTypedData.Run();
            //ExportingDataFromWorksheets.Run();
            //RetrievingDataFromCells.Run();

            ////// AccessingCells
            ////// =====================================================
            //AccessingMaximumDisplayRangeofWorksheet.Run();
            //RowAndColumnIndex.Run();
            //UsingCellIndex.Run();
            //UsingCellIndexInCellsCollection.Run();
            //UsingCellName.Run();
            //UsingRowAndColumnIndexOfCell.Run();

            ////// Find
            ////// =====================================================
            //FindCellsContainingFormula.Run();
            //FindCellsStringNumber.Run();
            //FindDataOrFormulas.Run();
            //FindingCellsContainingFormula.Run();
            //FindingCellsContainingStringValueOrNumber.Run();
            //FindingCellsWithStringOrNumber.Run();
            //FindingDataOrFormulasUsingFindOptions.Run();

            ///// Importing
            ///// =====================================================
            //ImportHtmlFormattedData.Run();
            //ImportingFromArray.Run();
            //ImportingFromArrayList.Run();
            //ImportingFromCustomObject.Run();
            //ImportingFromDataColumn.Run();
            //ImportingFromDataGrid.Run();
            //ImportingFromDataTable.Run();
            //ImportingFromDataView.Run();

            //// Processing
            //// =====================================================
            // CreatingSubtotals.Run();
            //TracingDependents.Run();
            //TracingPrecedents.Run();

            ////// FilteringAndValidation
            ////// =====================================================
            //AutofilterData.Run();
            //DateDataValidation.Run();
            //DecimalDataValidation.Run();
            //ListDataValidation.Run();
            //TextLengthDataValidation.Run();
            //TimeDataValidation.Run();
            //WholeNumberDataValidation.Run();

            // =====================================================
            // =====================================================
            // DrawingObjects
            // =====================================================
            // =====================================================      

            //// Comments
            //// =====================================================
            //AddImageToComment.Run();
            //AddingComment.Run();
            // CommentFormatting.Run();

            //// Controls
            //// =====================================================
            //AddinganArrowHead.Run();
            //AddingArcControl.Run();
            //AddingButtonControl.Run();
            //AddingCheckBoxControl.Run();
            //AddingComboBoxControl.Run();
            //AddingGroupBoxControl.Run();
            //DrawingObjects.Controls.AddingLabelControl.Run();
            //AddingLineControl.Run();
            //AddingListBoxControl.Run();
            //AddingOvalControl.Run();
            //AddingRadioButtonControl.Run();
            //AddingRectangleControl.Run();
            //AddingScrollBarControl.Run();
            //AddingSpinnerControl.Run();
            //DrawingObjects.Controls.AddingTextBoxControl.Run();
            //ManipulatingTextBoxControls.Run();            

            //// OLE
            //// =====================================================
            //ExtractingOLEObjects.Run();
            //InsertingOLEObjects.Run();
            //RefreshOLEObjects.Run();

            //// Pictures
            //// =====================================================
            //AddingPictures.Run();

            ////// PositioningPictures
            ////// =====================================================
            //AbsolutePositioning.Run();
            //ProportionalPositioning.Run();

            // =====================================================
            // =====================================================
            // Files
            // =====================================================
            // =====================================================

            //// Handling
            //// =====================================================
            //LoadVisibleSheetsOnly.Run();
            //OpeningCSVFiles.Run();
            //OpeningEncryptedExcelFiles.Run();
            //OpeningFiles.Run();
            //OpeningFilesThroughPath.Run();
            //OpeningFilesThroughStream.Run();
            //OpeningFilewithDataOnly.Run();
            //OpeningHTMLFile.Run();
            //OpeningMicrosoftExcel2007XlsxFiles.Run();
            //OpeningMicrosoftExcel972003Files.Run();
            //OpeningSpreadsheetMLFiles.Run();
            //OpeningTabDelimitedFiles.Run();
            //OpeningTextFilewithCustomSeparator.Run();
            //SaveFileInExcel972003format.Run();
            //SaveInExcel2007xlsbFormat.Run();
            //SaveInExcel2007xlsxFormat.Run();
            //SaveInHtmlFormat.Run();
            //SaveInODSFormat.Run();
            //SaveInPdfFormat.Run();
            //SaveInSpreadsheetMLFormat.Run();
            //SaveWorkbookToTextCSVFormat.Run();
            //SaveXLSFile.Run();
            //SaveXLSXFile.Run();
            //SavingFiles.Run();
            //SavingFiletoSomeLocation.Run();
            //SavingFiletoStream.Run();
            //SavingTextFilewithCustomSeparator.Run();

            //// Utility
            //// =====================================================
            //AdvancedConversiontoPdf.Run();
            //ChartToImage.Run();
            //ConvertingToHTMLFiles.Run();
            //ConvertingToMHTMLFiles.Run();
            //ConvertingToXPS.Run();
            //ConvertingWorksheetToSVG.Run();
            //EncryptingFiles.Run();
            //Excel2PDFConversion.Run();
            //ManagingDocumentProperties.Run();
            //SetPDFCreationTime.Run();
            //SettingImagePrefrencesforHTML.Run();
            //WorksheetToImage.Run();
            //XlstoPDFDirectConversation.Run();

            // =====================================================
            // =====================================================
            // Formatting
            // =====================================================
            // =====================================================

            //ColorsAndBackground.Run();
            //ColorsAndPalette.Run();
            //ComputeColorChoosenByMSExcel.Run();
            //ConditionalFormatting.Run();
            //ConditionalFormattingatRuntime.Run();
            //FormattingSelectedCharacters.Run();
            //MakeCellActive.Run();
            //SetBorder.Run();
            //SetPattern.Run();
            //UsingCopyMethod.Run();

            //// ApproachesToFormatData
            //// =====================================================
            //ApplyingGradientFillEffects.Run();
            //UsingExcelPredefinedStyles.Run();
            //UsingGetStyleSetStyle.Run();
            //UsingStyleObject.Run();

            //// Borders
            //// =====================================================
            //AddingBordersToCells.Run();
            //AddingBorderstoRange.Run();

            //// ConfiguringAlignmentSettings
            //// =====================================================
            //Indentation.Run();
            //MergingCells.Run();
            //Orientation.Run();
            //ShrinkingToFit.Run();
            //TextAlignmentHorizontal.Run();
            //TextAlignmentVertical.Run();
            //TextDirection.Run();
            //WrappingText.Run();

            //// DealingWithFontSettings
            //// =====================================================
            //SettingFontColor.Run();
            //SettingFontName.Run();
            //SettingFontSize.Run();
            //SettingFontStyle.Run();
            //SettingFontUnderlineType.Run();
            //SettingStrikeOutEffect.Run();
            //SettingSubScriptEffect.Run();
            //SettingSuperScriptEffect.Run();

            //// Excel2007Themes
            //// =====================================================
            //CustomizeThemes.Run();
            //GetSetThemeColors.Run();
            //UtilizeThemeColors.Run();

            //// FormatRowsColumns
            //// =====================================================
            //FormattingAColumn.Run();
            //FormattingARow.Run();

            //// SettingDisplayFormats
            //// =====================================================
            //UsingBuiltInNumberFormats.Run();
            //UsingCustomNumber.Run();

            // =====================================================
            // =====================================================
            // Formulas
            // =====================================================
            // =====================================================

            //CalculatingFormulas.Run();
            //CalculatingFormulasOnce.Run();
            //DirectCalculationFormula.Run();
            //ProcessDataUsingAddinfunction.Run();
            //ProcessDataUsingArrayFunction.Run();
            //ProcessDataUsingBuiltinfunction.Run();
            //ProcessDataUsingR1C1.Run();

            // =====================================================
            // =====================================================
            // PivotTableExamples
            // =====================================================
            // =====================================================

            //ChangeSourceData.Run();
            //ClearPivotFields.Run();
            //ConsolidationFunctions.Run();
            //PivotTableExamples.CreatePivotTable.Run();
            //FormattingLook.Run();
            //SettingAutoFormat.Run();
            //SettingDataFieldFormat.Run();
            //SettingFormatOptions.Run();
            //SettingPageFieldFormat.Run();
            //RefreshAndCalculateItems.Run();

            // =====================================================
            // =====================================================
            // RowsColumns
            // =====================================================
            // =====================================================

            //AutofitColumn.Run();
            //AutofitColumninSpecificRange.Run();
            //AutofitRowinSpecificRange.Run();
            //AutofitRowsandColumns.Run();
            //AutofitRowsforMergedCells.Run();

            //// Copying
            //// =====================================================
            //RowsColumns.Copying.CopyingRows.Run();
            //RowsColumns.Copying.CopyingColumns.Run();

            //// Grouping
            //// =====================================================
            //GroupingRowsAndColumns.Run();
            //SummaryRowBelow.Run();
            //SummaryRowRight.Run();
            //UngroupingRowsAndColumns.Run();

            //// HeightAndWidth
            //// =====================================================
            //SettingHeightAllRows.Run();
            //SettingHeightOfAllRowsInWorksheet.Run();
            //SettingHeightOfRow.Run();
            //SettingWidthOfAllColumns.Run();
            //SettingWidthOfAllColumnsInWorksheet.Run();
            //SettingWidthOfColumn.Run();
            //SetWidthAllColumns.Run();

            //// Hiding
            //// =====================================================
            //HidingMultipleRowsAndColumns.Run();
            //HidingRowsAndColumns.Run();
            //UnhidingRowsAndColumns.Run();

            //// InsertingAndDeleting
            //// =====================================================
            //DeletingAColumn.Run();
            //DeletingARow.Run();
            //DeletingMultipleRows.Run();
            //InsertingAColumn.Run();
            //InsertingARow.Run();
            //InsertingMultipleRows.Run();

            // =====================================================
            // =====================================================
            // SmartMarkers
            // =====================================================
            // =====================================================

            //AddCustomLabels.Run();
            // CopyStyleWithSmartMarker.Run();
            //GroupingData.Run();
            //ImageMarkers.Run();
            //UsingCopyStyleAttribute.Run();
            //UsingGenericList.Run();
            //UsingHTMLProperty.Run();
            //UsingNestedObjects.Run();
            //UsingVariableArray.Run();

            // =====================================================
            // =====================================================
            // Tables
            // =====================================================
            // =====================================================

            //ConvertTableToRange.Run();
            //CreatingListObject.Run();
            //FormataListObject.Run();   
            //SetCommentOfTableOrListObject.Run();

            // =====================================================
            // =====================================================
            // Worksheets
            // =====================================================
            // =====================================================

            //// Display
            //// =====================================================
            //ControlTabBarWidth.Run();
            //DisplayHideGridlines.Run();
            //DisplayHideRowColumnHeaders.Run();
            //DisplayHideScrollBars.Run();
            //DisplayTab.Run();
            //FreezePanes.Run();
            //HideTabs.Run();
            //HideUnhideWorksheet.Run();
            //PageBreakPreview.Run();
            //RemovePanes.Run();
            //SplitPanes.Run();
            //ZoomFactor.Run();

            //// Management
            //// =====================================================
            //AccessingWorksheetsusingSheetName.Run();
            //AddingWorksheetsToDesignerSpreadSheet.Run();
            //AddingWorksheetsToNewExcelFile.Run();
            //RemovingWorksheetsUsingSheetIndex.Run();
            //RemovingWorksheetsUsingSheetName.Run();

            //// Security
            //// =====================================================
            //AdvancedProtectionSettings.Run();
            //AdvancedProtectionSettingsUsingAsposeCells.Run();            
            //LockCell.Run();

            //// Value
            //// =====================================================
            //CopyWithinWorkbook.Run();
            //CopyWorksheetsBetweenWorkbooks.Run();
            //CopyWorksheetFromWorkbookToOther.Run();
            //MoveWorksheet.Run();
            //AddingPageBreaks.Run();
            //ClearAllPageBreaks.Run();
            //RemoveSpecificPageBreak.Run();

            //// PageSetupFeatures
            //// =====================================================
            //PageOrientation.Run();
            //ScalingFactor.Run();
            //FitToPagesOptions.Run();
            //ManagePaperSize.Run();
            //SetPrintQuality.Run();
            //SetMargins.Run();
            //SetHeadersAndFooters.Run();
            //SetHeadersAndFooters.Run();
            //InsertImageInHeaderFooter.Run();
            //SetPrintArea.Run();
            //SetPrintTitle.Run();
            //OtherPrintOptions.Run();
            //SetPageOrder.Run();

            ////// Protecting
            ////// =====================================================
            //AllowUserToEditRangesInWorksheet.Run();
            //EditRangesWorksheet.Run();
            //ProtectCellsWorksheet.Run();
            //ProtectColumnWorksheet.Run();
            //ProtectingSpecificCellsinaWorksheet.Run();
            //ProtectingSpecificColumnInWorksheet.Run();
            //ProtectingSpecificRowInWorksheet.Run();
            //ProtectingWorksheet.Run();
            //ProtectRowWorksheet.Run();

            ////// Unprotect
            ////// =====================================================            
            //UnprotectingSimplyProtectedWorksheet.Run();
            //UnprotectSimpleSheet.Run();
            //UnprotectingProtectedWorksheet.Run();

            // Stop before exiting
            Console.WriteLine("\n\nProgram Finished. Press any key to exit....");
            Console.ReadKey();
        }
        public static string GetDataDir(Type t)
        {
            string c = t.FullName;
            c = c.Replace("Aspose.Cells.Examples.CSharp.", "");
            c = c.Replace('.', Path.DirectorySeparatorChar);
            string p = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data", c));
            p += Path.DirectorySeparatorChar;

            if (Directory.Exists(p))
            {
                Console.WriteLine("Using Data Dir {0}", p);
            }
            else
            {
                Directory.CreateDirectory(p);
                Console.WriteLine("Created Data Dir {0}", p);
            }

            return p;
        }
    }
}
