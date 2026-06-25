using rest_with_asp_net_10_example.Model;
using rest_with_asp_net_10_example.Model.Context;

namespace rest_with_asp_net_10_example.Services.Impl;

public class PersonServicesImpl : IPersonServices
{
    private MSSQLContext _context;

    public PersonServicesImpl(MSSQLContext context)
    {
        _context = context;
    }

    public Person Create(Person person)
    {
        _context.Persons.Add(person);
        _context.SaveChanges();
        return person;
    }

    public Person Update(Person person)
    {
        var existingPerson = _context.Persons.Find(person.Id);
        if (existingPerson == null)
        {
            throw new Exception("Person not found");
        }
        
        _context.Entry(existingPerson).CurrentValues.SetValues(person);
        _context.SaveChanges();
        return person;
    }

    public List<Person> FindAll()
    {
        return _context.Persons.ToList();
    }

    public Person FindById(long id)
    {
        return _context.Persons.Find(id) ?? new Person();
    }

    public void Delete(long id)
    {
        var existingPerson = _context.Persons.Find(id);
        if (existingPerson == null)
        {
            throw new Exception("Person not found");
        }
        _context.Persons.Remove(existingPerson);
        _context.SaveChanges();
    }
}
