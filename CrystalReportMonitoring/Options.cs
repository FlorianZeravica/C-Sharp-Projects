using CommandLine;

namespace CrystalReportMonitoring
{
    /// <summary>
    /// Options, which can be pre-set to require some input from user
    /// </summary>
    internal sealed class Options
    {
        [Option('p', "path", Required = true, HelpText = "The required base path to iterate through.")]
        public string Path { get; set; }
    }
}