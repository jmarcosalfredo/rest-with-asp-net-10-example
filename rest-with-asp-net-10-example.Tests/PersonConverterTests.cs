using FluentAssertions;
using rest_with_asp_net_10_example.Data.Converter.Impl;
using rest_with_asp_net_10_example.Data.DTO.V2;
using rest_with_asp_net_10_example.Model;

namespace rest_with_asp_net_10_example.Tests
{

    public class PersonConverterTests
    {
        private readonly PersonConverter _converter;

        public PersonConverterTests()
        {
            _converter = new PersonConverter();
        }

        //PersonDTO to Person conversion tests
        [Fact]
        public void Parse_ShouldConvertPersonDTOToPerson()
        {
            // Arrange: Prepare the data, objects, and any necessary dependencies for the test.
            var dto = new PersonDTO
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male",
                BirthDay = new DateTime(1869, 10, 2)
            };
            var expectedPerson = new Person
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male",
            };
            // Act: Call the method under test with the prepared data.
            var person = _converter.Parse(dto);
            // Assert: Verify that the result matches the expected outcome.
            person.Should().NotBeNull();
            person.Id.Should().Be(expectedPerson.Id);
            person.FirstName.Should().Be(expectedPerson.FirstName);
            person.LastName.Should().Be(expectedPerson.LastName);
            person.Address.Should().Be(expectedPerson.Address);
            person.Should().BeEquivalentTo(expectedPerson);
        }

        [Fact]
        public void Parse_ShouldReturnNull_WhenPersonDTOIsNull()
        {
            // Arrange: Prepare the data, objects, and any necessary dependencies for the test.
            PersonDTO? dto = null;
            // Act: Call the method under test with the prepared data.

#pragma warning disable CS8604 // Possible null reference argument.
            var person = _converter.Parse(dto);
#pragma warning restore CS8604 // Possible null reference argument.

            // Assert: Verify that the result matches the expected outcome.
            person.Should().BeNull();
        }

        //Person to PersonDTO conversion tests
        [Fact]
        public void Parse_ShouldConvertPersonToPersonDTO()
        {
            // Arrange: Prepare the data, objects, and any necessary dependencies for the test.
            var entity = new Person
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male",
                // BirthDay = new DateTime(1869, 10, 2)
            };
            var expectedPerson = new PersonDTO
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male",
            };
            // Act: Call the method under test with the prepared data.
            var person = _converter.Parse(entity);
            // Assert: Verify that the result matches the expected outcome.
            person.Should().NotBeNull();
            person.Id.Should().Be(expectedPerson.Id);
            person.FirstName.Should().Be(expectedPerson.FirstName);
            person.LastName.Should().Be(expectedPerson.LastName);
            person.Address.Should().Be(expectedPerson.Address);
            person.Should().BeEquivalentTo(expectedPerson, options => options.Excluding(person => person.BirthDay));
            person.BirthDay.Should().NotBeNull();
        }

        [Fact]
        public void Parse_ShouldReturnNull_WhenPersonIsNull()
        {
            // Arrange: Prepare the data, objects, and any necessary dependencies for the test.
            Person? dto = null;
            // Act: Call the method under test with the prepared data.

#pragma warning disable CS8604 // Possible null reference argument.
            var person = _converter.Parse(dto);
#pragma warning restore CS8604 // Possible null reference argument.

            // Assert: Verify that the result matches the expected outcome.
            person.Should().BeNull();
        }

        [Fact]
        public void ParseList_ShouldConvertPersonDTOListToPersonList()
        {
            // Arrange: Prepare the data, objects, and any necessary dependencies for the test.
            var dtoList = new List<PersonDTO>
            {
                new PersonDTO
                {
                    Id = 1,
                    FirstName = "Mahatma",
                    LastName = "Gandhi",
                    Address = "Porbandar - India",
                    Gender = "Male",
                    BirthDay = new DateTime(1869, 10, 2)
                },
                new PersonDTO
                {
                    Id = 2,
                    FirstName = "Indira",
                    LastName = "Gandhi",
                    Address = "Allahabad - India",
                    Gender = "Female",
                    BirthDay = new DateTime(1917, 11, 19)
                }
            };
            // Act: Call the method under test with the prepared data.
            var personList = _converter.ParseList(dtoList);

            // Assert: Verify that the result matches the expected outcome.
            personList.Should().NotBeNull();
            personList.Count.Should().Be(2);
            personList[0].Should().BeEquivalentTo(new Person
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male",
                // BirthDay = new DateTime(1869, 10, 2)
            });
            personList[1].Should().BeEquivalentTo(new Person
            {
                Id = 2,
                FirstName = "Indira",
                LastName = "Gandhi",
                Address = "Allahabad - India",
                Gender = "Female",
                // BirthDay = new DateTime(1917, 11, 19)
            });
        }

        [Fact]
        public void Parse_NullListPersonDTOShouldReturnNull()
        {
            // Arrange: Prepare the data, objects, and any necessary dependencies for the test.
            List<PersonDTO>? dto = null;
            // Act: Call the method under test with the prepared data.

#pragma warning disable CS8604 // Possible null reference argument.
            var listPerson = _converter.ParseList(dto);
#pragma warning restore CS8604 // Possible null reference argument.

            // Assert: Verify that the result matches the expected outcome.
            listPerson.Should().BeNull();
        }

        [Fact]
        public void ParseList_ShouldConvertPersonListToPersonDTOList()
        {
            // Arrange: Prepare the data, objects, and any necessary dependencies for the test.
            var personList = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    FirstName = "Mahatma",
                    LastName = "Gandhi",
                    Address = "Porbandar - India",
                    Gender = "Male"
                    // BirthDay = new DateTime(1869, 10, 2)

                },
                new Person
                {
                    Id = 2,
                    FirstName = "Indira",
                    LastName = "Gandhi",
                    Address = "Allahabad - India",
                    Gender = "Female",
                    //BirthDay = new DateTime(1917, 11, 19)
                }
            };
            // Act: Call the method under test with the prepared data.
            var dtoList = _converter.ParseList(personList);

            // Assert: Verify that the result matches the expected outcome.
            personList.Should().NotBeNull();
            personList.Count.Should().Be(2);
            personList[0].Should().BeEquivalentTo(new PersonDTO
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male",
                BirthDay = new DateTime(1869, 10, 2)
            }, options => options.Excluding(dto => dto.BirthDay));
            personList[1].Should().BeEquivalentTo(new PersonDTO
            {
                Id = 2,
                FirstName = "Indira",
                LastName = "Gandhi",
                Address = "Allahabad - India",
                Gender = "Female",
                BirthDay = new DateTime(1917, 11, 19)
            }, options => options.Excluding(dto => dto.BirthDay));
        }

        [Fact]
        public void Parse_NullListPersonShouldReturnNull()
        {
            // Arrange: Prepare the data, objects, and any necessary dependencies for the test.
            List<PersonDTO>? dto = null;
            // Act: Call the method under test with the prepared data.

#pragma warning disable CS8604 // Possible null reference argument.
            var listPerson = _converter.ParseList(dto);
#pragma warning restore CS8604 // Possible null reference argument.

            // Assert: Verify that the result matches the expected outcome.
            listPerson.Should().BeNull();
        }
    }

}