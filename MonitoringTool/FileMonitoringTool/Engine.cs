using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileMonitoringTool
{
    class Engine
    {
        /// <summary>
        /// Iteration-process
        /// </summary>
        /// <param name="path">Base path</param>
        /// <param name="reportFileExtension">Extension of the report files</param>
        /// <param name="fileName">Base name the file will be created with</param>
        /// <param name="fileExtension">Extension the file will be created with</param>        
        public void Run(string path, string reportFileExtension, string fileName, string fileExtension)
        {
            var isPathValid = this.ValidatePath(path);

            if (!isPathValid)
            {
                Console.WriteLine("Invalid path or not existing files");
                return;
            }

            this.ProcessPath(path, reportFileExtension, fileName, fileExtension);
            Console.WriteLine("--Prozess fertig--");
            Console.ReadKey();
        }

        /// <summary>
        /// Iterate through path-subdirectories and get all file names
        /// </summary>
        /// <param name="path">Base path</param>
        /// <param name="reportFileExtension">Extension of the report files</param>
        /// <param name="fileName">Base name the file will be created with</param>
        /// <param name="fileExtension">Extension the file will be created with</param>
        private void ProcessPath(string path, string reportFileExtension, string fileName, string fileExtension)
        {
            var FileInfo = new FileInformation();

            var subdirectoriePaths = this.GetSubdirectories(path);
            var reportFilePaths = new List<string>();

            foreach (var subdirPath in subdirectoriePaths)
            {
                reportFilePaths.AddRange(this.GetFiles(subdirPath, reportFileExtension).ToList());
            }
            FileInfo.CreateFile(reportFilePaths, path, fileName, fileExtension);
        }

        /// <summary>
        /// Get all subdirectories
        /// </summary>
        /// <param name="path">Base path</param>
        /// <returns></returns>
        public string[] GetSubdirectories(string path)
        {
            //Get all paths
            var allPaths = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);

            //Sort array alphabetically
            Array.Sort(allPaths);

            return allPaths;
        }

        /// <summary>
        /// Get all report files from directory
        /// </summary>
        /// <param name="subdirectoriePath">Subdirectorie path of each directory in base path</param>
        /// <param name="reportFileExtension">Extension of the report files</param>
        /// <returns></returns>
        private string[] GetFiles(string subdirectoriePath, string reportFileExtension)
        {
            return Directory.GetFiles(subdirectoriePath, reportFileExtension, SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Check if path exists
        /// </summary>
        /// <param name="path">Base path</param>
        /// <returns></returns>
        public bool ValidatePath(string path)
        {
            return Directory.Exists(path);
        }
    }
}