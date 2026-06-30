using rest_with_asp_net_10_example.Model;

namespace rest_with_asp_net_10_example.Repositories;

public interface IBookRepository
{
    Book Create(Book book);

    Book FindById(long id);

    List<Book> FindAll();

    Book Update(Book book);

    void Delete(long id);
}
