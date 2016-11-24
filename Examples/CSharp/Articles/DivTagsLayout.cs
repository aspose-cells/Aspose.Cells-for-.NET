using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class DivTagsLayout
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            var export_html = @"
                                <html>
                                <body>
                                    <table>
                                        <tr>
                                            <td>
                                                <div>This is some Text.</div>
                                                <div>
                                                    <div>
                                                        <span>This is some more Text</span>
                                                    </div>
                                                    <div>
                                                        <span>abc@abc.com</span>
                                                    </div>
                                                    <div>
                                                        <span>1234567890</span>
                                                    </div>
                                                    <div>
                                                        <span>ABC DEF</span>
                                                    </div>
                                                </div>
                                                <div>Generated On May 30, 2016 02:33 PM <br />Time Call Received from Jan 01, 2016 to May 30, 2016</div>
                                            </td>
                                            <td>";
            export_html = export_html + " <img src=" + dataDir + "ASpose_logo_100x100.png" + @" />
                                               
                                            </td>
                                        </tr>
                                    </table>
                                </body>
                                </html>";

            using (MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(export_html)))
            {
                // Specify HTML load options, support div tag layouts
                Aspose.Cells.HTMLLoadOptions loadOptions = new HTMLLoadOptions(LoadFormat.Html);
                loadOptions.SupportDivTag = true;

                // Create workbook object from the html using load options
                Workbook wb = new Workbook(ms, loadOptions);

                // Auto fit rows and columns of first worksheet
                Worksheet ws = wb.Worksheets[0];
                ws.AutoFitRows();
                ws.AutoFitColumns();

                // Save the workbook in xlsx format
                wb.Save(dataDir + "DivTagsLayout_out.xlsx", Aspose.Cells.SaveFormat.Xlsx);
            }
            // ExEnd:1                        
        }
    }
}
