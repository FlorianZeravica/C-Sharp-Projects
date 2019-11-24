using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace CrystalReportMonitoring
{
    class FileOverwriter
    {
        const string DateFormation = "ddMMyyyy";
        const string InvertedDateFormation = "yyyyMMdd";

        private const string SeparationString = "_";
        private const string RegexDotRemovingString = @"[^0-9]";
        private const string RegexTimeExtractionString = @"\d+:\d+:\d+";
        private const string RegexDateExtractionString = @"(\d+)[.](\d+)[.](\d+)";

        /// <summary>
        /// Overwrites the file name of the previous created file
        /// </summary>
        /// <param name="createdFileFullpath">Fullpath of the created file</param>
        /// <param name="oldFileName">Base name the file got created with</param>
        /// <param name="fileExtension">Extension the file will be created with</param>
        public void OverwriteFile(string createdFileFullpath, string oldFileName, string fileExtension)
        {
            var timeExtractionRegex = new Regex(RegexTimeExtractionString);
            var dateExtractionRegex = new Regex(RegexDateExtractionString);

            var oldFileFullpath = Path.Combine(createdFileFullpath, oldFileName + fileExtension);

            var fileInfo = new FileInfo(oldFileFullpath);
            var fileModifiedDateAndTime = fileInfo.LastWriteTime.ToString();

            var extractedFileTime = timeExtractionRegex.Match(fileModifiedDateAndTime).ToString();
            var extractedFileDate = dateExtractionRegex.Match(fileModifiedDateAndTime).ToString();
            
            //Remove double dots in time
            var fileTime = Regex.Replace(extractedFileTime, RegexDotRemovingString, "");

            //Remove dots in date
            var fileDate = Regex.Replace(extractedFileDate, RegexDotRemovingString, "");

            //Convert date to yyyyMMdd
            fileDate = this.ConvertDate(fileDate);

            //Format the new file name
            var newFormatedFileName = string.Format("{0} {1} {2} {1} {3}", oldFileName, SeparationString, fileDate, fileTime) + fileExtension;

            //Combine everything to get newFileFullpath
            var newFileFullpath = Path.Combine(createdFileFullpath, newFormatedFileName);

            //Rewrite old name to new name
            File.Move(oldFileFullpath, newFileFullpath);
        }

        /// <summary>
        /// Converts the date from ddMMyyyy to yyyyMMdd
        /// </summary>
        /// <param name="date">Date of the written file</param>
        /// <returns></returns>
        private string ConvertDate (string date)
        {
            var dateTime = DateTime.ParseExact(date, DateFormation, CultureInfo.InvariantCulture)
                  .ToString(InvertedDateFormation);

            return dateTime;
        }
    }
}
