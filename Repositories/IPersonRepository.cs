using rest_with_asp_net_10_example.Model;

namespace rest_with_asp_net_10_example.Repositories;

public interface IPersonRepository
{
    Person Create(Person person);

    Person FindById(long id);

    List<Person> FindAll();

    Person Update(Person person);

    void Delete(long id);
}
