Imports Aspose.Cells.GridWeb.Data

Namespace Articles
    Public Class CalculateCustomFunction
        Inherits System.Web.UI.Page

        ' ExStart:CalculateCustomFunction
        Private Class GridWebCustomCalculationEngine
            Inherits GridAbstractCalculationEngine
            Public Overrides Sub Calculate(data As GridCalculationData)
                ' Calculate MYTESTFUNC() with your own logic. i.e Multiply MYTESTFUNC() parameter with 2 so MYTESTFUNC(3.0) = 6
                If "MYTESTFUNC".Equals(data.FunctionName.ToUpper()) Then
                    data.CalculatedValue = CDec(2.0 * CDbl(data.GetParamValue(0)))
                End If
            End Sub
        End Class

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            If Page.IsPostBack = False AndAlso GridWeb1.IsPostBack = False Then
                ' Assign your own custom calculation engine to GridWeb
                GridWeb1.CustomCalculationEngine = New GridWebCustomCalculationEngine()

                ' Access the active worksheet and add your custom function in cell B3
                Dim sheet As GridWorksheet = GridWeb1.ActiveSheet
                Dim cell As GridCell = sheet.Cells("B3")
                cell.Formula = "=MYTESTFUNC(9.0)"

                ' Calculate the GridWeb formula
                GridWeb1.CalculateFormula()
            End If
        End Sub
        ' ExEnd:CalculateCustomFunction

    End Class
End Namespace
