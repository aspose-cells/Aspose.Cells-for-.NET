<?php
/**
 * Created by PhpStorm.
 * User: assadmahmood
 * Date: 29/07/15
 * Time: 3:28 PM
 */

namespace Aspose\Cells\WorkingWithFiles\UtilityFeatures;


class EncryptingFiles {

    public static function run($dataDir=null)
    {
        if(is_null($dataDir)) die("Data Directory Undefined");

        // Create Aspose.Cells Helper Object
        $ptr = new \COM('Aspose.Cells.Interop.InteropHelper');

        // Opening through Path
        // Creating a Workbook object and opening an Excel file using its file path

        $workbook = $ptr->New("Aspose.Cells.Workbook",array($dataDir . '/Book1.xls'));

        $XOR = $ptr->New("Aspose.Cells.EncryptionType.XOR",array());
        $crypt = $ptr->New("Aspose.Cells.EncryptionType.StrongCryptographicProvider",array());

        $ptr->Call($workbook,"SetEncryptionOptions",array($XOR,40));
        $ptr->Call($workbook,"SetEncryptionOptions",array($crypt,128));

        $settings = $ptr->Get($workbook,"Settings",array());
        $ptr->Set($settings,"Password","1234",array());

        $ptr->Call($workbook,"Save",array($dataDir."/encryptedoutBook1.xls"));

        print "Completed." . PHP_EOL;
    }

} 