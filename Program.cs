using CommandLine;
using System;

namespace CLIExample
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<KafkaOptions, GrpcOptions>(args)
                .MapResult
                (
                    (KafkaOptions opts) => KafkaHandler(opts),
                    (GrpcOptions opts) => GrpcHandler(opts),
                    errs => 1
                );
        }

        private static int KafkaHandler(KafkaOptions opts)
        {
            Console.WriteLine($"kafka: {opts.Topic} : {opts.Consumers} : {opts.Producers}");
            return 0;
        }

        private static int GrpcHandler(GrpcOptions opts)
        {
            Console.WriteLine($"grpc: {opts.Port}");
            return 0;
        }
    }
}
