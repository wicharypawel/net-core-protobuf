using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using NetCoreProtobuf.Proto.Generated;
using System;
using System.IO;

namespace NetCoreProtobuf.ConsoleApp.SimpleSerialization
{
    // Example was originally presented by https://github.com/protocolbuffers/protobuf/tree/master/csharp/src
    public sealed class Program
    {
        public static void Main()
        {
            var person = new Person
            {
                Id = 1,
                Name = "Foo",
                Email = "foo@bar",
                Phones = { new PhoneNumber { Number = "555-1212" } },
                LastUpdated = Timestamp.FromDateTime(DateTime.UtcNow)
            };
            Console.WriteLine($"Created person: {person.Name} with id {person.Id}");
            using var stream = new MemoryStream();
            person.WriteTo(stream);
            Console.WriteLine("Person serialised to stream");
            var bytes = stream.ToArray();
            Person copy = Person.Parser.ParseFrom(bytes);
            Console.WriteLine("Parse from stream");
            Console.WriteLine($"Recreated person: {copy.Name} with id {copy.Id}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}