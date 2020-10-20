using System;
using System.IO;

namespace Aspose.Cells.Examples.CSharp.Files.Utility
{
    public class VerifyPassword
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a Stream object
            FileStream fstream = new FileStream(dataDir + "EncryptedBook1.xlsx", FileMode.Open);

            bool isPasswordValid = FileFormatUtil.VerifyPassword(fstream, "1234");

            Console.WriteLine("Password is Valid: " + isPasswordValid);
            // ExEnd:1

            Console.WriteLine("VerifyPassword executed successfully");
        }
    }
}
