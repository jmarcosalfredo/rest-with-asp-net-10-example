using rest_with_asp_net_10_example.Model;
using rest_with_asp_net_10_example.Model.Context;
using rest_with_asp_net_10_example.Repositories;

namespace rest_with_asp_net_10_example.Services.Impl;

public class PersonServicesImpl : IPersonServices
{
    private IPersonRepository _repository;

    public PersonServicesImpl(IPersonRepository repository)
    {
        _repository = repository;
    }

    public Person Create(Person person)
    {
        return _repository.Create(person);
        
    }

    public Person Update(Person person)
    {
        return _repository.Update(person);
    }

    public List<Person> FindAll()
    {
        return _repository.FindAll();
    }

    public Person FindById(long id)
    {
        return _repository.FindById(id);
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }
}
