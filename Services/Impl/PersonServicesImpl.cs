using rest_with_asp_net_10_example.Data.Converter.Impl;
using rest_with_asp_net_10_example.Data.DTO;
using rest_with_asp_net_10_example.Model;
using rest_with_asp_net_10_example.Model.Context;
using rest_with_asp_net_10_example.Repositories;

namespace rest_with_asp_net_10_example.Services.Impl;

public class PersonServicesImpl : IPersonServices
{
    private IRepository<Person> _repository;
    private readonly PersonConverter _converter;

    public PersonServicesImpl(IRepository<Person> repository)
    {
        _repository = repository;
        _converter = new PersonConverter();
    }

    public PersonDTO Create(PersonDTO person)
    {
        var entity = _converter.Parse(person);
        entity = _repository.Create(entity);
        return _converter.Parse(entity);
        
    }

    public PersonDTO Update(PersonDTO person)
    {
        var entity = _converter.Parse(person);
        entity = _repository.Update(entity);
        return _converter.Parse(entity);
    }

    public List<PersonDTO> FindAll()
    {
        return _converter.ParseList(_repository.FindAll());
    }

    public PersonDTO FindById(long id)
    {
        return _converter.Parse(_repository.FindById(id));
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }
}
