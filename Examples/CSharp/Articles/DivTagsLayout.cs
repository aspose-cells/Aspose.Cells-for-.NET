using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class DivTagsLayout
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // ExStart:1
            var export_html = @"<html>
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
            export_html = export_html + " <img src=\"" + sourceDir + "sampleDivTagsLayout_ASpose_logo_100x100.png\"" + @" />
                                               
                                            </td>
                                        </tr>
                                    </table>
                                </body>
                                </html>";

            MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(export_html));

            // Specify HTML load options, support div tag layouts
            Aspose.Cells.HtmlLoadOptions loadOptions = new HtmlLoadOptions(LoadFormat.Html);
            loadOptions.SupportDivTag = true;

            // Create workbook object from the html using load options
            Workbook wb = new Workbook(ms, loadOptions);

            // Auto fit rows and columns of first worksheet
            Worksheet ws = wb.Worksheets[0];
            ws.AutoFitRows();
            ws.AutoFitColumns();

            // Save the workbook in xlsx format
            wb.Save(outputDir + "outputDivTagsLayout.xlsx", Aspose.Cells.SaveFormat.Xlsx);
            // ExEnd:1

            Console.WriteLine("DivTagsLayout executed successfully.");
        }
    }
}
