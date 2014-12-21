Imports Helpers
Imports NUnit.Framework
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Assert = NUnit.Framework.Assert
Imports Description = Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute

Namespace Examples.ProgrammersGuide.AsposeCells.WorkingWithWorksheets.DisplayFeatures
	<TestClass, TestFixture> _
	Public Class DisplayFeaturesExamples
        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub HideUnhideWorksheet()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/HideUnhideWorksheet")
	
	            HideUnhideWorksheetExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub DisplayHideTabs()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/DisplayHideTabs")
	
	            DisplayHideTabsExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub DisplayHideScrollBars()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/DisplayHideScrollBars")
	
	            DisplayHideScrollBarsExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub DisplayHideGridlines()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/DisplayHideGridlines")
	
	            DisplayHideGridlinesExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub PageBreakPreview()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/PageBreakPreview")
	
	            PageBreakPreviewExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub ZoomFactor()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/ZoomFactor")
	
	            ZoomFactorExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub DisplayHideRowColumnHeaders()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/DisplayHideRowColumnHeaders")
	
	            DisplayHideRowColumnHeadersExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub FreezePanes()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/FreezePanes")
	
	            FreezePanesExample.Program.Main()
        End Sub

        <TestMethod(), Test(), Owner("Console")> _
	        Public Sub SplitPanes()
	            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/SplitPanes")
	
	            SplitPanesExample.Program.Main()
        End Sub

	End Class
End Namespace