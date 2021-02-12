using CommandLine;

namespace CLIExample
{
    [Verb("grpc", HelpText = "Runs the gRPC server.")]
    public class GrpcOptions
    {
        [Option('p', "port", Default = 50051, HelpText = "specifies the port the server runs")]
        public int Port { get; set; }
    }
}
