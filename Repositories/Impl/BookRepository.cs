using rest_with_asp_net_10_example.Model;
using rest_with_asp_net_10_example.Model.Context;

namespace rest_with_asp_net_10_example.Repositories.Impl;

public class BookRepository : IBookRepository
{
        private MSSQLContext _context;

    public BookRepository(MSSQLContext context)
    {
        _context = context;
    }

    public Book Create(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
        return book;
    }

    public Book Update(Book book)
    {
        var existingBook = _context.Books.Find(book.Id);
        if (existingBook == null)
        {
            throw new Exception("Book not found");
        }
        
        _context.Entry(existingBook).CurrentValues.SetValues(book);
        _context.SaveChanges();
        return book;
    }

    public List<Book> FindAll()
    {
        return _context.Books.ToList();
    }

    public Book FindById(long id)
    {
        return _context.Books.Find(id) ?? new Book();
    }

    public void Delete(long id)
    {
        var existingBook = _context.Books.Find(id);
        if (existingBook == null)
        {
            throw new Exception("Book not found");
        }
        _context.Books.Remove(existingBook);
        _context.SaveChanges();
    }
}
