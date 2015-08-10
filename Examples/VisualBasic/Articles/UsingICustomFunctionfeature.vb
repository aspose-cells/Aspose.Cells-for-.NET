'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace Aspose.Cells.Examples.Articles
    Public Class CustomFunction
        Implements ICustomFunction

        Public Function CalculateCustomFunction(ByVal functionName As String, ByVal paramsList As System.Collections.ArrayList, ByVal contextObjects As System.Collections.ArrayList) As Object Implements ICustomFunction.CalculateCustomFunction

            'get value of first parameter
            Dim firstParamB1 As Decimal = System.Convert.ToDecimal(paramsList(0))

            'get value of second parameter
            Dim secondParamC1C5 As Array = CType(paramsList(1), Array)

            Dim total As Decimal = 0D

            ' get every item value of second parameter
            For Each value As Object() In secondParamC1C5

                total += System.Convert.ToDecimal(value(0))

            Next value

            total = total / firstParamB1

            'return result of the function
            Return total

        End Function
    End Class

    Public Class UsingICustomFunctionfeature
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Open the workbook
            Dim workbook As New Workbook()

            'Obtaining the reference of the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Adding a sample value to "A1" cell
            worksheet.Cells("B1").PutValue(5)

            'Adding a sample value to "A2" cell
            worksheet.Cells("C1").PutValue(100)

            'Adding a sample value to "A3" cell
            worksheet.Cells("C2").PutValue(150)

            'Adding a sample value to "B1" cell
            worksheet.Cells("C3").PutValue(60)

            'Adding a sample value to "B2" cell
            worksheet.Cells("C4").PutValue(32)

            'Adding a sample value to "B2" cell
            worksheet.Cells("C5").PutValue(62)

            'Adding custom formula to Cell A1
            workbook.Worksheets(0).Cells("A1").Formula = "=MyFunc(B1,C1:C5)"

            'Calcualting Formulas
            workbook.CalculateFormula(False, New CustomFunction())

            'Assign resultant value to Cell A1
            workbook.Worksheets(0).Cells("A1").PutValue(workbook.Worksheets(0).Cells("A1").Value)

            'Save the file
            workbook.Save(dataDir & "UsingICustomFunction.xls")
        End Sub
    End Class
End Namespace
