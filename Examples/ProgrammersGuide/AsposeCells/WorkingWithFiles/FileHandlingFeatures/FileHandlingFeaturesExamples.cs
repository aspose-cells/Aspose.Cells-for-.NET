using Helpers;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using Description = Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute;

namespace Examples.ProgrammersGuide.AsposeCells.WorkingWithFiles.FileHandlingFeatures
{
    [TestClass, TestFixture]
    public class FileHandlingFeaturesExamples
    {	
        [TestMethod, Test, Owner("Console")]
        public void OpeningFiles()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/FileHandlingFeatures/OpeningFiles");

            OpeningFilesExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void SaveWorkbookToTextCSVFormat()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/FileHandlingFeatures/SaveWorkbookToTextCSVFormat");

            SaveWorkbookToTextCSVFormatExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void SavingFiles()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/FileHandlingFeatures/SavingFiles");

            SavingFilesExample.Program.Main();
        }

    }
}
