using CommandLine;

namespace FileMonitoringTool
{
    class Program
    {
        static int Main(string[] args)
        {
            return CommandLine.Parser.Default.ParseArguments<Options>(args)
              .MapResult(
                (Options options) => { new FileMonitoringTool().Run(options); return 0; },
                errs => 1);
        }
    }
}