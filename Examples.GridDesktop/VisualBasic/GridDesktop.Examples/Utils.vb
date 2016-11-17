Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO

Public Class Utils
	Public Shared Function GetDataDir(t As Type) As String
		Dim c As String = t.FullName
		c = c.Replace("GridDesktop.Examples.", "")
		c = c.Replace("."C, Path.DirectorySeparatorChar)

		Dim retDir As String = Nothing
        Dim parent As DirectoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent
		Dim startDirectory As String = Nothing
		If parent IsNot Nothing Then
            If parent.Parent IsNot Nothing Then
                startDirectory = parent.Parent.FullName
            End If

			retDir = Path.Combine(Path.GetFullPath(Path.Combine(startDirectory, "..\")), "Data\") & c

			If Not Directory.Exists(retDir) Then
				Directory.CreateDirectory(retDir)
			End If
		Else
			retDir = parent.FullName
		End If
		Return retDir & "\"
	End Function
End Class
