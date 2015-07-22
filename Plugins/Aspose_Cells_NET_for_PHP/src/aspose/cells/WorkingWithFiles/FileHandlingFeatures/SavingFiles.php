<?php
/**
 * Created by PhpStorm.
 * User: assadmahmood
 * Date: 21/07/15
 * Time: 5:00 PM
 */

namespace Aspose\Cells\WorkingWithFiles\FileHandlingFeatures;


class SavingFiles {

    public static function run($dataDir=null)
    {
        if(is_null($dataDir)) die("Data Directory Undefined");

        // Create Aspose.Cells Helper Object
        $ptr = new \COM('Aspose.Cells.Interop.InteropHelper');

        // Opening through Path
        // Creating a Workbook object and opening an Excel file using its file path

        $workbook = $ptr->New("Aspose.Cells.Workbook",array());

        //Your Code goes here for any workbook related operations
        $ptr->Call($workbook,"Save",array($dataDir.'/book1.xls'));
        print "File saved successfully!" . PHP_EOL;
    }

} 