Imports Helpers
Imports NUnit.Framework
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Assert = NUnit.Framework.Assert
Imports Description = Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute

Namespace Examples.ProgrammersGuide.AsposeCells.WorkingWithFiles.FileHandlingFeatures
	<TestClass, TestFixture> _
	Public Class FileHandlingFeaturesExamples
        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub OpeningFiles()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/FileHandlingFeatures/OpeningFiles")
	
	            OpeningFilesExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub SaveWorkbookToTextCSVFormat()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/FileHandlingFeatures/SaveWorkbookToTextCSVFormat")
	
	            SaveWorkbookToTextCSVFormatExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub SavingFiles()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/FileHandlingFeatures/SavingFiles")
	
	            SavingFilesExample.Program.Main()
        End Sub

	End Class
End Namespace