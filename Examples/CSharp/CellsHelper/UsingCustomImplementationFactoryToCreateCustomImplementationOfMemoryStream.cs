using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Aspose.Cells.Examples.CSharp._CellsHelper
{
    public class UsingCustomImplementationFactoryToCreateCustomImplementationOfMemoryStream
    {
        /*
        //Implement CustomImplementationFactory - CELLSNET-45461 - CELLSNET-45461 - CELLSNET-45461
        class MM1 : CustomImplementationFactory
        {

            RecyclableMemoryStreamManager manager = new RecyclableMemoryStreamManager();

            public override MemoryStream CreateMemoryStream()
            {

                return manager.GetStream("MM");
            }

            public override MemoryStream CreateMemoryStream(int capacity)
            {
                return manager.GetStream("MM", capacity);
            }
        }*/

        //Implement CustomImplementationFactory
        class MM : CustomImplementationFactory
        {

            public override MemoryStream CreateMemoryStream()
            {
                return new MemoryStream();
            }

            public override MemoryStream CreateMemoryStream(int capacity)
            {
                return new MemoryStream();
            }
        }

        public static void Run()
        {
            //CellsHelper.CustomImplementationFactory = new MM();

            Console.WriteLine("UsingCustomImplementationFactoryToCreateCustomImplementationOfMemoryStream executed successfully.\r\n");
        }
    }
}
