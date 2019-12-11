using System.Collections.Generic;
using System.IO;

namespace FileMonitoringTool
{
    class FileInformation
    {
        private const string ValueSeparator = "; ";

        /// <summary>
        /// Entry point for the other methods
        /// </summary>
        /// <param name="reportFilePaths">Report file fullpath</param>
        /// <param name="path">Base path</param>
        /// <param name="fileName">Base name the file will be created with</param>
        /// <param name="fileExtension">Extension the file will be created with</param>
        public void CreateFile(List<string> reportFilePaths, string path, string fileName, string fileExtension)
        {
            var writer = new FileWriter();
            var fileInfoEntries = this.CreateFileInfoList(reportFilePaths);

            writer.CreateAndWriteFile(path, fileName, fileExtension, fileInfoEntries);
        }

        /// <summary>
        /// Gets the file name of the file, directory name of the file, date and time the report got changed the last time
        /// </summary>
        /// <param name="filePaths">Report file fullpath</param>
        /// <returns></returns>
        private List<string> CreateFileInfoList(List<string> filePaths)
        {
            var fileInfoEntries = new List<string>();
            string fileInfoEntry;

            foreach (var path in filePaths)
            {
                var fileInfo = new FileInfo(path);
                fileInfoEntry = fileInfo.DirectoryName + ValueSeparator + fileInfo.Name + ValueSeparator + fileInfo.LastWriteTime;
                fileInfoEntries.Add(fileInfoEntry);
            }
            return fileInfoEntries;
        }
    }
}
