Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace GroupingData
	Friend Class OleDbCommand
		Private p As String
		Private con As OleDbConnection

		Public Sub New(ByVal p As String, ByVal con As OleDbConnection)
			' TODO: Complete member initialization
			Me.p = p
			Me.con = con
		End Sub
	End Class
End Namespace
