using rest_with_asp_net_10_example.Model;
using rest_with_asp_net_10_example.Repositories;

namespace rest_with_asp_net_10_example.Services.Impl;

public class BookServicesImpl : IBookServices
{
    private IRepository<Book> _repository;

    public BookServicesImpl(IRepository<Book> repository)
    {
        _repository = repository;
    }

    public Book Create(Book book)
    {
        return _repository.Create(book);
        
    }

    public Book Update(Book book)
    {
        return _repository.Update(book);
    }

    public List<Book> FindAll()
    {
        return _repository.FindAll();
    }

    public Book FindById(long id)
    {
        return _repository.FindById(id);
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }
}
