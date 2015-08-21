# Aspose-Cells-Net-for-PHP
Project Aspose.Cells .NET for PHP shows how different tasks can be performed using Aspose.Cells .NET APIs in PHP. This project is aimed to provide useful examples for PHP Developers who want to utilise Aspose.Cells for .nET in their PHP Projects.

### System Requirements
* IIS with PHP and PHP Manager installed.
* Aspose.Total APIs.
* Aspose.Cells the Interop dll and tlb file.

### Supported Platforms
* PHP 5.3 or above
* Windows OS

### How to configure the source code on Windows Platform
#### 1. Register both dll and interop.dll files e.g. Aspose.Cells.dll and Aspose.Cells.Interop.dll.
Register both dll and interop.dll files e.g. Aspose.Cells.dll and Aspose.Cells.Interop.dll.
C:\Windows\Microsoft.NET\Framework\v2.0.50727>regasm c:\cells\Aspose.Cells.dll /codebase
Microsoft (R) .NET Framework Assembly Registration Utility 2.0.50727.7905
Copyright (C) Microsoft Corporation 1998-2004. All rights reserved.
Types registered successfully
C:\Windows\Microsoft.NET\Framework\v2.0.50727>regasm c:\cells\Aspose.Cells.Interop.dll /codebase

#### 2. Enable COM and DOTNET Extensions in PHP
In IIS open PHP Manager and then Click ‘Enable to Disable and Extension‘. Find php_com_dotnet.dll and make sure it is enabled.

#### 3. Configure Aspose.Cells Java for PHP Examples
* Clone the Repository
```
git clone git@github.com:asposemarketplace/Aspose_Cells_Net_for_PHP.git
```
* Setup the project using composer
```
composer install
```

Read more about composer on http://www.getcomposer.com
