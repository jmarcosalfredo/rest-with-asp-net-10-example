using rest_with_asp_net_10_example.Data.DTO.V2;

namespace rest_with_asp_net_10_example.Services;

public interface IPersonServicesV2
{
    PersonDTO Create(PersonDTO PersonDTO);
    PersonDTO Update(PersonDTO PersonDTO);
}
