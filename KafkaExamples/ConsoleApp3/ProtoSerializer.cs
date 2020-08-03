using Confluent.Kafka;
using System;
using System.Collections.Generic;
using Google.Protobuf;
using System.Text;

namespace ConsoleApp3
{
    public class ProtoSerializer<T> : ISerializer<T> where T : Google.Protobuf.IMessage<T>
    {
        public IEnumerable<KeyValuePair<string, object>>
            Configure(IEnumerable<KeyValuePair<string, object>> config, bool isKey)
                => config;

        public void Dispose() { }

        public byte[] Serialize(string topic, T data) //Deprecated?
            => data.ToByteArray();

        public byte[] Serialize(T data, SerializationContext context)
            => data.ToByteArray();
    }
}
