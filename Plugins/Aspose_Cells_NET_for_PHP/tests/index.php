<?php
/**
 * Created by PhpStorm.
 * User: assadmahmood
 * Date: 21/07/15
 * Time: 4:23 PM
 */

require_once __DIR__ . '/../vendor/autoload.php'; // Autoload files using Composer autoload

use Aspose\Cells\WorkingWithFiles\FileHandlingFeatures\OpeningFiles;
use Aspose\Cells\WorkingWithFiles\FileHandlingFeatures\SavingFiles;
use Aspose\Cells\WorkingWithFiles\UtilityFeatures\WorksheetToImage;
use Aspose\Cells\WorkingWithFiles\UtilityFeatures\ManagingDocumentProperties;
use Aspose\Cells\WorkingWithFiles\UtilityFeatures\Excel2PDFConversion;
use Aspose\Cells\WorkingWithFiles\UtilityFeatures\EncryptingFiles;
use Aspose\Cells\WorkingWithWorksheets\ManagementFeatures\ManagingWorksheets\AddWorksheetsToExistingExcelFile;
use Aspose\Cells\WorkingWithWorksheets\ManagementFeatures\ManagingWorksheets\AddingWorksheetsToNewExcelFile;
use Aspose\Cells\WorkingWithWorksheets\ManagementFeatures\ManagingWorksheets\RemovingWorksheetsUsingSheetIndex;
use Aspose\Cells\WorkingWithWorksheets\ManagementFeatures\ManagingWorksheets\RemovingWorksheetsUsingSheetName;
use Aspose\Cells\WorkingwithFormulas\CalculatingFormulas;

print "Running Aspose\\Cells\\WorkingWithFiles\\FileHandlingFeatures\\OpeningFiles::run()" . PHP_EOL;
OpeningFiles::run(__DIR__ . '/data/WorkingWithFiles/FileHandlingFeatures/OpeningFiles');

print "Running Aspose\\Cells\\WorkingWithFiles\\FileHandlingFeatures\\SavingFiles::run()" . PHP_EOL;
SavingFiles::run(__DIR__ . '/data/WorkingWithFiles/FileHandlingFeatures/SavingFiles');

print "Running Aspose\\Cells\\WorkingWithFiles\\UtilityFeatures\\WorksheetToImage::run()" . PHP_EOL;
WorksheetToImage::run(__DIR__ . '/data/WorkingWithFiles/UtilityFeatures/WorksheetToImage');

print "Running Aspose\\Cells\\WorkingWithFiles\\UtilityFeatures\\ManagingDocumentProperties::run()" . PHP_EOL;
ManagingDocumentProperties::run(__DIR__ . '/data/WorkingWithFiles/UtilityFeatures/ManagingDocumentProperties');

print "Running Aspose\\Cells\\WorkingWithFiles\\UtilityFeatures\\Excel2PDFConversion::run()" . PHP_EOL;
Excel2PDFConversion::run(__DIR__ . '/data/WorkingWithFiles/UtilityFeatures/Excel2PDFConversion');

print "Running Aspose\\Cells\\WorkingWithFiles\\UtilityFeatures\\EncryptingFiles::run()" . PHP_EOL;
EncryptingFiles::run(__DIR__ . '/data/WorkingWithFiles/UtilityFeatures/EncryptingFiles');

print "Running Aspose\\Cells\\WorkingWithWorksheets\\ManagementFeatures\\ManagingWorksheets\\AddWorksheetsToExistingExcelFile::run()" . PHP_EOL;
AddWorksheetsToExistingExcelFile::run(__DIR__ . '/data/WorkingWithWorksheets/ManagementFeatures/ManagingWorksheets/AddWorksheetsToExistingExcelFile');

print "Running Aspose\\Cells\\WorkingWithWorksheets\\ManagementFeatures\\ManagingWorksheets\\AddingWorksheetsToNewExcelFile::run()" . PHP_EOL;
AddingWorksheetsToNewExcelFile::run(__DIR__ . '/data/WorkingWithWorksheets/ManagementFeatures/ManagingWorksheets/AddingWorksheetsToNewExcelFile');

print "Running Aspose\\Cells\\WorkingWithWorksheets\\ManagementFeatures\\ManagingWorksheets\\RemovingWorksheetsUsingSheetIndex::run()" . PHP_EOL;
RemovingWorksheetsUsingSheetIndex::run(__DIR__ . '/data/WorkingWithWorksheets/ManagementFeatures/ManagingWorksheets/RemovingWorksheetsUsingSheetIndex');

print "Running Aspose\\Cells\\WorkingWithWorksheets\\ManagementFeatures\\ManagingWorksheets\\RemovingWorksheetsUsingSheetName::run()" . PHP_EOL;
RemovingWorksheetsUsingSheetName::run(__DIR__ . '/data/WorkingWithWorksheets/ManagementFeatures/ManagingWorksheets/RemovingWorksheetsUsingSheetName');

print "Running Aspose\\Cells\\WorkingwithFormulas\\CalculatingFormulas::run()" . PHP_EOL;
CalculatingFormulas::run(__DIR__ . '/data/WorkingwithFormulas/CalculatingFormulas');