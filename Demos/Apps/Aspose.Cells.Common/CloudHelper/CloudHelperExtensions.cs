namespace Aspose.Cells.Common.CloudHelper
{
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    using System;

    public static class CloudHelperExtensions
    {
        /// <summary>
        ///     ReadAsBytes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] ReadAsBytes(this Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);

                return ms.ToArray();
            }
        }
        public static IDictionary<string, Stream> ToStream(this IList<CellsCloudFileInfo> Files)
        {
            IDictionary<string, Stream> keyValuePairs = new Dictionary<string, Stream>();
            foreach (CellsCloudFileInfo cellsCloudFileInfo in Files)
            {
                keyValuePairs.Add(cellsCloudFileInfo.Filename, new MemoryStream(Convert.FromBase64String(cellsCloudFileInfo.FileContent)));
            }
            return keyValuePairs;
        }
    }
}
