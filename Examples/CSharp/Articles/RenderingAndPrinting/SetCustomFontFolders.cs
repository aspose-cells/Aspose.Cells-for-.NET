using System.IO;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class SetCustomFontFolders
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Defining string variables to store paths to font folders & font file
            string fontFolder1 =  dataDir + "Arial";
            string fontFolder2 =  dataDir + "Calibri";
            string fontFile = dataDir + "arial.ttf";

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
            // ExEnd:1          
            
        }
        public static void FontSubstitution()
        {
            // ExStart:FontSubstitution
            // Substituting the Arial font with Times New Roman & Calibri
            FontConfigs.SetFontSubstitutes("Arial", new string[] { "Times New Roman", "Calibri" });
            // ExEnd:FontSubstitution
        }
    }
}
