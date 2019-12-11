using CommandLine;

namespace FileMonitoringTool
{
    internal sealed class Options
    {
        [Option('p', "path", Required = true, HelpText = "The required base path to iterate through.")]
        public string Path { get; set; }
    }
}
