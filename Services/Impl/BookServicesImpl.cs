using rest_with_asp_net_10_example.Data.DTO;
using rest_with_asp_net_10_example.Model;
using rest_with_asp_net_10_example.Repositories;

namespace rest_with_asp_net_10_example.Services.Impl;

public class BookServicesImpl : IBookServices
{
    private IRepository<Book> _repository;
    private readonly BookConverter _converter;

    public BookServicesImpl(IRepository<Book> repository)
    {
        _repository = repository;
        _converter = new BookConverter();
    }

    public BookDTO Create(BookDTO book)
    {
        var entity = _converter.Parse(book);
        entity = _repository.Create(entity);
        return _converter.Parse(entity);
        
    }

    public BookDTO Update(BookDTO book)
    {
        var entity = _converter.Parse(book);
        entity = _repository.Update(entity);
        return _converter.Parse(entity);
    }

    public List<BookDTO> FindAll()
    {
        return _converter.ParseList(_repository.FindAll());
    }

    public BookDTO FindById(long id)
    {
        return _converter.Parse(_repository.FindById(id));
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }
}
