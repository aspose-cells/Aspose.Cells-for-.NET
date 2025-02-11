description 
==================================


[Product Page](https://products.aspose.com/cells/net) | [Docs](https://docs.aspose.com/cells/net/aspose-cells-gridjs/) | [API Reference](https://reference.aspose.com/cells/net/aspose.cells.gridjs/) | [Demos](https://products.aspose.app/cells/family/) | [Blog](https://blog.aspose.com/category/cells/) | [Code Samples](https://github.com/aspose-cells/Aspose.Cells-for-.NET/tree/master/Examples_GridJs) | [Free Support](https://forum.aspose.com/c/cells) | [Temporary License](https://purchase.aspose.com/temporary-license) | [EULA](https://company.aspose.com/legal/eula) 

Try our [free online apps](https://products.aspose.app/cells/family) demonstrating some of the most popular Aspose.Cells functionality.

This is a  demo to show how we can use GridJs to implment a spreadsheet Editor.

## Step by step to run the demo
Edit the properties in `Models/TestConfig.cs` to match your enviroment.

If you want to use Amazon Storage Service, edit the properties in AwsConfig class in TestConfig.cs.

In Startup.cs check if you need to do some initialization work.

Build the project and run.

It shall be started at http://localhost:24262/GridJs2/List

If you have any questions or need help,

please feedback to the following website https://forum.aspose.com/c/cells/9 

## Step to run in docker 

1. docker build -t gridjs-demo-net6 .

2. run with aspose license file:

      docker run -d -p 24262:80  -v C:/path/to/license.txt:/app/license gridjs-demo-net6
	  
   or just run the demo in trial mode:
   
      docker run -d -p 24262:80 gridjs-demo-net6

3. open browser and enter the url:http://localhost:24262/GridJs2/List


## Reference js lib used in the demo project:
jquery.js    v2.1.1

jquery-ui.js v1.12.1 

jquery-ui.css v1.12.1 

jszip.min.js v3.6.0 

bootstrap.css   v22.5.5.2

quantumui.css   v22.5.5.2

