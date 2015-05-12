using Helpers;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using Description = Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute;

namespace Examples.ProgrammersGuide.AsposeCells.WorkingWithWorksheets.ManagementFeatures.ManagingWorksheets
{
    [TestClass, TestFixture]
    public class ManagingWorksheetsExamples
    {	
        [TestMethod, Test, Owner("Console")]
        public void AddingWorksheetsToNewExcelFile()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/ManagementFeatures/ManagingWorksheets/AddingWorksheetsToNewExcelFile");

            AddingWorksheetsToNewExcelFileExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void AddWorksheetsToExistingExcelFile()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/ManagementFeatures/ManagingWorksheets/AddWorksheetsToExistingExcelFile");

            AddWorksheetsToExistingExcelFileExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void RemovingWorksheetsUsingSheetName()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/ManagementFeatures/ManagingWorksheets/RemovingWorksheetsUsingSheetName");

            RemovingWorksheetsUsingSheetNameExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void RemovingWorksheetsUsingSheetIndex()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithWorksheets/ManagementFeatures/ManagingWorksheets/RemovingWorksheetsUsingSheetIndex");

            RemovingWorksheetsUsingSheetIndexExample.Program.Main();
        }

    }
}
