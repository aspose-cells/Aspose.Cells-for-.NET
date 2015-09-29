<?php
/**
 * Created by PhpStorm.
 * User: assadmahmood
 * Date: 21/07/15
 * Time: 4:14 PM
 */

namespace Aspose\Cells\WorkingWithFiles\FileHandlingFeatures;


class OpeningFiles {

    public static function run($dataDir=null)
    {
        if(is_null($dataDir)) die("Data Directory Undefined");

        // Create Aspose.Cells Helper Object
        $ptr = new \COM('Aspose.Cells.Interop.InteropHelper');

        // Opening through Path
        // Creating a Workbook object and opening an Excel file using its file path

        $workbook = $ptr->New("Aspose.Cells.Workbook",array($dataDir . '/Book1.xls'));
        $worksheets = $ptr->Get($workbook,"Worksheets",array());
        print "Workbook opened using path successfully!" . PHP_EOL;
    }
} 