using System;
using System.IO;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class SetCustomFontFolders
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Defining string variables to store paths to font folders & font file
            string fontFolder1 = sourceDir + "Arial";
            string fontFolder2 = sourceDir + "Calibri";
            string fontFile = sourceDir + "Arial.ttf"; 

            // Setting first font folder with SetFontFolder method
            // Second parameter directs the API to search the subfolders for font files
            FontConfigs.SetFontFolder(fontFolder1, true);

            // Setting both font folders with SetFontFolders method
            // Second parameter prohibits the API to search the subfolders for font files
            FontConfigs.SetFontFolders(new string[] { fontFolder1, fontFolder2 }, false);

            // Defining FolderFontSource
            FolderFontSource sourceFolder = new FolderFontSource(fontFolder1, false);

            // Defining FileFontSource
            FileFontSource sourceFile = new FileFontSource(fontFile);

            // Defining MemoryFontSource
            MemoryFontSource sourceMemory = new MemoryFontSource(System.IO.File.ReadAllBytes(fontFile));

            // Setting font sources
            FontConfigs.SetFontSources(new FontSourceBase[] { sourceFolder, sourceFile, sourceMemory });

            Console.WriteLine("SetCustomFontFolders executed successfully.");
        }
        public static void FontSubstitution()
        {
            // Substituting the Arial font with Times New Roman & Calibri
            FontConfigs.SetFontSubstitutes("Arial", new string[] { "Times New Roman", "Calibri" });          
        }
    }
}
