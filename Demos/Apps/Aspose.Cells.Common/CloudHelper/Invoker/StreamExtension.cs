namespace Aspose.Cells.Common.CloudHelper.Invoker
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    /// <summary>
    ///     Stream helper
    /// </summary>
    internal static class StreamExtension
    {
        private const int BufferSize = 8192;
        /// <summary>
        ///     Copy a stream to destination stream
        /// </summary>
        /// <param name="source">The source stream</param>
        /// <param name="destination">The destination stream</param>
        /// <param name="bufferSize">The size of the buffer</param>
        public static void CopyTo(this Stream source, Stream destination, int bufferSize = 81920)
        {
            if (source.CanSeek)
            {
                source.Flush();
                source.Position = 0;
            }

            var array = new byte[bufferSize];
            int count;
            while ((count = source.Read(array, 0, array.Length)) != 0)
                destination.Write(array, 0, count);
        }

        public static byte[] ReadAll(this Stream stream)
        {
            return stream.CanSeek ? ReadAllImplForKnownLength(stream) : ReadAllImplForUnknownLength(stream);
        }

        private static byte[] ReadAllImplForKnownLength(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[stream.Length - stream.Position];
            stream.Read(buffer, 0, buffer.Length);
            return buffer;
        }

        private static byte[] ReadAllImplForUnknownLength(Stream stream)
        {
            List<byte> collector = new List<byte>();
            byte[] buffer = new byte[BufferSize];
            for (; ; )
            {
                var count = stream.Read(buffer, 0, buffer.Length);
                if (count == 0)
                {
                    break;
                }

                if (count < BufferSize)
                {
                    byte[] rest = new byte[count];
                    Array.Copy(buffer, rest, count);
                    collector.AddRange(rest);
                }
                else
                {
                    collector.AddRange(buffer);
                }
            }

            return collector.ToArray();
        }
    }
}