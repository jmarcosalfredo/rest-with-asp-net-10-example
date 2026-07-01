using rest_with_asp_net_10_example.Data.DTO.V1;
using rest_with_asp_net_10_example.Model;

namespace rest_with_asp_net_10_example.Services;

public interface IBookServices
{
    BookDTO Create(BookDTO book);

    BookDTO FindById(long id);

    List<BookDTO> FindAll();

    BookDTO Update(BookDTO book);

    void Delete(long id);
}
