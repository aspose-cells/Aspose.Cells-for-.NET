
Namespace Worksheets
    Public Class AccessNamedRanges
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnAddNamedRange_Click(sender As Object, e As EventArgs)
            ' ExStart:AddNamedRange
            ' Inserting dummy data
            GridWeb1.WorkSheets(0).Cells("B1").PutValue(100)
            GridWeb1.WorkSheets(0).Cells("B2").PutValue(200)
            GridWeb1.WorkSheets(0).Cells("B3").PutValue(300)
            GridWeb1.WorkSheets(0).Cells("B4").PutValue(400)

            ' Add a new named range "MyRange" with based area B1:B4
            GridWeb1.WorkSheets.Names.Add("MyRange", "Sheet1!B1:B4")

            ' Apply a formula to a cell that refers to a named range "MyRange"
            GridWeb1.WorkSheets(0).Cells("A1").Formula = "=SUM(MyRange)"

            ' Apply a formula to A2 cell
            GridWeb1.WorkSheets(0).Cells("A2").Formula = "=Average(MyRange)"

            ' Calculate the results of the formulas
            GridWeb1.WorkSheets.CalculateFormula()
            ' ExEnd:AddNamedRange
        End Sub
    End Class
End Namespace
