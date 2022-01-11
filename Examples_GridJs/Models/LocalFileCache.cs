using Aspose.Cells.GridJs;
using System;
using System.IO;

namespace Aspose.Cells.GridJsDemo.Models
{
    public class LocalFileCache  : GridCacheForStream
    {

        /// <summary>
        /// Implement this method to savecache,save the stream to the cache object with the key id.
        /// </summary>
        /// <param name="s">the source stream </param>
        /// <param name="uid">he key id.</param>
        public override void SaveStream(Stream s, String uid)
        {//make sure the directory is exist
            String filepath = Path.Combine(Config.FileCacheDirectory , "streamcache", uid.Replace('/', '.'));
            using (FileStream fs = new FileStream(filepath, FileMode.Create))
            {
                s.Position = 0;
                s.CopyTo(fs);
            }

        }

        /// <summary>
        /// Implement this method to loadcache with the key uid,return the stream from the cache object.
        /// </summary>
        /// <param name="uid">the key id</param>
        /// <returns>the stream from  the cache</returns>
        public override Stream LoadStream(String uid)
        {//make sure the directory is exist
            String filepath = Path.Combine(Config.FileCacheDirectory, "streamcache", uid.Replace('/', '.'));
            FileStream fs = new FileStream(filepath, FileMode.Open);
            return fs;
        }
        /// <summary>
        ///  implement the url in action controller  to get the file
        /// </summary>
        /// <param name="uid">the key id</param>
        /// <returns></returns>
        public override String GetFileUrl(string uid)
        {
            return "/GridJs2/GetFile?id=" + uid;
        }
        public override bool IsExisted(String uid)
        {
            String filepath = Path.Combine(Config.FileCacheDirectory,   "streamcache", uid.Replace('/', '.'));
            return File.Exists(filepath);
        }

    }
}
