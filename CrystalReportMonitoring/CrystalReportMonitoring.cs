namespace CrystalReportMonitoring
{
    internal sealed class CrystalReportMonitoring
    {
        private const string ReportExtension = "*.rpt";
        private const string FileExtension = ".csv";
        private const string FileName = "CrystalReportsMonitoringFile";

        /// <summary>
        /// Start the iteration-process
        /// </summary>
        /// <param name="options">Parsing options</param>
        public void Run(Options options)
        {
            var engine = new Engine();
            engine.Process(options.Path, ReportExtension, FileName, FileExtension);
        }
    }
}