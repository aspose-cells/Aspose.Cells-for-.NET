<?php
/**
 * Created by PhpStorm.
 * User: assadmahmood
 * Date: 29/07/15
 * Time: 4:16 PM
 */

namespace Aspose\Cells\WorkingWithWorksheets\ManagementFeatures\ManagingWorksheets;


class RemovingWorksheetsUsingSheetIndex {

    public static function run($dataDir=null)
    {
        if(is_null($dataDir)) die("Data Directory Undefined");

        // Create Aspose.Cells Helper Object
        $ptr = new \COM('Aspose.Cells.Interop.InteropHelper');

        // Opening through Path
        // Creating a Workbook object and opening an Excel file using its file path

        $workbook = $ptr->New("Aspose.Cells.Workbook",array($dataDir . '/book1.xls'));
        $worksheets = $ptr->Get($workbook,"Worksheets",array());
        $ptr->Call($worksheets,"RemoveAt",array(0));
        $ptr->Call($workbook,"Save",array($dataDir."/output.xls"));

        print "Completed." . PHP_EOL;
    }

} 