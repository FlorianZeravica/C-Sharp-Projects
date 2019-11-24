using System.Collections.Generic;
using System.IO;

namespace CrystalReportMonitoring
{
    public class FileWriter
    {
        //Name of the created folder
        private const string FolderName = "_CrystalReportMonitoring Files";

        //Output order of the reports in the file
        private const string OutputOrder = "Directory; Report name; Modfication date and time";

        /// <summary>
        /// Creates a file on the central stacker
        /// </summary>
        /// <param name="filePath">Base path</param>
        /// <param name="fileName">Base name the file will be created with</param>
        /// <param name="fileExtension">Extension the file will be created with</param>
        /// <param name="fileInfoEntries">Files with the whole information which they will get written</param>
        /// <returns></returns>
        public bool CreateAndWriteFile(string filePath, string fileName, string fileExtension, List<string> fileInfoEntries)
        {
            var fileIsCreated = true;
            var defaultFileName = fileName;

            //Add the extension in a second process, so default- and comparingFileName can be used separated
            var defaultFileNameWithExtension = defaultFileName + fileExtension;

            var path = CreateFolder(filePath);

            var defaultFullpath = Path.Combine(path, defaultFileNameWithExtension);

            var FileOverwriter = new FileOverwriter();


            //Writes the whole contend from the list into the file with "," separation
            using (StreamWriter writer = File.CreateText(defaultFullpath))
            {
                writer.Write("{0}" + "\n", OutputOrder);

                foreach (var entry in fileInfoEntries)
                {
                    writer.WriteLine(entry);
                }
            }

            //When file created, overwrite the name
            FileOverwriter.OverwriteFile(path, defaultFileName, fileExtension);

            return fileIsCreated;
        }

        //Creates a new folder on the given path
        private string CreateFolder(string filePath)
        {
            var newFilePath = filePath + @"\" + FolderName;

            //Create new folder if it doesnt already exists and return new filePath
            if(!Directory.Exists(newFilePath))
            {
                Directory.CreateDirectory(newFilePath);
                return newFilePath;
            }
            //Return new filePath if the folder already exists
            if(Directory.Exists(newFilePath))
            {
                return newFilePath;
            }
            return filePath;
        }
    }
}