using CommandLine;
using System;

namespace CLIExample
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            return Parser.Default.ParseArguments(args, new[] { typeof(KafkaOptions), typeof(GrpcOptions) })
                .MapResult
                (
                    (KafkaOptions opts) => { Console.WriteLine($"kafka: {opts.Topic} : {opts.Consumers} : {opts.Producers}"); return 0; },
                    (GrpcOptions opts) => { Console.WriteLine($"grpc: {opts.Port}"); return 0; },
                    errs => 1
                );
        }
    }
}
