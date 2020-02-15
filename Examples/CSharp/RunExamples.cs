using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using Aspose.Cells.Examples.CSharp.Articles;
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
using Aspose.Cells.Examples.CSharp.Articles.WorkingWithHTMLFormat;
using Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting;
using Aspose.Cells.Examples.CSharp.Articles.PageSetupAndPrintingOptions;
using Aspose.Cells.Examples.CSharp.Articles.StylingAndDataFormatting;
using Aspose.Cells.Examples.CSharp.Articles.PivotTablesAndPivotCharts;
using Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine;
using Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets;
using Aspose.Cells.Examples.CSharp.Articles.ManagingRowsColumnsCells;
using Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes;
using Aspose.Cells.Examples.CSharp.Articles.ManageDatabaseConnection;
using Aspose.Cells.Examples.CSharp.Articles.ManagingVBAModules;
using Aspose.Cells.Examples.CSharp.Articles.ManageConditionalFormatting;
using Aspose.Cells.Examples.CSharp.Charts;
using Aspose.Cells.Examples.CSharp.Data;
using Aspose.Cells.Examples.CSharp.Data.Handling;
using Aspose.Cells.Examples.CSharp.Data.Handling.AccessingCells;
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
using Aspose.Cells.Examples.CSharp.KnowledgeBase.Benchmarking;
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
using Aspose.Cells.Examples.CSharp.Articles.UsingImageOrPrintOptions;
using Aspose.Cells.Examples.CSharp.KnowledgeBase.ComparingVSTOWithAspose;
using Aspose.Cells.Examples.CSharp.KnowledgeBase.FAQs;
using Aspose.Cells.Examples.CSharp.Articles.FilteringObjectsAtLoadTime;
using Aspose.Cells.Examples.CSharp.XmlMaps;
using Aspose.Cells.Examples.CSharp._CellsHelper;
using Aspose.Cells.Examples.CSharp.HTML;
using Aspose.Cells.Examples.CSharp.WorkbookSettings;
using Aspose.Cells.Examples.CSharp.Rendering;
using Aspose.Cells.Examples.CSharp.Worksheets;
using Aspose.Cells.Examples.CSharp.LoadingSavingConvertingAndManaging;
using Aspose.Cells.Examples.CSharp._Workbook;
using Aspose.Cells.Examples.CSharp.Slicers;
using Aspose.Cells.Examples.CSharp.PivotTables;

namespace Aspose.Cells.Examples.CSharp
{
    internal class RunExamples
    {
        [STAThread()]
        public static void Main()
        {
            Console.WriteLine("Open RunExamples.cs. \nIn Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");

            Console.WriteLine("Aspose.Cells for .NET v" + CellsHelper.GetVersion());
            Console.WriteLine("");

            //The following lines are setting Aspose.Cells license.
            //Please place the license in 01_SourceDirectory directory 
            //returned by Get_SourceDirectory() method as shown in the code
            try
            {
                // Create a License object
                Aspose.Cells.License license = new License();

                // Set the license of Aspose.Cells to avoid the evaluation limitations
                // Uncomment this line if you have a license
                //license.SetLicense(Get_SourceDirectory() + "Aspose.Cells.lic");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Uncomment the one you want to try out

            //ChangeCommentFontColor.Run();

            //Aspose.Cells for .NET v20.1
            //InsertCheckboxInChartSheet.Run();
            //XAdESSignatureSupport.Run();
            //RegexReplace.Run();
            //PrintHeadings.Run();
            //PivotTableDataDisplayFormatRanking.Run();
            //GetCellValidationInODS.Run();

            //Aspose.Cells for .NET v19.12
            //AllowLeadingApostrophe.Run();
            //ConvertExcelFileToHtmlWithTooltip.Run();

            //Aspose.Cells for .NET v19.11
            //GetTextWidth.Run();
            //ReadAndWriteTableWithQueryTableDataSource.Run();
            //PivotTableSortAndHide.Run();
            //GetOdataDetails.Run();
            //AddValidationArea.Run();

            //Aspose.Cells for .NET v19.10
            //DocumentConversionProgressForTiff.Run();
            //ICellsDataTableDataSourceForWorkbookDesigner.Run();
            //WorkingWithContentTypeProperties.Run();
            //PivotTableCustomSort.Run();

            //Aspose.Cells for .NET v19.9
            //PrintSheetWithAdditionalSettings.Run();
            //AdjustCompressionLevel.Run();

            //Aspose.Cells for .NET v19.8
            //DetectLinkTypes.Run();
            //ExtractEmbeddedMolFile.Run();
            //PrintPreview.Run();

            //Aspose.Cells for .NET v19.7
            //DocumentConversionProgress.Run();

            //Aspose.Cells for .NET v19.6
            //OpeningSXCFiles.Run();
            //OpeningFODSFiles.Run();
            //ExportSlicerToPDF.Run();

            //OpeningTSVFiles.Run();

            //Aspose.Cells for .NET v19.5
            //ReadODSBackground.Run();
            //SetODSColoredBackground.Run();
            //SetODSGraphicBackground.Run();
            //ConvertDatesToJapaneseDates.Run();
            //ImportCustomObjectsToMergedArea.Run();

            //Aspose.Cells for .NET v19.4
            //ConvertExcelFileToMarkdown.Run();
            //CutAndPasteCells.Run();
            //AddThreadedComments.Run();
            //EditThreadedComments.Run();
            //ReadThreadedComments.Run();
            //RemoveThreadedComments.Run();
            //GetChartSubTitleForODSFile.Run();
            //AddWebExtension.Run();
            //AccessWebExtensionInformation.Run();
            //SetColumnViewWidthInPixels.Run();

            //Aspose.Cells for .NET v19.3
            //GetRangeWithExternalLinks.Run();
            //KeepSeparatorsForBlankRow.Run();
            //ImportingFromJson.Run();
            //ConvertTableToRangeWithOptions.Run();

            //Aspose.Cells for .NET v19.2
            //GetHyperlinksInRange.Run();
            //DetectFileFormatOfEncryptedFiles.Run();
            //CountNumberOfCells.Run();
            //OpeningCSVFilesAndReplacingInvalidCharacters.Run();
            //InsertingARowWithFormatting.Run();

            //Aspose.Cells for .NET v19.1
            //ShowReportFilterPagesOption.Main();
            //OpeningFiles.Main();
            //RegisterAndCallFuncFromAddIn.Main();
            //RenderUsingTextCrossType.Main();
            //SortDataInColumnWithBackgroundColor.Main();

            //Aspose.Cells for .NET v18.12
            //CreateLineWithDataMarkerChart.Main();
            //SetSingleSheetTabNameInHtml.Main();
            //FilterVBAMacrosWhileLoadingWorkbook.Main();
            //ReplaceTagWithTextInTextBox.Main();
            //ExportPrintAreaToHtml.Main();
            //CheckIfValidationInCellDropDown.Main();


            //Aspose.Cells for .NET v18.11
            //DetectCircularReference.Main();
            //GetPivotTableRefreshDate.Main();
            //ReplaceTextInSmartArt.Main();
            //DataValidationRules.Main();
            //ConvertExcelFileToSVG.Main();

            //Aspose.Cells for .NET v18.10
            //GetShapeConnectionPoints.Main();
            //SetScalableColumnWidth.Main();
            //RecognizeSelfClosingTags.Main();
            //OpeningCSVFilesWithPreferredParser.Main();
            //SupportNamedRangeFormulasInGermanLocale.Main();
            //AutofilterBeginsWith.Main();
            //AutofilterEndsWith.Main();
            //EvaluateIsBlank.Main();


            //Aspose.Cells for .NET v18.9
            //ExportCustomPropertiesToPDF.Main();
            //GetXMLPathFromListObjectTable.Main();
            //CreateSafeSheetNames.Main();
            //AutofilterBlank.Main();
            //AutofilterNonBlank.Main();
            //AutofilterContains.Main();
            //AutofilterNotContains.Main();
            //RetrieveQueryTableResultRange.Main();

            //Aspose.Cells for .NET v18.8
            //ApplyingTextAlignmentToPartialTextInsideTheTextBox.Main();
            //ContentCopyForAccessibilityOption.Main();
            //DisablePivotTableRibbon.Main();
            //ExportRangeWithFlagToSkipColumnName.Main();
            //PastingRowsColumnsWithPasteOptions.Main();


            //Aspose.Cells for .NET v18.7
            //Data.ChangeCellsAlignmentAndKeepExistingFormatting.Main();
            //WorkbookSettings.FindMaximumRowsAndColumnsSupportedByXLSAndXLSXFormats.Main();
            //Worksheets.Security.SpecifyAuthorWhileWriteProtectingWorkbook.Main();

            //Aspose.Cells for .NET v18.6
            //DrawingObjects.ExtractTextFromGearTypeSmartArtShape.Main();
            //Data.GetAddressCellCountOffsetEntireColumnAndEntireRowOfTheRange.Main();
            //Formulas.AddCellsToMicrosoftExcelFormulaWatchWindow.Main();
            //Slicers.CreateSlicerToPivotTable.Main();
            //Slicers.FormattingSlicer.Main();
            //Slicers.RemovingSlicer.Main();
            //Slicers.RenderingSlicer.Main();
            //Slicers.UpdatingSlicer.Main();
            //_Workbook.AddCustomXMLPartsAndSelectThemByID.Main();

            //Aspose.Cells for .NET v18.5
            //LoadingSavingConvertingAndManaging.SaveWorkbookToStrictOpenXMLSpreadsheetFormat.Main();
            //Fonts.SpecifyIndividualOrPrivateSetOfFontsForWorkbookRendering.Main();
            //DrawingObjects.SpecifyFarEastAndLatinNameOfFontInTextOptionsOfShape.Main();

            //Aspose.Cells for .NET v18.4
            //Charts.CreateChartPDFWithDesiredPageSize.Main();
            //Charts.FindTypeOfXandYValuesOfPointsInChartSeries.Main();
            //Data.GetAllHiddenRowsIndicesAfterRefreshingAutoFilter.Main();
            //DocumentProperties.SpecifyLanguageOfExcelFileUsingBuiltInDocumentProperties.Main();
            //DrawingObjects.RotateTextWithShapeInsideWorksheet.Main();
            //HTML.GetHTML5StringFromCell.Main();
            //HTML.HidingOverlaidContentWithCrossHideRightWhileSavingToHtml.Main();
            //Rendering.AvoidBlankPageInOutputPdfWhenThereIsNothingToPrint.Main();

            //Aspose.Cells for .NET v18.3
            //Charts.ReadAxisLabelsAfterCalculatingTheChart.Run();
            //Data.PreserveSingleQuotePrefixOfCellValueOrRange.Run();
            //DrawingObjects.AccessAndModifyLabelOfOleObject.Run();
            //HTML.ExportSimilarBorderStyle.Run();
            //LoadingSavingConvertingAndManaging.SpecifyDocumentVersionOfExcelFile.Run();
            //PivotTables.GroupPivotFieldsInPivotTable.Run();
            //Rendering.GetDrawObjectAndBoundUsingDrawObjectEventHandler.Run();
            //Worksheets.FindIfWorksheetIsDialogSheet.Run();
            //_Workbook.StopConversionOrLoadingUsingInterruptMonitor.Run();

            //Aspose.Cells for .NET v18.2
            //WorkbookSettings.ControlExternalResourcesUsingWorkbookSetting_StreamProvider.Run();
            //_Workbook.FilterDefinedNamesWhileLoadingWorkbook.Run();
            //DrawingObjects.SetMarginsOfCommentOrShapeInsideTheWorksheet.Run();
            //Data.SpecifyFormulaFieldsWhileImportingDataToWorksheet.Run();
            //Formulas.SpecifyMaximumRowsOfSharedFormula.Run();

            //Aspose.Cells for .NET v18.1
            //Charts.HandleAutomaticUnitsOfChartAxisLikeMicrosoftExcel.Run();
            //HTML.ExcludeUnusedStylesInExcelToHTML.Run();
            //HTML.ExportDocumentWorkbookAndWorksheetPropertiesInHTML.Run();
            //PivotTables.FindAndRefreshNestedOrChildrenPivotTables.Run();
            //PivotTables.ParsingPivotCachedRecordsWhileLoadingExcelFile.Run();
            //Rendering.CreatePdfBookmarkEntryForChartSheet.Run();

            //Aspose.Cells for .NET v17.12
            //Charts.SetShapeTypeOfDataLabelsOfChart.Run();
            //HTML.ExportWorksheetCSSSeparatelyInOutputHTML.Run();
            //HTML.PrefixTableElementsStylesWithHtmlSaveOptions_TableCssIdProperty.Run();
            //Rendering.RenderOfficeAdd_InsWhileConvertingExcelToPdf.Run();
            //SmartMarkers.AutoPopulateSmartMarkerDataToOtherWorksheets.Run();
            //WorkbookSettings.Implement_Cell_FormulaLocal_SimilarTo_Range_FormulaLocal.Run();
            //Worksheets.UpdateDaysPreservingHistoryOfRevisionLogsInSharedWorkbook.Run();

            //Aspose.Cells for .NET v17.11
            //_Workbook.CreateSharedWorkbook.Run();
            //_Workbook.PasswordProtectOrUnprotectSharedWorkbook.Run();
            //DrawingObjects.ConvertSmartArtToGroupShape.Run();
            //DrawingObjects.DetermineIfShapeIsSmartArtShape.Run();
            //Rendering.IgnoreErrorsWhileRenderingExcelToPdf.Run();
            //Rendering.RenderLimitedNoOfSequentialPages.Run();
            //XmlMaps.FindRootElementNameOfXmlMap.Run();
            //XmlMaps.QueryCellAreasMappedToXmlMapPath.Run();

            //Aspose.Cells for .NET v17.10
            //Charts.SetValuesFormatCodeOfChartSeries.Run();
            //Worksheets.UtilizeSheet_SheetId_PropertyOfOpenXml.Run();
            //_Workbook.ReadAndWriteExternalConnectionOfXLSBFile.Run();
            //Formulas.InterruptOrCancelFormulaCalculationOfWorkbook.Run();
            //LoadingSavingConvertingAndManaging.SpecifyHtmlCrossTypeInOutputHTML.Run();

            //Aspose.Cells for .NET v17.9
            //Rendering.AddPDFBookmarksWithNamedDestinations.Run();
            //Rendering.ControlLoadingOfExternalResourcesInExcelToPDF.Run();
            //WorkbookVBAProject.CopyVBAMacroUserFormDesignerStorageToWorkbook.Run();
            //DrawingObjects.SendShapeFrontOrBackInWorksheet.Run();
            //Data.SortDataInColumnWithCustomSortList.Run();

            //Aspose.Cells for .NET v17.8
            //LoadingSavingConvertingAndManaging.DisableDownlevelRevealedCommentsWhileSavingToHTML.Run();
            //LoadingSavingConvertingAndManaging.ExportCommentsWhileSavingExcelFileToHtml.Run();
            //Rendering.OutputBlankPageWhenThereIsNothingToPrint.Run();
            //_CellsHelper.UsingCustomImplementationFactoryToCreateCustomImplementationOfMemoryStream.Run();
            //_Workbook.AddDigitalSignatureToAnAlreadySignedExcelFile.Run();

            //Aspose.Cells for .NET v17.7
            //Data.ApplyAdvancedFilterOfMicrosoftExcel.Run();
            //Fonts.SetDefaultFontPropertyOfPdfSaveOptionsAndImageOrPrintOptions.Run();
            //LoadingSavingConvertingAndManaging.ReadNumbersSpreadsheet.Run();
            //WorkbookSettings.ImplementErrorsAndBooleanValueInRussianOrAnyOtherLanguage.Run();
            //Worksheets.PageSetupFeatures.DetermineIfPaperSizeOfWorksheetIsAutomatic.Run();

            //Aspose.Cells for .NET v17.6
            //DrawingObjects.TilePictureAsTextureInsideShape.Run();
            //SmartMarkers.UsingFormulaParameterInSmartMarkerField.Run();
            //Rendering.ExportRangeOfCellsInWorksheetToImage.Run();

            //Aspose.Cells for .NET v17.5
            //Data.ExportHTMLStringValueOfCellsToDataTable.Run();
            //Data.ShiftFirstRowDownWhenInsertingCellsDataTableRows.Run();
            //LoadingSavingConvertingAndManaging.ConvertExcelFileToPDFA_1a.Run();
            //Worksheets.PageSetupFeatures.CopyPageSetupSettingsFromSourceWorksheetToDestinationWorksheet.Run();
            //Worksheets.PageSetupFeatures.ImplementCustomPaperSizeOfWorksheetForRendering.Run();
            //Worksheets.PageSetupFeatures.RemoveExistingPrinterSettingsOfWorksheets.Run();

            //Aspose.Cells for .NET v17.4.0
            //Data.SpecifyingDBNumCustomPatternFormatting.Run();
            //Data.SpecifyingSortWarningWhileSortingData.Run();
            //WorkbookVBAProject.CheckifVBAProjectisProtectedandLockedforViewing.Run();
            //WorkbookVBAProject.FindoutifVBAProjectisProtected.Run();
            //WorkbookVBAProject.PasswordProtecttheVBAProjectofExcelWorkbook.Run();

            //Aspose.Cells for .NET v17.3.0
            //Charts.ReadManipulateExcel2016Charts.Run();
            //Data.RenameDuplicateColumnsAutomaticallyWhileExportingWorksheetData.Run();
            //Fonts.GetListOfFontsUsedInSpreadsheetOrWorkbook.Run();
            //LoadingSavingConvertingAndManaging.AutoFitColumnsandRowsWhileLoadingHTMLInWorkbook.Run();
            //LoadingSavingConvertingAndManaging.GetWarningsWhileLoadingExcelFile.Run();
            //LoadingSavingConvertingAndManaging.TrimLeadingBlankRowsAndColumnsWhileExportingSpreadsheetsToCSVFormat.Run();
            //RowsColumns.ConvertTextToColumns.Run();

            //Aspose.Cells for .NET v17.2.0
            //Introduction.FirstApplication.Run();
            //Introduction.OpenExistingFile.Run();
            //Introduction.CheckVersionNumber.Run();
            //NumberOfSignificantDigits.Run();
            //GetPageDimensions.Run();
            //CheckCustomFormatPattern.Run();
            //RenderGradientFillToHTML.Run();
            //LoadTemplateWithoutCharts.Run();
            //ReadColorOfShapesGlowEffect.Run();
            //ReadAndManipulateExcel2016Charts.Run();
            //AccessTextBoxName.Run();
            //AddConditionalIconsSet.Run();
            //AddImageHyperlinks.Run();
            //AddingAnonymousCustomObject.Run();
            //AddPDFBookmarks.Run();
            //AddPictureToExcelComment.Run();
            //AddWordArtWatermarkToWorksheet.Run();
            //AutoFitRowsMergedCells.Run();
            //AvoidExponentialNotationWhileImportingFromHtml.Run();
            //ChangeHtmlLinkTarget.Run();
            //ChangeTextDirection.Run();
            //CombineMultipleWorkbooksSingleWorkbook.Run();
            //CombineMultipleWorksheetsSingleWorksheet.Run();
            //ConvertXLSFileToPDF.Run();
            //CopyRangeDataOnly.Run();
            //CopyRangeDataWithStyle.Run();
            //CopyRangeStyleOnly.Run();
            //CreateManipulateRemoveScenarios.Run();
            //CustomSliceSectorColorsPieChart.Run();
            //DeleteRedundantSpacesWhileImportingFromHtml.Run();
            //DetectMergedCellsAndUnmerge.Run();
            //DisableCompatibilityChecker.Run();
            //WriteUsingLightCellsAPI.Run();
            //AbsolutePathOfExternalDataSourceFile.Run();
            //AddXmlMapInsideWorkbook.Run();
            //ApplyConditionalFormattingCellValue.Run();
            //ApplyConditionalFormattingFormula.Run();
            //SettingSubscriptEffect.Run();
            //SettingSuperscripteffect.Run();
            //ChangeTextBoxOrShapeCharacterSpacing.Run();
            //AssignAndValidateDigitalSignatures.Run();
            //ErrorCheckingOptions.Run();
            //ExportVisibleRowsData.Run();
            //ExtractImagesFromWorksheets.Run();
            //ExportXmlMapFromWorkbook.Run();
            //FindCellsWithSpecificStyle.Run();
            //FindIfCellValueStartsWithSingleQuote.Run();
            //FindQueryTablesAndListObjectsOfExternalDataConnections.Run();
            //FitAllWorksheetColumns.Run();
            //FormatPivotTableCells.Run();
            //FormatWorksheetCells.Run();
            //GenerateThumbnailOfWorksheet.Run();
            //GetIconSetsDataBars.Run();
            //HidingDisplayOfZeroValues.Run();
            //HtmlExportFrameScripts.Run();
            //IgnoreHiddenColumnsDataTable.Run();
            //Implement1904DateSystem.Run();
            //ImplementCustomCalculationEngine.Run();
            //InsertDeleteRows.Run();
            //ChartLegendEntry.Run();
            //CheckHiddenExternalLinks.Run();
            //CreateTransparentImage.Run();
            //CustomizingRibbonXML.Run();
            //CustomLabelsSubtotals.Run();
            //ImplementingNonSequencedRanges.Run();
            //InsertOleObject_WAVFile.Run();
            //InsertLinkedPicture.Run();
            //InsertPictureCellReference.Run();
            //LimitNumberOfPagesGenerated.Run();
            //LoadWebImage.Run();
            //MergeUnmergeRangeOfCells.Run();
            //SetBackgroundPicture.Run();
            //MoveRangeOfCells.Run();
            //ReadingCSVMultipleEncodings.Run();
            //LoadSpecificSheets.Run();
            //RemoveWhitespaceAroundData.Run();
            //RenderOnePdfPagePerExcelWorksheet.Run();
            //ResamplingAddedImages.Run();
            //SaveEachWorksheetToDifferentPDF.Run();
            //SearchReplaceDataInRange.Run();
            //SecurePDFDocuments.Run();
            //SetPixelFormatRenderedImage.Run();
            //SettingStrongEncryptionType.Run();
            //SettingScaleCropAndLinksUpToDateProperties.Run();
            //SetWorksheetTabColor.Run();
            //ShowFormulasInsteadOfValues.Run();
            //SortData.Run();
            //UpdateRichTextCells.Run();
            //UsePresentationPreferenceOption.Run();
            //UsingCustomXmlParts.Run();
            //UsingImageMarkersWhileGroupingDataInSmartMarkers.Run();
            //UsingWorkbookMetadata.Run();
            //RenderUnicodeInOutput.Run();
            //UpdateReferenceInWorksheets.Run();
            //SettingTextEffectsShadowOfShapeOrTextbox.Run();
            //ImplementDirectCalculationOfCustomFunction.Run();
            //FilterDataWhileLoadingWorkbook.Run();
            //FilteringObjects.Run();
            //CustomFilteringPerWorksheet.Run();
            //AddActiveXControls.Run();
            //LoadExcelFileWithoutChart.Run();
            //ExportToHTMLWithGridLines.Run();
            //DivTagsLayout.Run();
            //LoadWorkbookWithPrinterSize.Run();
            //CreateTextBoxWithDifferentHorizontalAlignment.Run();
            //SetTextboxOrShapeParagraphLineSpacing.Run();
            //UpdateActiveXComboBoxControl.Run();
            //FindDataPointsInPieBar.Run();
            //GetSetClassIdentifierEmbedOleObject.Run();
            //LoadWorkbookWithSpecificCultureInfoNumberFormat.Run();
            //LoadWorkbookWithSpecificCultureInfoDateFormat.Run();
            //ReflactionEffectOfShape.Run();
            //ShadowEffectOfShape.Run();
            //GlowEffectOfShape.Run();
            //Shape3DEffect.Run();
            //LinkCellsToXmlMapElements.Run();
            //PropagateFormulaInTable.Run();
            //AddWordArtTextWithBuiltinStyle.Run();
            //SetPresetWordArtStyle.Run();
            //GetWarningsForFontSubstitution.Run();
            //RemoveUnusedStyles.Run();
            //ReadingCellValuesInMultipleThreadsSimultaneously.TestMultiThreadingRead();
            //GetSmartMarkerNotifications.Run();
            //ReadUsingLightCellsApi.Run();
            //CustomTextForLabels.Run();
            //MINIFSAndMAXIFS.Run();
            //TotalsInOtherLanguages.Run();
            //UsingCellsFactory.Run();
            //ConvertingColumnChartToImage.Run();
            //ConvertingPieChartToImageFile.Run();
            //ConvertWorksheetToImageByPage.Run();
            //ConvertWorksheetToSVG.Run();
            //ConvertWorksheettoImageFile.Run();
            //DeletingBlankColumns.Run();
            //DeletingBlankRows.Run();
            //ExtractOLEObjects.Run();
            //GenerateDatabarImage.Run();
            //SetPictureBackGroundFillChart.Run();
            //CopyingMultipleColumns.Run();
            //CopyingMultipleRows.Run();
            //CopyingSingleRow.Run();
            //CopyingSingleColumn.Run();
            //CopyChart.Run();
            //CopyControls.Run();
            //CopyingPicture.Run();
            //CreatePivotChart.Run();
            //CreatePivotTableWithFormatting.Run();
            //UseExplicitLineBreaks.Run();
            //WrapText.Run();
            //AbsolutePositionOfShapeInsideWorksheet.Run();
            //AddWordArtWatermarkToChart.Run();
            //ChangeShapesAdjustmentValues.Run();
            //CopyShapesBetweenWorksheets.Run();
            //CopySparkline.Run();
            //CreateSignatureLineInWorkbook.Run();
            //DetermineAxisInChart.Run();
            //DisableTextWrappingForDataLabels.Run();
            //GetEquationTextOfChartTrendLine.Run();
            //GetWorksheetOfTheChart.Run();
            //RefreshValueOfLinkedShapes.Run();
            //ResizeChartDataLabelToFit.Run();
            //RichTextCustomDataLabel.Run();
            //ShowCellRangeAsDataLabels.Run();
            //GetDataConnection.Run();
            //ModifyingExistingDataConnection.Run();
            //ReadingAndWritingQueryTable.Run();
            //RetrievingSQLConnectionData.Run();
            //AccessTableFromCellAndAddValue.Run();
            //GetValidationAppliedOnCell.Run();
            //HowAndWhereToUseEnumerators.Run();
            //VerifyCellValidation.Run();
            //AssignMacroToFormControl.Run();
            //CheckVbaCodeIsSigned.Run();
            //CheckVbaProjectSigned.Run();
            //CheckVbaSignatureIsValid.Run();
            //DigitallySignVbaProjectWithCertificate.Run();
            //ExportVBACertificateToFile.Run();
            //ModifyingVBAOrMacroCode.Run();
            //AssignAndValidateDigitalSignatures.Run();
            //ChangeChartDataSource.Run();
            //CheckIfPasswordProtected.Run();
            //CheckPasswordToModify.Run();
            //ConvertXLSBToXLSM.Run();
            //CopyMoveWorksheets.Run();
            //DetectEmptyWorksheets.Run();
            //DetectFileFormatAndEncryption.Run();
            //EditingHyperlinksOfWorksheet.Run();
            //ImportCSVWithFormulas.Run();
            //ImportXmlData.Run();
            //VerifyPasswordUsedToProtectWorksheets.Run();
            //ModifyThroughSampleExcelFile.Run();
            //ModifyThroughStyleObject.Run();
            //ReadingLargeExcelFiles.Run();
            //WritingLargeExcelFiles.Run();
            //SettingPageSetup.Run();
            //SettingPrintingOptions.Run();
            //ChangingLayoutOfPivotTable.Run();
            //GetPivotTableCellByDisplayName.Run();
            //RemovePivotTable.Run();
            //SettingPivotTableOption.Run();
            //SpecifyAbsolutePositionOfPivotItem.Run();
            //ConvertChartToSvgImage.Run();
            //ExportChartToSvgWithViewBox.Run();
            //ExportHiddenWorksheetInHTML.Run();
            //PrintCommentWhileSavingToPdf.Run();
            //PrintingRangeOfPages.Run();
            //PrintingUsingSheetRender.Run();
            //PrintingUsingWorkbookRender.Run();
            //RenderWorksheetToGraphicContext.Run();
            //SaveExcelIntoPdfWithMinimumSize.Run();
            //SetCustomFontFolders.Run();
            //SpecifyJobWhilePrinting.Run();
            //WorksheetToImageDesiredSize.Run();
            //WorksheetToImageUsingTiffCompression.Run();
            //ApplyingSubtotalChangeSummaryDirection.Run();
            //ConvertStringToNumericValue.Run();
            //ExtractThemeData.Run();
            //RenderCustomDateFormat.Run();
            //RenderGradientFillToHTML.Run();
            //ImplementIStreamProvider.Run();
            //ExportedWorkSheetViaIFilePathProvider.Run();
            //ExpandTextFromRightToLeft.Run();
            //SpecificPagesToImage.Run();
            //UseWorkbookRenderForImageConversion.Run();
            //WorksheetToAnImage.Run();
            //AddWorkbookScopedNamedRange.Run();
            //WorksheetNamedRange.Run();
            //CalculationOfArrayFormula.Run();
            //DecreaseCalculationTime.Run();
            //SetExternalLinksInFormulas.Run();
            //SettingSharedFormula.Run();

            //_CellsHelper.IndexToName.Run();
            //_CellsHelper.MergeFiles.Run();
            //_CellsHelper.NameToIndex.Run();
            //_CellsHelper.NumberOfSignificantDigits.Run();
            //_CellsHelper.UsingCustomImplementationFactoryToCreateCustomImplementationOfMemoryStream.Run();
            //UsingSparklines.Run();
            //Applying3DFormat.Run();
            //ChangeChartSizeAndPosition.Run();
            //ChartRendering.Run();
            //ChartToPdf.Run();
            //HandleAutomaticUnitsOfChartAxisLikeMicrosoftExcel.Run();
            //HowToCreateChart.Run();
            //ReadManipulateExcel2016Charts.Run();
            //SetShapeTypeOfDataLabelsOfChart.Run();
            //SettingCategoryData.Run();
            //SettingChartsData.Run();
            //SetValuesFormatCodeOfChartSeries.Run();
            //AddingLabelControlInChart.Run();
            //AddingPictureInChart.Run();
            //AddingTextBoxControlInChart.Run();
            //HowToCreateBubbleChart.Run();
            //HowToCreateCustomChart.Run();
            //HowToCreateLineChart.Run();
            //HowToCreatePieChart.Run();
            //HowToCreatePyramidChart.Run();
            //MicrosoftThemeColorInChartSeries.Run();
            //ModifyLineChart.Run();
            //ModifyPieChart.Run();
            //ApplyingThemesInChart.Run();
            //ChangingMajorGridlinesInChart.Run();
            //MajorGridlinesOfChart.Run();

            //SettingChartArea.Run();
            //SettingChartLines.Run();
            //SettingTitlesAxes.Run();
            //AddingLinkToOtherSheetCell.Run();
            //AddingLinkToExternalFile.Run();
            //AddingLinkToURL.Run();
            //AddingLinkToURL2.Run();
            //MergingCellsInWorksheet.Run();
            //UnMergingtheMergedCells.Run();
            //AccessAllNamedRanges.Run();
            //AccessSpecificNamedRange.Run();
            //CopyNamedRanges.Run();
            //CreateNamedRangeofCells.Run();
            //FormatRanges1.Run();
            //FormatRanges2.Run();
            //IdentifyCellsInNamedRange.Run();
            //InputDataInCellsInRange.Run();
            //IntersectionOfRanges.Run();
            //RenameNamedRange.Run();
            //SetBorderAroundEachCell.Run();
            //UnionOfRanges.Run();
            //CalculatingSumUsingNamedRange.Run();
            //MergeCellsInNamedRange.Run();
            //RemoveNamedRange.Run();
            //SettingComplexFormulaOfRange.Run();

            //int ii = 0;

            //SettingSimpleFormulaWithRange.Run();
            //CheckCustomNumberFormat.Run();
            //AccessCellByRowAndColumnIndex.Run();
            //AccessCellUsingCellIndexInCellsCollection.Run();
            //AccessCellUsingCellName.Run();
            //AccessingMaximumDisplayRangeofWorksheet.Run();
            //FindCellsContainingFormula.Run();
            //FindCellsStringNumber.Run();
            //FindDataOrFormulas.Run();
            //FindingCellsContainingFormula.Run();
            //FindingCellsContainingStringValueOrNumber.Run();
            //FindingCellsWithStringOrNumber.Run();
            //FindingDataOrFormulasUsingFindOptions.Run();

            //Console.Write("Press key...");
            //Console.ReadKey();
            //return;


            //// CopyShapesBetweenWorksheets
            //// =====================================================
            // CopyChart.Run();
            //CopyControls.Run();
            //CopyingPicture.Run();

            //// CreatePivotTablesPivotCharts
            //// =====================================================
            //CreatePivotChart.Run();
            //Articles.CreatePivotTablesPivotCharts.CreatePivotTable.Run();

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

            //// WorkingWithHTMLFormat
            //// =====================================================
            //ExpandTextFromRightToLeft.Run();
            //ImplementIStreamProvider.Run();

            //// RenderingAndPrinting
            //// =====================================================
            //SetDefaultFontWhileRendering.Run();
            //SetDefaultFontWhileRenderingSpreadsheet.Run();
            //SetCustomFontFolders.Run();
            //PrintCommentWhileSavingToPdf.Run();
            //PrintingUsingSheetRender.Run();
            //PrintingUsingWorkbookRender.Run();
            //WorksheetToImageUsingTiffCompression.Run();
            //PreventExportingHiddenContent.Run();
            //PrintingRangeOfPages.Run();
            //ChangeFontUnicodeCharacterToPdf.Run();
            //SpecifyJobWhilePrinting.Run();
            //ExportChartToSvgWithViewBox.Run();
            //WorksheetToImageDesiredSize.Run();
            //RenderWorksheetToGraphicContext.Run();
            //SaveExcelIntoPdfWithOptimizedSize.Run();

            //// PageSetupAndPrintingOptions
            //// =====================================================
            //SettingPageSetup.Run();
            //SettingPrintingOptions.Run();

            //// UsingImageOrPrintOptions
            //// =====================================================
            //WorksheetToAnImage.Run();
            //SpecificPagesToImage.Run();
            //UseWorkbookRenderForImageConversion.Run();

            //// StylingAndDataFormatting
            //// =====================================================
            //ReusingStyleObjects.Run();
            //ConvertStringToNumericValue.Run();
            //CustomDecimalAndGroupSeparator.Run();
            //DisplayBulletsInCellUsingHtml.Run();
            //RenderCustomDateFormat.Run();
            //ApplyingSubtotalChangeSummaryDirection.Run();
            //ExtractThemeData.Run();

            //// PivotTablesAndPivotCharts
            //// =====================================================
            //ChangingLayoutOfPivotTable.Run();
            //SettingPivotTableOption.Run();
            //SpecifyAbsolutePositionOfPivotItem.Run();
            //RemovePivotTable.Run();
            //GetCellByDisplayName.Run();
            //CustomizePivotTableGlobalSettings.Run();

            //// WorkingWithCalculationEngine
            //// =====================================================
            //DecreaseCalculationTime.Run();
            //SettingSharedFormula.Run();
            //SetExternalLinksInFormulas.Run();
            //UsingICustomFunctionfeature.Run();
            //CalculateIFNAFunction.Run();
            //ReturnRangeOfValuesUsingICustomFunction.Run();
            //UsingFormulaTextFunction.Run();
            //CalculationOfArrayFormula.Run();
            //SettingFormulaCalculationModeWorkbook.Run();

            //// ManagingVBAModules
            //// =====================================================
            //ModifyingVBAOrMacroCode.Run();
            //AddVBAModuleOrCode.Run();
            //AssignMacroToFormControl.Run();
            //AddLibraryReferenceToVbaProject.Run();
            //CheckVbaProjectSigned.Run();
            //ExportVBACertificateToFile.Run();
            //CheckVbaCodeIsSigned.Run();
            //DigitallySignVbaProjectWithCertificate.Run();
            //CheckVbaSignatureIsValid.Run();

            //// ManageConditionalFormatting
            //// =====================================================
            //AddColorScales.Run();
            //ApplyShadingToAlternateRowsColumns.Run();
            //GenerateDatabarImage.Run();

            //// ManagingWorkbooksWorksheets
            //// =====================================================
            //ChangeChartDataSource.Run();
            //SetAutoRecovery.Run();
            //OdsFileSaveOptions.Run();
            //CheckPasswordToModify.Run();
            //DeterminingLicenseLoading.Run();
            //DetectFileFormatAndEncryption.Run();
            //ExportExcelDataToDataTableWithoutFormatting.Run();
            //ConvertXLSBToXLSM.Run();
            //CalculateScalingFactor.Run();
            //ReleaseUnmanagedResources.Run();
            //EditingHyperlinksOfWorksheet.Run();
            //ImportXmlData.Run();
            //ImportCSVWithFormulas.Run();
            //CheckIfPasswordProtected.Run();
            //VerifyPasswordUsedToProtectWorksheets.Run();
            //SearchDataUsingOriginalValues.Run();
            //DetectEmptyWorksheets.Run();
            //CopyMoveWorksheets.Run();
            //GetApplicationVersion.Run();

            //// ManagingRowsColumnsCells
            //// =====================================================
            //PopulateDataEfficiently.Run();
            //GetValidationAppliedOnCell.Run();
            //AddingHTMLRichTextInCell.Run();
            //AccessTableFromCellAndAddValue.Run();
            //GetStringValue.Run();
            //GetRowHeights.Run();
            //CalculateWidthAndHeight.Run();
            //HowAndWhereToUseEnumerators.Run();
            //VerifyCellValidation.Run();

            //// ManageChartsAndShapes
            //// =====================================================
            //RichTextCustomDataLabel.Run();
            //CopyShapesBetweenWorksheets.Run();
            //SetPictureBackGroundFillChart.Run();
            //AddWordArtWatermarkToChart.Run();
            //DisableTextWrappingForDataLabels.Run();
            //AbsolutePositionOfShapeInsideWorksheet.Run();
            //GetWorksheetOfTheChart.Run();
            //AddCustomLabelsToDataPoints.Run();
            //GetEquationTextOfChartTrendLine.Run();
            //RefreshValueOfLinkedShapes.Run();
            //ShowCellRangeAsDataLabels.Run();
            //DetermineAxisInChart.Run();
            //CreateSignatureLineInWorkbook.Run();
            //CreateWaterfallChart.Run();
            //LockingWordartWatermark.Run();
            //CreatePieChartWithLeaderLines.Run();
            //ChartSetupUsingSetChartDataRange.Run();
            //ChangeShapesAdjustmentValues.Run();
            //GenerateChartByProcessingSmartMarkers.Run();
            //CreateDynamicCharts.Run();
            //UsingDynamicFormula.Run();
            //ResizeChartDataLabelToFit.Run();
            //CopySparkline.Run();

            //// ManageDatabaseConnection
            //// =====================================================
            //GetDataConnection.Run();
            //RetrievingSQLConnectionData.Run();
            //ModifyingExistingDataConnection.Run();
            //ReadingAndWritingQueryTable.Run();

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
            // KnowledgeBase
            // =====================================================
            // =====================================================

            //// Benchmarking
            //// =====================================================
            //Creating50XLSFiles.Run();
            //CreateAnExcelFileFiveSheets.Run();
            //CreateAnExcelFileSingleWorksheet.Run();
            //LoadLargeExcelScenario1.Run();
            //LoadLargeExcelScenario2.Run();
            //LoadLargeExcelScenario3.Run();

            //// ComparingVSTOWithAspose
            //// =====================================================
            //UsingAsposeCells.Run();

            //// FAQs
            //// =====================================================
            //FixOutOfMemoryException.Run();
            //FileFormatInformation.Run();

            // =====================================================
            // =====================================================
            // Charts
            // =====================================================
            // =====================================================

            //Applying3DFormat.Run();
            //ChangeChartPosition.Run();
            //HowToCreateChart.Run();
            //SettingCategoryData.Run();
            //SettingChartsData.Run();
            //UsingSparklines.Run();
            //ChartRendering.Run();
            //ChartToPdf.Run();

            //// InsertingControlsintoCharts
            //// =====================================================
            //Charts.InsertingControlsintoCharts.AddingLabelControl.Run();
            //AddingPictureToChart.Run();
            //Charts.InsertingControlsintoCharts.AddingTextBoxControl.Run();

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
            //ChangingMajorGridlines.Run();
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
            //SettingSimpleFormula.Run();
            //SettingComplexFormula.Run();
            //CalculatingSumUsingNamedRange.Run();

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

            //AccessNonPrimitiveShape.Run();

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
            //OpeningTextFilewithCustomSeparator.Main();
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
            //EncryptingODSFiles.Run();
            //Excel2PDFConversion.Run();
            //AccessingDocumentProperties.Run();
            //AccessingValueOfDocumentProperties.Run();
            //AddingDocumentProperties.Run();
            //ConfigureLinktoContentDocumentProperty.Run();
            //RemovingCustomProperties.Run();
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
            //SpecifyCompatibility.Run();

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
            //SetColumnWidthInPixels.Run();

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
            //CopyStyleWithSmartMarker.Run();
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

        public static string Get_SourceDirectory()
        {
            return Path.GetFullPath("..\\..\\..\\Data\\01_SourceDirectory\\");
        }

        public static string Get_OutputDirectory()
        {
            return Path.GetFullPath("..\\..\\..\\Data\\02_OutputDirectory\\");
        }
    }
}
