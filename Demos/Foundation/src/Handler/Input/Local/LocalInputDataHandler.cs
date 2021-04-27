using Tools.Foundation.Config;
using Tools.Foundation.Handler;
using Tools.Foundation.Handler.Exceptions;
using Tools.Foundation.Handler.Exceptions.Local;
using Tools.Foundation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Tools.Foundation.Handler.Input.Local
{
    public class LocalInputDataHandler : IInputDataHandler
    {
        private string locale;
        public static Configs Configs = new Configs();
        // Instantiate Tools.Foundation.Handler.Exceptions.IExceptionHandler class object to handle the exceptions
        IExceptionHandler exceptionHandler = null;

        public LocalInputDataHandler()
        {
            new LocalInputDataHandler(locale, null);
        }

        public LocalInputDataHandler(string locale, IExceptionHandler exceptionHandler)
        {
            if (!String.IsNullOrEmpty(locale))
            {
                this.locale = locale;
            }
            //Check if the outputHandler was set
            if (exceptionHandler == null)
            {
                //Use default
                this.exceptionHandler = new LocalExceptionHandler();
            }
            else
            {
                //Use custom
                this.exceptionHandler = exceptionHandler;
            }
        }

        /// <summary>
        ///Save file localy from stream
        /// </summary>
        /// <param name="Stream st">File stream</param>
        /// <param name="string path">Folder where to save</param>
        /// <returns> InputFileDescription</returns>
        public InputFileDescription saveFile(Stream st, InputFileDescription inputFileDesc)
        {
            //Result ibject
             InputFileDescription fileDesc = new  InputFileDescription();
            try
            {
                if (st != null)
                {
                    if (!String.IsNullOrEmpty(inputFileDesc.OperationId) && !String.IsNullOrEmpty(inputFileDesc.Name))
                    {
                        string directory = getDirectory(inputFileDesc.OperationId);
                        //Create new FileStream object which will be saved localy
                        string pathForFile = String.Concat(directory, "/" + inputFileDesc.Name);
                        try
                        {
                            using (System.IO.FileStream output = new System.IO.FileStream(pathForFile, FileMode.Create, FileAccess.Write))
                            {
                                //Save stream to the local file
                                st.CopyTo(output);
                                //Set result data
                                FileInfo fileInfo = new FileInfo(pathForFile);
                                fileDesc.CreationTime = fileInfo.CreationTimeUtc;
                                fileDesc.ModificationTime = fileInfo.LastWriteTimeUtc;
                                fileDesc.UploadTime = DateTime.UtcNow;
                                fileDesc.Name = Path.GetFileName(pathForFile);
                                fileDesc.Path = directory;
                                fileDesc.Size = st.Length;
                            }
                        }
                        catch (DocumentsToolsException)
                        {
                            throw new GdtFileNotFoundException(locale, this.exceptionHandler);
                        }
                    }
                    else
                    {
                        throw new GdtFileNotFoundException(locale, this.exceptionHandler);
                    }
                }
                else
                {
                    throw new GdtNullReferenceException(locale, this.exceptionHandler);
                }
            }
            catch (DocumentsToolsException ex)
            {
                throw ex;
            }
            return fileDesc;
        }

        /// <summary>
        ///Create a directory for the input files
        /// </summary>
        /// <param name="string operationId">Id of the opperation - used as a sub folder name</param>
        /// <returns>string</returns>
        private string getDirectory(string operationId)
        {
            try
            {
                //Get configuration options
                string configurationFilePath = new InternalConfigurations().configurationFilePath;
                string configPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                new ConfigLoader(configPath + configurationFilePath).LoadConfigs(Configs);
                string path = String.Concat(Configs.workingdirectory, "/" + operationId + "/", Configs.inputdirname);
                //Create sub folder original in the temppath folder
                DirectoryInfo di = new DirectoryInfo(path);
                try
                {
                    di.Create();
                    return di.FullName;
                }
                catch (DocumentsToolsException)
                {
                    throw new GdtFileNotFoundException(locale, this.exceptionHandler);
                }
            }
            catch (DocumentsToolsException)
            {
                throw new GdtNullReferenceException(locale, this.exceptionHandler);
            }
        }

        /// <summary>
        ///Get file description
        /// </summary>
        /// <param name="FileDescription fileDesc">FileDescription of the </param>
        /// <returns>InputFileDescription</returns>
        public  InputFileDescription getFileDescription(FileDescription fileDesc)
        {
            //Initialaze the InputFileDescription obhect wich will be returned
            InputFileDescription fileDescription = new InputFileDescription();
            //Check if fileid is empty
            if (fileDesc != null)
            {
                try
                {
                    if (!String.IsNullOrEmpty(fileDesc.Name) && !String.IsNullOrEmpty(fileDesc.OperationId))
                    {
                        string path = getDirectory(fileDesc.OperationId);
                        //Get FileInfo for the fileId
                        FileInfo fi = new FileInfo(path + "/" + fileDesc.Name);
                        //Set result data
                        fileDescription.Name = fi.Name;
                        fileDescription.Path = path;
                        fileDescription.Size = fi.Length;
                        fileDescription.CreationTime = fi.CreationTimeUtc;
                    }
                    else
                    {
                        throw new GdtFileNotFoundException(locale, this.exceptionHandler);
                    }
                }
                catch (DocumentsToolsException)
                {
                    throw new GdtNullReferenceException(locale, this.exceptionHandler);
                }
            }
            else
            {
                throw new GdtNullReferenceException(locale, this.exceptionHandler);
            }
            return fileDescription;
        }

        /// <summary>
        ///Get local file stream
        /// </summary>
        /// <param name="FileDescription fileDesc">FileDescription object which contains the file data</param>
        /// <returns> List[Stream]</returns>
        public Stream getFile(FileDescription fileDesc)
        {
            //Initialize result stream
            Stream st = null;
            //Check if FileDescription is null
            if (fileDesc != null)
            {
                try
                {
                    //Get stream of the file
                    st = new FileStream(fileDesc.Path, FileMode.Open);
                }
                catch (DocumentsToolsException)
                {
                    throw new GdtFileNotFoundException(locale, this.exceptionHandler);
                }
            }
            else
            {
                throw new GdtNullReferenceException(locale, this.exceptionHandler);
            }
            return st;
        }

        /// <summary>
        ///Delete local file
        /// </summary>
        /// <param name="InputFileDescription fileDesc">FileDescription object which contains the file data</param>
        /// <returns>bool</returns>
        public bool removeFile(InputFileDescription fileDesc)
        {
            //Initialize the result variable with the default value
            bool result = false;
            if (fileDesc != null)
            {
                try
                {
                    if (!String.IsNullOrEmpty(fileDesc.Path))
                    {
                        //Delete the file
                        File.Delete(fileDesc.Path);
                        result = true;
                    }
                    else
                    {
                        throw new DocumentsToolsException();
                    }
                }
                catch (DocumentsToolsException)
                {
                    throw new GdtFileNotFoundException(locale, this.exceptionHandler);
                }
            }
            else
            {
                throw new GdtNullReferenceException(locale, this.exceptionHandler);
            }
            return result;
        }
    }
}