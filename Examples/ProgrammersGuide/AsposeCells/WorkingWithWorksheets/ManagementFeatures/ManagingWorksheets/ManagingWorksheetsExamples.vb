Imports Helpers
Imports NUnit.Framework
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Assert = NUnit.Framework.Assert
Imports Description = Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute

Namespace Examples.ProgrammersGuide.AsposeCells.WorkingWithWorksheets.ManagementFeatures.ManagingWorksheets
	<TestClass, TestFixture> _
	Public Class ManagingWorksheetsExamples
        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub AddingWorksheetsToNewExcelFile()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/ManagementFeatures/ManagingWorksheets/AddingWorksheetsToNewExcelFile")
	
	            AddingWorksheetsToNewExcelFileExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub AddWorksheetsToExistingExcelFile()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/ManagementFeatures/ManagingWorksheets/AddWorksheetsToExistingExcelFile")
	
	            AddWorksheetsToExistingExcelFileExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub RemovingWorksheetsUsingSheetName()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/ManagementFeatures/ManagingWorksheets/RemovingWorksheetsUsingSheetName")
	
	            RemovingWorksheetsUsingSheetNameExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub RemovingWorksheetsUsingSheetIndex()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/ManagementFeatures/ManagingWorksheets/RemovingWorksheetsUsingSheetIndex")
	
	            RemovingWorksheetsUsingSheetIndexExample.Program.Main()
        End Sub

	End Class
End Namespace