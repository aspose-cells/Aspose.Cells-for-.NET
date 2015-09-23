<?php
/**
 * Created by PhpStorm.
 * User: assadmahmood
 * Date: 29/07/15
 * Time: 12:19 PM
 */

namespace Aspose\Cells\WorkingWithFiles\UtilityFeatures;


class WorksheetToImage {

    public static function run($dataDir=null)
    {
        if(is_null($dataDir)) die("Data Directory Undefined");

        // Create Aspose.Cells Helper Object
        $ptr = new \COM('Aspose.Cells.Interop.InteropHelper');

        // Opening through Path
        // Creating a Workbook object and opening an Excel file using its file path

        $workbook = $ptr->New("Aspose.Cells.Workbook",array($dataDir . '/MyTestBook1.xls'));
        $worksheets = $ptr->Get($workbook,"Worksheets",array());
        $sheet = $ptr->Get($worksheets,'Item',array(0));

        $imgOptions = $ptr->New("Aspose.Cells.Rendering.ImageOrPrintOptions",array());
        $imageFormat = new \DOTNET('mscorlib', 'System.Drawing.Imaging.ImageFormat');
        $ptr->Set($imgOptions,'ImageFormat',$imageFormat->Jpeg,array());
        $ptr->Set($imgOptions,'OnePagePerSheet',true,array());

        $sr = $ptr->New("Aspose.Cells.Rendering.SheetRender",array($sheet,$imgOptions));
        $bitmap = new \DOTNET("mscorlib", "System.Drawing.Bitmap");

        $bitmap->Save($dataDir . "./SheetImage.jpg");

        print "Conversion to Image(s) completed!" . PHP_EOL;
    }

} 