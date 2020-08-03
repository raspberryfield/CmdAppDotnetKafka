using Confluent.Kafka;
using Google.Protobuf.Examples.Person;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World! - ConsoleApp3 Kafka/protobuf.");
            Console.WriteLine("press any button to send message...");
            Console.ReadLine();

            var config = new ProducerConfig
            {
                BootstrapServers = "172.18.82.14:9092"
          
            };

        
            // If serializers are not specified, default serializers from
            // `Confluent.Kafka.Serializers` will be automatically used where
            // available. Note: by default strings are encoded as UTF8.
            using (var producer = new ProducerBuilder<Null, Person>(config).SetValueSerializer(new ProtoSerializer<Person>()).Build())
            {
                try
                {
                    var dr = await producer.ProduceAsync("my_first_topic", new Message<Null, Person> { Value = new Person {Name = "Lena", Age = 34} });
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
