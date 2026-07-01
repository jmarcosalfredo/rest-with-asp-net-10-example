using Mapster;
using rest_with_asp_net_10_example.Data.DTO.V1;
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

    public BookDTO Create(BookDTO book)
    {
        var entity = book.Adapt<Book>();
        entity = _repository.Create(entity);
        return entity.Adapt<BookDTO>();
        
    }

    public BookDTO Update(BookDTO book)
    {
        var entity = book.Adapt<Book>();
        entity = _repository.Update(entity);
        return entity.Adapt<BookDTO>();
    }

    public List<BookDTO> FindAll()
    {
        return _repository.FindAll().Adapt<List<BookDTO>>();
    }

    public BookDTO FindById(long id)
    {
        return _repository.FindById(id).Adapt<BookDTO>();
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }
}
