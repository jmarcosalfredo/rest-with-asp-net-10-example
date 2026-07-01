using rest_with_asp_net_10_example.Data.Converter.Impl;
using rest_with_asp_net_10_example.Data.DTO.V2;
using rest_with_asp_net_10_example.Model;
using rest_with_asp_net_10_example.Repositories;

namespace rest_with_asp_net_10_example.Services.Impl;

public class PersonServicesImplV2 : IPersonServicesV2
{
    private IRepository<Person> _repository;
    private readonly PersonConverter _converter;

    public PersonServicesImplV2(IRepository<Person> repository)
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
}
