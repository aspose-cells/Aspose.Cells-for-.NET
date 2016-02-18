// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NGit.Api;

namespace AsposeVisualStudioPluginCells.Core
{
    public class GitHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>

        public static string CloneOrCheckOutRepo(AsposeComponent component)
        {
            if (Directory.Exists(getLocalRepositoryPath(component)))
            {
                if (Directory.Exists(getLocalRepositoryPath(component) + "\\.git\\refs\\heads"))
                {
                    if (Directory.GetFiles(getLocalRepositoryPath(component) + "\\.git\\refs\\heads").Length <= 0)
                    {
                        System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(getLocalRepositoryPath(component));
                        Empty(directory);
                    }
                }
            }

            string repUrl = component.get_remoteExamplesRepository();
            string localFolder = getLocalRepositoryPath(component);
            string error = string.Empty;

            checkAndCreateFolder(getLocalRepositoryPath(component));

            try
            {
                CloneCommand clone = Git.CloneRepository();
                clone.SetURI(repUrl);
                clone.SetDirectory(localFolder);

                Git repo = clone.Call();
                //writer.Close();
                repo.GetRepository().Close();
            }
            catch (Exception ex)
            {
                try
                {
                    var git = Git.Open(localFolder);
                    //var repository = git.GetRepository();
                    //PullCommand pullCommand = git.Pull();
                    //pullCommand.Call();
                    //repository.Close();

                    var reset = git.Reset().SetMode(ResetCommand.ResetType.HARD).SetRef("origin/master").Call();

                }
                catch (Exception ex2)
                {

                    error = ex2.Message;
                }

                error = ex.Message;
            }

            return error;
        }


        public static void Empty(DirectoryInfo directory)
        {
            foreach (System.IO.FileInfo file in directory.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch
                {
                    continue;
                }
            }
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories())
            {
                try
                {
                    subDirectory.Delete(true);
                }
                catch
                {
                    continue;
                }
            }
        }

        private static void checkAndCreateFolder(String folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }

        public static string getLocalRepositoryPath(AsposeComponent component)
        {
            return AsposeComponentsManager.getAsposeHomePath() + "gitrepos" + "/" + component.get_name();
        }

    }
}
