using Google.Protobuf;
using NetCoreProtobuf.Proto.Generated;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace NetCoreProtobuf.Proto.Tests
{
    public class AddressBookTests
    {
        private readonly List<Person> _peopleList;
        public AddressBookTests()
        {

            _peopleList = new List<Person>()
            {
                new Person
                {
                    Id = 1,
                    Name = "Foo",
                    Email = "foo@bar",
                    Phones = { new PhoneNumber { Number = "555-1212" } }
                },
                new Person
                {
                    Id = 2,
                    Name = "Bar",
                    Email = "bar@foo",
                    Phones = { new PhoneNumber { Number = "116-1412", Type = PhoneType.Mobile } }
                },

            };
        }

        [Fact]
        public void ParseAddressBookToStreamAndOut()
        {
            // Arrange
            var addressBook = new AddressBook();
            addressBook.People.Add(_peopleList);
            using MemoryStream stream = new MemoryStream();
            // Act
            addressBook.WriteTo(stream);
            var bytes = stream.ToArray();
            var copy = AddressBook.Parser.ParseFrom(bytes);
            // Assert
            Assert.Equal(addressBook.People.Capacity, copy.People.Capacity);
            Assert.Equal(addressBook.People[0].Id, copy.People[0].Id);
            Assert.Equal(addressBook.People[0].Email, copy.People[0].Email);
            Assert.Equal(addressBook.People[0].Phones[0].Number, copy.People[0].Phones[0].Number);
        }

        [Fact]
        public void ParseAddressBookToByteArrayAndOut()
        {
            // Arrange
            var addressBook = new AddressBook();
            addressBook.People.Add(_peopleList);
            // Act
            var bytes = addressBook.ToByteArray();
            var copy = AddressBook.Parser.ParseFrom(bytes);
            // Assert
            Assert.Equal(addressBook.People.Capacity, copy.People.Capacity);
            Assert.Equal(addressBook.People[0].Id, copy.People[0].Id);
            Assert.Equal(addressBook.People[0].Email, copy.People[0].Email);
            Assert.Equal(addressBook.People[0].Phones[0].Number, copy.People[0].Phones[0].Number);
        }

        [Fact]
        public void ParseAddressBookToByteStringAndOut()
        {
            // Arrange
            var addressBook = new AddressBook();
            addressBook.People.Add(_peopleList);
            // Act
            var byteString = addressBook.ToByteString();
            var copy = AddressBook.Parser.ParseFrom(byteString);
            // Assert
            Assert.Equal(addressBook.People.Capacity, copy.People.Capacity);
            Assert.Equal(addressBook.People[0].Id, copy.People[0].Id);
            Assert.Equal(addressBook.People[0].Email, copy.People[0].Email);
            Assert.Equal(addressBook.People[0].Phones[0].Number, copy.People[0].Phones[0].Number);
        }
    }
}
