using CommandLine;

namespace CLIExample
{
    [Verb("kafka", HelpText = "Runs Kafka consumers/producers.")]
    public class KafkaOptions
    {
        [Option('t', "topic", Default = "my-topic", HelpText = "specifies the topic")]
        public string Topic { get; set; }

        [Option('c', "consumers", Default = 2, HelpText = "specifies the consumers")]
        public int Consumers { get; set; }

        [Option('p', "producers", Default = 1, HelpText = "specifies the producers")]
        public int Producers { get; set; }
    }
}
