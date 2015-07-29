<?php
/**
 * Created by PhpStorm.
 * User: assadmahmood
 * Date: 29/07/15
 * Time: 5:25 PM
 */

namespace Aspose\Cells\WorkingwithFormulas;


class CalculatingFormulas {

    public static function run($dataDir=null)
    {
        if(is_null($dataDir)) die("Data Directory Undefined");

        // Create Aspose.Cells Helper Object
        $ptr = new \COM('Aspose.Cells.Interop.InteropHelper');

        // Opening through Path
        // Creating a Workbook object and opening an Excel file using its file path

        $workbook = $ptr->New("Aspose.Cells.Workbook",array());
        $worksheets = $ptr->Get($workbook,"Worksheets",array());
        $sheetIndex = $ptr->Call($worksheets,"Add",array());
        $worksheet = $ptr->Get($worksheets,"Item",array($sheetIndex));
        $cells = $ptr->Get($worksheet,"Cells",array());
        $a1 = $ptr->Get($cells,"Item_3",array("A1"));
        $ptr->Call($a1,"PutValue",array(1));

        $a2 = $ptr->Get($cells,"Item_3",array("A2"));
        $ptr->Call($a2,"PutValue",array(2));

        $a3 = $ptr->Get($cells,"Item_3",array("A3"));
        $ptr->Call($a3,"PutValue",array(3));

        $a4 = $ptr->Get($cells,"Item_3",array("A4"));
        $ptr->Call($a3,"PutValue",array(3));

        $ptr->Call($workbook,"Save",array($dataDir."/output.xls"));
        $ptr->Set($a4,"Formula","=SUM(A1:A3)",array());

        $ptr->Call($workbook,"CalculateFormula",array());

        $value = $ptr->Get($a4,"Value",array());
        $stringVal = $ptr->Call($value,"ToString",array());
        print "Calculated Value: " . $stringVal . PHP_EOL;

        $ptr->Call($workbook,"Save",array($dataDir."/output.xls"));

        print "Completed." . PHP_EOL;
    }

} 