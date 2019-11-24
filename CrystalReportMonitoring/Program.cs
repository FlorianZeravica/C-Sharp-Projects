using CommandLine;

namespace CrystalReportMonitoring
{
    class Program
    {
        static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<Options>(args)
              .MapResult(
                (Options options) => { new CrystalReportMonitoring().Run(options); return 0; },
                errs => 1);
        }
    }
}