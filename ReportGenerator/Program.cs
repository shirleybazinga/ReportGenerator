using System;
using CommandLine;

namespace ReportGenerator
{
    public class Program
    {
        public class Options
        {
            [Option('v', "verbose", Default = false, HelpText = "Prints all messages to standard output.")]
            public bool Verbose { get; set; }

            [Option('t', "test", Default = false, HelpText = "Run unit test with test data.")]
            public bool UnitTest { get; set; }

            [Option('p', "product", Required = true, HelpText = "Input product type to be processed, e.g., FxForward or \"Fx Forward\", BondFuture or \"Bond Future\", InterestRateSwap or \"Interest Rate Swap\", etc.")]
            public string Product { get; set; }

            [Option('b', "broker", Required = true, HelpText = "Input broker to be processed, e.g., Broker-A, Broker-B, etc.")]
            public string Broker { get; set; }

            [Option('d', "date", Required = true, HelpText = "Input date to be processed, e.g., \"8 Apr 2021\".")]
            public DateTime Date { get; set; }

            [Option('o', "output", Required = true, HelpText = "Full path of the output report.")]
            public string OutputPath { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Input params: {(args.Length > 0 ? string.Join(", ", args) : "None")}");
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);
        }

        public static void RunOptions(Options opts)
        {
            if (opts.Verbose)
            {
                Console.WriteLine($"Verbose output enabled. Current Arguments: -v {opts.Verbose}, -t {opts.UnitTest}, -p {opts.Product}, -b {opts.Broker}, -d {opts.Date}, -o {opts.OutputPath}");
            }
            else
            {
                Console.WriteLine($"Verbose output disabled.");
            }

            var dataAccess = new DataAccess(opts.UnitTest ? new TestData() : new CreateStub(opts.Date));
            var data = dataAccess.GetTrades(opts.Broker, opts.Product, opts.Date);
            var reportGenerator = new ReportGeneratorFactory().GetReportGenerator(opts.Broker, opts.Product);
            reportGenerator.Generate(data, opts.OutputPath);
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {
            Console.WriteLine($"Failed to parse input params.");
        }
    }
}
