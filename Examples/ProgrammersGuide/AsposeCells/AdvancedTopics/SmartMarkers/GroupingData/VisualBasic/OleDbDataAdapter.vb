Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace GroupingData
	Friend Class OleDbDataAdapter
		Private privateSelectCommand As OleDbCommand
		Public Property SelectCommand() As OleDbCommand
			Get
				Return privateSelectCommand
			End Get
			Set(ByVal value As OleDbCommand)
				privateSelectCommand = value
			End Set
		End Property

		Friend Sub Fill(ByVal ds As System.Data.DataSet, ByVal p As String)

		End Sub
	End Class
End Namespace
