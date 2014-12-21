using Helpers;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using Description = Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute;

namespace Examples.ProgrammersGuide.AsposeCells.WorkingWithWorksheets.DisplayFeatures
{
    [TestClass, TestFixture]
    public class DisplayFeaturesExamples
    {	
        [TestMethod, Test, Owner("Console")]
        public void HideUnhideWorksheet()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/HideUnhideWorksheet");

            HideUnhideWorksheetExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void DisplayHideTabs()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/DisplayHideTabs");

            DisplayHideTabsExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void DisplayHideScrollBars()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/DisplayHideScrollBars");

            DisplayHideScrollBarsExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void DisplayHideGridlines()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/DisplayHideGridlines");

            DisplayHideGridlinesExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void PageBreakPreview()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/PageBreakPreview");

            PageBreakPreviewExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void ZoomFactor()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/ZoomFactor");

            ZoomFactorExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void DisplayHideRowColumnHeaders()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/DisplayHideRowColumnHeaders");

            DisplayHideRowColumnHeadersExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void FreezePanes()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/FreezePanes");

            FreezePanesExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void SplitPanes()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/DisplayFeatures/SplitPanes");

            SplitPanesExample.Program.Main();
        }

    }
}
