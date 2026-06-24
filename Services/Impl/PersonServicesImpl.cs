using rest_with_asp_net_10_example.Model;

namespace rest_with_asp_net_10_example.Services.Impl;

public class PersonServicesImpl : IPersonServices
{
    public Person Create(Person person)
    {
        return person;
    }

    public Person Update(Person person)
    {
        person.Id = new Random().Next(1, 1000); // Simulating an update by assigning a random Id
        return person;
    }

    public List<Person> FindAll()
    {
        List<Person> persons = new List<Person>();
        for (int i = 0; i < 8; i++)
        {
            var person = MockPerson(i);
            persons.Add(person);
        }

        return persons;
    }

    public Person FindById(long id)
    {
        var person = MockPerson((int)id);

        return person;
    }

    public void Delete(long id)
    {
        // Simulating a delete operation
    }

    private Person MockPerson(int i)
    {
        var person = new Person
        {
            Id = new Random().Next(1, 1000),
            FirstName = "John " + i,
            LastName = "Doe " + i,
            Address = "123 Main St " + i,
            Gender = "Male"
        };

        return person;
    }

}
