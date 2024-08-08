# Examples of Aspose.Cells.GridWeb in .Net6


* GridWeb.Net6 examples has two kinds of project files  **GridWeb.Demo.NET6.0.csproj** for linux and **GridWeb.Demo.NET6.0.windows.csproj** for windows.
* Open the  project file in Visual Studio and build the project.
* All dependencies are included via nuget package reference in the examples project. 

## GridWeb .net6 develop guide:
### 0. add package reference in project file
     for windows:

    <PackageReference Include="System.Text.Encoding.CodePages" Version="4.7.0" />
    <PackageReference Include="System.Security.Cryptography.Pkcs" Version="6.0.3" />
    <PackageReference Include="System.Drawing.Common" Version="7.0.0" />
    <PackageReference Include="Aspose.Cells.GridWeb" Version="24.8.0" />

    for linux:

     <PackageReference Include="System.Text.Encoding.CodePages" Version="4.7.0" />
     <<PackageReference Include="System.Security.Cryptography.Pkcs" Version="6.0.3" />
     <<PackageReference Include="SkiaSharp.NativeAssets.Linux.NoDependencies" Version="2.88.8" />
     <<PackageReference Include="Aspose.Cells.GridWeb" Version="24.8.0" />
    

### 1. Views\_viewimport.cs
add required packages:
~~~c#
@using Aspose.Cells.GridWeb
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@addTagHelper *, Aspose.Cells.GridWeb
~~~

### 2. Config:
edit Models/TestConfig.cs ,update the acutal path to match with your enviroment
~~~c#
public class TestConfig
    {
        /// <summary>
        /// the directory which contains workbook files
        /// </summary>
        internal static String File = "/app/wb/test.xlsx";
        /// <summary>
        /// temp directory to store file cache
        /// </summary>
        internal static String TempDir = "/app/filecache";
        /// <summary>
        /// temp directory to store picture cache
        /// </summary>
        internal static String PicDir = "/app/piccache";
    }
~~~
### 3. Controller:
put the below code in your desired controller (etc. Controllers/GridController.cs) to load gridweb view:
~~~c#           
             //set the session store path
            Aspose.Cells.GridWeb.GridWeb.SessionStorePath = TestConfig.TempDir;
            Aspose.Cells.GridWeb.GridWeb mw = new Aspose.Cells.GridWeb.GridWeb();
            mw.ID = "gid";
            mw.SetSession(HttpContext.Session);
            //set acw_client path
            mw.ResourceFilePath = "/js/acw_client/";
            //set the picture cache ,you need to create this directory
            mw.PictureCachePath = TestConfig.PicDir;
            mw.EnableAsync = true;
            //load workbook
            String file = TestConfig.File;
            mw.ImportExcelFile(file);
            mw.ActiveSheet.Cells["B1"].PutValue("version:");
            mw.ActiveSheet.Cells["C1"].PutValue(Aspose.Cells.GridWeb.GridWeb.GetVersion());

            //set width height
            mw.Width = Unit.Pixel(800);
            mw.Height = Unit.Pixel(500);
            return View(mw);
~~~

### 4. Viewer 
Views\Grid\index1.cshtml:
add:
~~~html
<script src="~/js/acw_client/acwmain.js" asp-append-version="true"></script>
<script src="~/js/acw_client/lang_en.js" asp-append-version="true"></script>
<link href="~/js/acw_client/menu.css" rel="stylesheet" type="text/css">
~~~
or just use npm js reference:
~~~html
<script type="text/javascript" language="javascript"
	src="https://unpkg.com/gridweb-spreadsheet@24.8.0/acw_client/acwmain.js?t=202209"></script>
<script type="text/javascript" language="javascript"
	src="https://unpkg.com/gridweb-spreadsheet@24.8.0/acw_client/lang_en.js"></script>
<link href="https://unpkg.com/gridweb-spreadsheet@24.8.0/acw_client/menu.css" rel="stylesheet"
	type="text/css" />
~~~

~~~c#
@model GridWeb
<GridWebDiv mw=Model ></GridWebDiv>
~~~
 
### 5. Service
1.add session support 

2.add  GridScheduedService (optional, GridScheduedService will delete temporary files two days ago in the GridWeb.SessionStorePath )

 startup.cs:
 in ConfigureServices method:
~~~c#
         services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
           //config for GridScheduedService is optional
            services.AddSingleton<Microsoft.Extensions.Hosting.IHostedService, GridScheduedService>();
~~~
in Configure method
~~~c#
app.UseSession();
~~~ 

### 6. put latest acw_client in directory: wwwroot/js
You can find it from https://www.npmjs.com/package/gridweb-spreadsheet

### 7. add   acw route map in your Controller,which can provide all the  operations for general edit action.
   Check the example in Controllers/GridController.cs
~~~c#
        [HttpGet("acw/{type}/{id}")]
        [HttpPost("acw/{type}/{id}")]
        public IActionResult Operation(string type, string id)
        {
            return Aspose.Cells.GridWeb.AcwController.DoAcwAction(this, type, id);
        }
~~~ 

 


### 8.dependency js/css lib references in the demo project:
 
| name        | version    |  
| --------   | -----:   | 
| jquery.js        |  v2.1.1     |  
| jquery-ui.js       | v1.12.1    |    
| jquery-ui.css        |  v1.12.1      |  

[Home](https://www.aspose.com/) | [Product Page](https://products.aspose.com/cells/net) | [Docs](https://docs.aspose.com/cells/net/) | [Demos](https://products.aspose.app/cells/family) | [API Reference](https://apireference.aspose.com/cells/net) | [Examples](https://github.com/aspose-cells/Aspose.Cells-for-.NET) | [Blog](https://blog.aspose.com/category/cells/) | [Free Support](https://forum.aspose.com/c/cells) |  [Temporary License](https://purchase.aspose.com/temporary-license)
