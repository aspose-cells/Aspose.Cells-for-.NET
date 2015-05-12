Imports System.Reflection
Imports Helpers
Imports NUnit.Framework
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Assert = NUnit.Framework.Assert
Imports Description = Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute

<Assembly: AssemblyTitle("Aspose.Cells Examples")>
<Assembly: AssemblyDescription("A collection of examples which demonstrate how to use the Aspose.Cells for .NET API.")>
<Assembly: AssemblyConfiguration("VisualBasic")>

Namespace Examples.ProgrammersGuide.AsposeCells.WorkingWithFiles.UtilityFeatures
	<TestClass, TestFixture> _
	Public Class UtilityFeaturesExamples
        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub Excel2PDFConversion()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/Excel2PDFConversion")
	
	            Excel2PDFConversionExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub ChartToImage()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/ChartToImage")
	
	            ChartToImageExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub WorksheetToImage()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/WorksheetToImage")
	
	            WorksheetToImageExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub ConvertingToXPS()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/ConvertingToXPS")
	
	            ConvertingToXPSExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub ManagingDocumentProperties()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/ManagingDocumentProperties")
	
	            ManagingDocumentPropertiesExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub EncryptingFiles()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/EncryptingFiles")
	
	            EncryptingFilesExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub ConvertingWorksheetToSVG()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/ConvertingWorksheetToSVG")
	
	            ConvertingWorksheetToSVGExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub ConvertingToMHTMLFiles()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/ConvertingToMHTMLFiles")
	
	            ConvertingToMHTMLFilesExample.Program.Main()
        End Sub

	End Class

	<TestClass, SetUpFixture> _
	Public Class AsposeExamples
		<AssemblyInitialize> _
		Public Shared Sub AssemblyInitialize(ByVal context As Microsoft.VisualStudio.TestTools.UnitTesting.TestContext)
			Main()
		End Sub

		<SetUp> _
		Public Shared Sub AssemblySetup()
			Main()
		End Sub

		<AssemblyCleanup> _
		Public Shared Sub AssemblyCleanup()
			TestHelper.Cleanup()
		End Sub

		Public Shared Sub Main()
		    ' Provides an introduction of how to use this example project.
			TestHelper.ShowIntroForm()
		End Sub
	End Class
End Namespace