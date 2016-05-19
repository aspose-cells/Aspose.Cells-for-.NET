using Aspose.Cells;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Cells for .NET API reference when the project is build. Please check https://docs.nuget.org/consume/nuget-faq for more information. If you do not wish to use NuGet, you can manually download Aspose.Cells for .NET API from http://www.aspose.com/downloads, install it and then add its reference to this project. For any issues, questions or suggestions please feel free to contact us using http://www.aspose.com/community/forums/default.aspx
*/

namespace Aspose.Plugins.AsposeVSOpenXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"..\..\..\Sample Files\";
            string srcFileName = FilePath + "Encrypting Excel Files.xlsx";
            string destFileName = FilePath + "Result Encrypting Excel Files.xlsx";
            
            //Open an excel file.
            Workbook workbook = new Workbook(srcFileName);

            //Specify XOR encryption type.
            workbook.SetEncryptionOptions(EncryptionType.XOR, 40);

            //Specify Strong Encryption type (RC4,Microsoft Strong Cryptographic Provider).
            workbook.SetEncryptionOptions(EncryptionType.StrongCryptographicProvider, 128);

            //Password protect the file.
            workbook.Settings.Password = "1234";

            //Save the excel file.
            workbook.Save(destFileName);
        }
    }
}
