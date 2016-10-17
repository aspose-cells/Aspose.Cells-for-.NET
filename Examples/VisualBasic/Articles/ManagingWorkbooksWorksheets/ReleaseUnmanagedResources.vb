Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class ReleaseUnmanagedResources
        Public Shared Sub Run()
            ' ExStart:ReleaseUnmanagedResourcesForWorkbooks
            ' Create workbook object
            Dim wb1 As New Workbook()

            ' Call Dispose method
            wb1.Dispose()

            ' Call Dispose method via Using statement
            ' Any other code goes here
            Using wb2 As New Workbook()
            End Using
            ' ExEnd:ReleaseUnmanagedResourcesForWorkbooks
        End Sub
    End Class
End Namespace