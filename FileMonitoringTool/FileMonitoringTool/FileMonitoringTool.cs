namespace FileMonitoringTool
{
    class FileMonitoringTool
    {
        private const string ReportExtension = "*.pdf";
        private const string FileName = "MonitoringFile";
        private const string FileExtension = ".csv";

        /// <summary>
        /// Start the iteration-process
        /// </summary>
        /// <param name="options">Parsing options</param>
        public void Run(Options options)
        {
            var Engine = new Engine();
            Engine.Run(options.Path, ReportExtension, FileName, FileExtension);
        }
    }
}
