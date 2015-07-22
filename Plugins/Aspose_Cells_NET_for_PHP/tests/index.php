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

print "Running Aspose\\Cells\\WorkingWithFiles\\FileHandlingFeatures\\OpeningFiles::run()" . PHP_EOL;
OpeningFiles::run(__DIR__ . '/data/WorkingWithFiles/FileHandlingFeatures/OpeningFiles');

print "Running Aspose\\Cells\\WorkingWithFiles\\FileHandlingFeatures\\SavingFiles::run()" . PHP_EOL;
SavingFiles::run(__DIR__ . '/data/WorkingWithFiles/FileHandlingFeatures/SavingFiles');