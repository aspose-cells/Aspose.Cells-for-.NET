Imports System.IO
Imports Aspose.Cells

Namespace Articles
    Public Class DivTagsLayout
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim export_html = vbCr & vbLf & "                                <html>" & vbCr & vbLf & "                                <body>" & vbCr & vbLf & "                                    <table>" & vbCr & vbLf & "                                        <tr>" & vbCr & vbLf & "                                            <td>" & vbCr & vbLf & "                                                <div>This is some Text.</div>" & vbCr & vbLf & "                                                <div>" & vbCr & vbLf & "                                                    <div>" & vbCr & vbLf & "                                                        <span>This is some more Text</span>" & vbCr & vbLf & "                                                    </div>" & vbCr & vbLf & "                                                    <div>" & vbCr & vbLf & "                                                        <span>abc@abc.com</span>" & vbCr & vbLf & "                                                    </div>" & vbCr & vbLf & "                                                    <div>" & vbCr & vbLf & "                                                        <span>1234567890</span>" & vbCr & vbLf & "                                                    </div>" & vbCr & vbLf & "                                                    <div>" & vbCr & vbLf & "                                                        <span>ABC DEF</span>" & vbCr & vbLf & "                                                    </div>" & vbCr & vbLf & "                                                </div>" & vbCr & vbLf & "                                                <div>Generated On May 30, 2016 02:33 PM <br />Time Call Received from Jan 01, 2016 to May 30, 2016</div>" & vbCr & vbLf & "                                            </td>" & vbCr & vbLf & "                                            <td>"
            export_html = (Convert.ToString(export_html + " <img src=") & dataDir) + "ASpose_logo_100x100.png" + " />" & vbCr & vbLf & "                                               " & vbCr & vbLf & "                                            </td>" & vbCr & vbLf & "                                        </tr>" & vbCr & vbLf & "                                    </table>" & vbCr & vbLf & "                                </body>" & vbCr & vbLf & "                                </html>"

            Using ms As New MemoryStream(System.Text.Encoding.UTF8.GetBytes(export_html))
                ' Specify HTML load options, support div tag layouts
                Dim loadOptions As Aspose.Cells.HTMLLoadOptions = New HTMLLoadOptions(LoadFormat.Html)
                loadOptions.SupportDivTag = True

                ' Create workbook object from the html using load options
                Dim wb As New Workbook(ms, loadOptions)

                ' Auto fit rows and columns of first worksheet
                Dim ws As Worksheet = wb.Worksheets(0)
                ws.AutoFitRows()
                ws.AutoFitColumns()

                ' Save the workbook in xlsx format
                wb.Save(dataDir & Convert.ToString("DivTagsLayout_out.xlsx"), Aspose.Cells.SaveFormat.Xlsx)
            End Using
            ' ExEnd:1                        
        End Sub
    End Class
End Namespace
