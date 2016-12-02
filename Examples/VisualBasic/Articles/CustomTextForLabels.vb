Imports Aspose.Cells.Rendering

Namespace Articles
    Public Class CustomTextForLabels
        Public Shared Sub Run()
            ' ExStart:UsingGlobalizationSettings
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Loads an existing spreadsheet containing a pie chart
            Dim book As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Assigns the GlobalizationSettings property of the WorkbookSettings class to the class created in first step
            book.Settings.GlobalizationSettings = New CustomSettings()

            ' Accesses the 1st worksheet from the collection which contains pie chart
            Dim sheet As Worksheet = book.Worksheets(0)

            ' Accesses the 1st chart from the collection
            Dim chart As Aspose.Cells.Charts.Chart = sheet.Charts(0)

            ' Refreshes the chart
            chart.Calculate()

            ' Renders the chart to image
            chart.ToImage(dataDir & Convert.ToString("output_out.png"), New ImageOrPrintOptions())
            ' ExEnd:UsingGlobalizationSettings
        End Sub

        ' ExStart:GlobalizationSettings
        ' Defines a custom class inherited by GlobalizationSettings class
        Private Class CustomSettings
            Inherits GlobalizationSettings
            ' Overrides the GetOtherName method
            Public Overrides Function GetOtherName() As String
                ' Gets the culture identifier for the current system
                Dim lcid As Integer = System.Globalization.CultureInfo.CurrentCulture.LCID
                Select Case lcid
                    ' Handles case for English
                    Case 1033
                        Return "Other"
                        ' Handles case for French
                    Case 1036
                        Return "Autre"
                        ' Handles case for German
                    Case 1031
                        Return "Andere"
                    Case Else
                        ' Handle other cases
                        Return MyBase.GetOtherName()
                End Select
            End Function
        End Class
        ' ExEnd:GlobalizationSettings
    End Class
End Namespace