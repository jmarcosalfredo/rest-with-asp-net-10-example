using rest_with_asp_net_10_example.Model;

namespace rest_with_asp_net_10_example.Services;

public interface IPersonServices
{
    Person Create(Person person);

    Person FindById(long id);

    List<Person> FindAll();

    Person Update(Person person);

    void Delete(long id);
}
