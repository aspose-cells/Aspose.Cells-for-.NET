Imports System.IO

Class MainWindow

    Private Sub FrameworkElement_OnLoaded(sender As System.Object, e As System.Windows.RoutedEventArgs)
        ' ExStart:UsingGridDesktopInWpf
        ' The path to the documents directory.
        Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

        Using stream = New MemoryStream(File.ReadAllBytes(dataDir & Convert.ToString("SampleBook.xlsx")))
            Me.grid.ImportExcelFile(stream)
            Me.grid.ExportExcelFile(dataDir & Convert.ToString("SampleOutput_out_.xlsx"))
        End Using
        ' ExEnd:UsingGridDesktopInWpf
    End Sub

End Class
