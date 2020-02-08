using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using NetCoreProtobuf.Proto.Generated;
using System;
using System.IO;
using Xunit;

namespace NetCoreProtobuf.Proto.Tests
{
    public class PersonTests
    {
        [Fact]
        public void ParsePersonToStreamAndOut()
        {
            // Arrange
            var person = new Person
            {
                Id = 1,
                Name = "Foo",
                Email = "foo@bar",
                Phones = { new PhoneNumber { Number = "555-1212" } },
                LastUpdated = Timestamp.FromDateTime(DateTime.UtcNow)
            };
            using MemoryStream stream = new MemoryStream();
            // Act
            person.WriteTo(stream);
            var bytes = stream.ToArray();
            var copy = Person.Parser.ParseFrom(bytes);
            // Assert
            Assert.Equal(person.Id, copy.Id);
            Assert.Equal(person.Name, copy.Name);
            Assert.Equal(person.Email, copy.Email);
            Assert.Equal(person.Phones.Count, copy.Phones.Count);
            Assert.Equal(person.Phones[0].Number, copy.Phones[0].Number);
            Assert.Equal(person.Phones[0].Type, copy.Phones[0].Type);
            Assert.Equal(DateTime.UtcNow, person.LastUpdated.ToDateTime(), TimeSpan.FromSeconds(2));
        }

        [Fact]
        public void ParsePersonToByteArrayAndOut()
        {
            // Arrange
            var person = new Person
            {
                Id = 1,
                Name = "Foo",
                Email = "foo@bar",
                Phones = { new PhoneNumber { Number = "555-1212" } }
            };
            // Act
            var bytes = person.ToByteArray();
            var copy = Person.Parser.ParseFrom(bytes);
            // Assert
            Assert.Equal(person.Id, copy.Id);
            Assert.Equal(person.Name, copy.Name);
            Assert.Equal(person.Email, copy.Email);
            Assert.Equal(person.Phones.Count, copy.Phones.Count);
            Assert.Equal(person.Phones[0].Number, copy.Phones[0].Number);
            Assert.Equal(person.Phones[0].Type, copy.Phones[0].Type);
        }

        [Fact]
        public void ParsePersonToByteStringAndOut()
        {
            // Arrange
            var person = new Person
            {
                Id = 1,
                Name = "Foo",
                Email = "foo@bar",
                Phones = { new PhoneNumber { Number = "555-1212" } }
            };
            // Act
            var byteString = person.ToByteString();
            var copy = Person.Parser.ParseFrom(byteString);
            // Assert
            Assert.Equal(person.Id, copy.Id);
            Assert.Equal(person.Name, copy.Name);
            Assert.Equal(person.Email, copy.Email);
            Assert.Equal(person.Phones.Count, copy.Phones.Count);
            Assert.Equal(person.Phones[0].Number, copy.Phones[0].Number);
            Assert.Equal(person.Phones[0].Type, copy.Phones[0].Type);
        }
    }
}
