Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class CustomizingRibbonXML
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim wb As New Workbook(dataDir & "aspose-sample.xlsx")
            Dim fi As New FileInfo(dataDir & "CustomUI.xml")
            Dim sr As StreamReader = fi.OpenText()
            wb.RibbonXml = sr.ReadToEnd()
            sr.Close()


        End Sub
    End Class
End Namespace