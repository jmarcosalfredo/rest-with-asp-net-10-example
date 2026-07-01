using rest_with_asp_net_10_example.Data.DTO;
using rest_with_asp_net_10_example.Model;

namespace rest_with_asp_net_10_example.Services;

public interface IPersonServices
{
    PersonDTO Create(PersonDTO PersonDTO);

    PersonDTO FindById(long id);

    List<PersonDTO> FindAll();

    PersonDTO Update(PersonDTO PersonDTO);

    void Delete(long id);
}
