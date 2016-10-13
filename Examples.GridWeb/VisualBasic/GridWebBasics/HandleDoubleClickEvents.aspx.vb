
Namespace GridWebBasics
    Public Class HandleDoubleClickEvents
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                ' Sets sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0
            End If
        End Sub

        ' ExStart:CellDoubleClickEvent
        ' Event Handler for CellDoubleClick event
        Protected Sub GridWeb1_CellDoubleClick(ByVal sender As Object, ByVal e As Aspose.Cells.GridWeb.CellEventArgs)
            ' Displaying the name of the cell (that is double clicked) in GridWeb's Message Box
            Dim msg As String = "You just clicked <"
            msg &= "Row: " & (e.Cell.Row + 1) & " Column: " & (e.Cell.Column + 1) & " Cell Name: " & e.Cell.Name & ">"
            GridWeb1.Message = msg
        End Sub
        ' ExEnd:CellDoubleClickEvent

        ' ExStart:ColumnDoubleClickEvent
        ' Event Handler for ColumnDoubleClick event
        Protected Sub GridWeb1_ColumnDoubleClick(ByVal sender As Object, ByVal e As Aspose.Cells.GridWeb.RowColumnEventArgs)
            ' Displaying the number of the column (whose header is double clicked) in GridWeb's Message Box
            Dim msg As String = "You just clicked <"
            msg &= "Column header: " & (e.Num + 1) & ">"
            GridWeb1.Message = msg
        End Sub
        ' ExEnd:ColumnDoubleClickEvent

        ' ExStart:RowDoubleClickEvent
        ' Event Handler for RowDoubleClick event
        Protected Sub GridWeb1_RowDoubleClick(ByVal sender As Object, ByVal e As Aspose.Cells.GridWeb.RowColumnEventArgs)
            'Displaying the number of the row (whose header is double clicked) in GridWeb's Message Box
            Dim msg As String = "You just clicked <"
            msg &= "Row header: " & (e.Num + 1) & ">"
            GridWeb1.Message = msg
        End Sub
        ' ExEnd:RowDoubleClickEvent

        Protected Sub GridWeb1_SaveCommand(sender As Object, e As System.EventArgs)
            GridWeb1.Message = "You just clicked ""Save"" icon!"
        End Sub

        Protected Sub GridWeb1_SheetTabClick(sender As Object, e As System.EventArgs)
            GridWeb1.Message = "You just clicked ""Change worksheet"" icon!"
        End Sub

        Protected Sub GridWeb1_SubmitCommand(sender As Object, e As System.EventArgs)
            GridWeb1.Message = "You just clicked ""Submit"" icon!"
        End Sub

        Protected Sub GridWeb1_UndoCommand(sender As Object, e As System.EventArgs)
            GridWeb1.Message = "You just clicked ""Cancel"" icon!"
        End Sub

        Protected Sub CheckBox1_CheckedChanged(sender As Object, e As System.EventArgs)
            If CheckBox1.Checked Then
                ' ExStart:EnableDoubleClickEvents
                ' Enabling Double Click events
                GridWeb1.EnableDoubleClickEvent = True
                ' ExEnd:EnableDoubleClickEvents
            Else
                GridWeb1.EnableDoubleClickEvent = False
            End If

        End Sub
    End Class
End Namespace
