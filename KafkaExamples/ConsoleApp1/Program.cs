using Confluent.Kafka;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("press any button to send message...");
            Console.ReadLine();

            var config = new ProducerConfig { BootstrapServers = "172.17.209.219:9092"
            };

            // If serializers are not specified, default serializers from
            // `Confluent.Kafka.Serializers` will be automatically used where
            // available. Note: by default strings are encoded as UTF8.
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var dr = await p.ProduceAsync("my_first_topic", new Message<Null, string> { Value = "test2i" });
                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }

            Console.WriteLine("Exiting program...");
        }
    }
}
