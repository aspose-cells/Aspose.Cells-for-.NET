<?php
/**
 * Created by PhpStorm.
 * User: assadmahmood
 * Date: 29/07/15
 * Time: 2:22 PM
 */

namespace Aspose\Cells\WorkingWithFiles\UtilityFeatures;


class ManagingDocumentProperties {

    public static function run($dataDir=null)
    {
        if(is_null($dataDir)) die("Data Directory Undefined");

        // Create Aspose.Cells Helper Object
        $ptr = new \COM('Aspose.Cells.Interop.InteropHelper');

        // Opening through Path
        // Creating a Workbook object and opening an Excel file using its file path

        $workbook = $ptr->New("Aspose.Cells.Workbook",array($dataDir . '/Book1.xls'));
        $worksheets = $ptr->Get($workbook,"Worksheets",array());
        //Retrieve a list of all custom document properties of the Excel file
        $customDocProp = $ptr->Get($worksheets,"CustomDocumentProperties",array());
        //Accessing a custom document property by using the property index
        $customProp1 = $ptr->Get($customDocProp,"Item_2",array(3));
        //Accessing a custom document property by using the property name
        $customProp2 = $ptr->Get($customDocProp,"Item",array("Owner"));

        print $ptr->Get($customProp1,"Name",array()) . " -> " . $ptr->Get($customProp1,"Value",array()) . PHP_EOL;
        print $ptr->Get($customProp2,"Name",array()) . " -> " . $ptr->Get($customProp2,"Value",array()) . PHP_EOL;

        //Retrieve a list of all custom document properties of the Excel file
        $customDocPropColl = $ptr->Get($worksheets,"CustomDocumentProperties",array());

        //Adding a custom document property to the Excel file
        $publisher = $ptr->Call($customDocPropColl,"Add",array("Publisher","Aspose"));

        //Add link to content.
        $ptr->Call($customDocPropColl,"AddLinkToContent",array("Owner","MyRange"));

        //Accessing the custom document property by using the property name
        $customProp3 = $ptr->Get($customDocPropColl,"Item",array("Owner"));

        //Check whether the property is lined to content
        $isLinkedToContent = $ptr->Get($customProp3,"IsLinkedToContent",array());

        //Get the source for the property
        $source = $ptr->Get($customProp3,"Source",array());

        //Save the file with added properties
        $ptr->Call($workbook,"Save",array($dataDir . "/Test_Workbook.xls"));

        //Removing a custom document property
        $ptr->Call($customDocProp,"Remove",array("Publisher"));

        //Save the file with added properties
        $ptr->Call($workbook,"Save",array($dataDir . "/Test_Workbook_RemovedProperty.xls"));

    }

} 