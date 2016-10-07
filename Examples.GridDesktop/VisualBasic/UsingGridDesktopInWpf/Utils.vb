Imports System.IO

Public Class Utils
    Public Shared Function GetDataDir(t As Type) As String
        Dim retDir As String = Nothing
        Dim parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent
        Dim startDirectory As String = Nothing
        If parent IsNot Nothing Then
            Dim directoryInfo = parent.Parent
            If directoryInfo IsNot Nothing Then
                startDirectory = directoryInfo.FullName
            End If
            retDir = Path.Combine(Path.GetFullPath(Path.Combine(startDirectory, "..\")), "Data\") + parent.Name

            If Not Directory.Exists(retDir) Then
                Directory.CreateDirectory(retDir)
            End If
        Else
            retDir = parent.FullName
        End If
        Return retDir & Convert.ToString("\")
    End Function
End Class
