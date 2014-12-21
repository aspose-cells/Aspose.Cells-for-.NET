using Helpers;
using NUnit.Framework;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using Description = Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute;

[assembly: AssemblyTitle("Aspose.Cells Examples")]
[assembly: AssemblyDescription("A collection of examples which demonstrate how to use the Aspose.Cells for .NET API.")]
[assembly: AssemblyConfiguration("CSharp")]

namespace Examples.ProgrammersGuide.AsposeCells.WorkingWithFiles.UtilityFeatures
{
    [TestClass, TestFixture]
    public class UtilityFeaturesExamples
    {	
        [TestMethod, Test, Owner("Console")]
        public void Excel2PDFConversion()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/Excel2PDFConversion");

            Excel2PDFConversionExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void ChartToImage()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/ChartToImage");

            ChartToImageExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void WorksheetToImage()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/WorksheetToImage");

            WorksheetToImageExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void ConvertingToXPS()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/ConvertingToXPS");

            ConvertingToXPSExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void ManagingDocumentProperties()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/ManagingDocumentProperties");

            ManagingDocumentPropertiesExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void EncryptingFiles()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/EncryptingFiles");

            EncryptingFilesExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void ConvertingWorksheetToSVG()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/ConvertingWorksheetToSVG");

            ConvertingWorksheetToSVGExample.Program.Main();
        }

        [TestMethod, Test, Owner("Console")]
        public void ConvertingToMHTMLFiles()
        {
            TestHelper.SetDataDir("ProgrammersGuide/AsposeCells/WorkingWithFiles/UtilityFeatures/ConvertingToMHTMLFiles");

            ConvertingToMHTMLFilesExample.Program.Main();
        }

    }

    [TestClass, SetUpFixture]
    public class AsposeExamples
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context)
        {
            Main();
        }

        [SetUp]
        public static void AssemblySetup()
        {
            Main();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            TestHelper.Cleanup();
        }

        public static void Main()
        {
            // Provides an introduction of how to use this example project.
            TestHelper.ShowIntroForm();
        }
    }
}
