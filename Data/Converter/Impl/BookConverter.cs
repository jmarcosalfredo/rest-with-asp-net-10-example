using rest_with_asp_net_10_example.Data.Converter.Contract;
using rest_with_asp_net_10_example.Data.DTO;
using rest_with_asp_net_10_example.Model;

namespace rest_with_asp_net_10_example;

public class BookConverter : IParser<BookDTO, Book>, IParser<Book, BookDTO>
{
    public Book Parse(BookDTO origin)
    {
        if (origin == null) return null!;
        return new Book
        {
            Id = origin.Id,
            Author = origin.Author,
            LaunchDate = origin.LaunchDate,
            Price = origin.Price,
            Title = origin.Title
        };
    }

    public BookDTO Parse(Book origin)
    {
        if (origin == null) return null!;
        return new BookDTO
        {
            Id = origin.Id,
            Author = origin.Author,
            LaunchDate = origin.LaunchDate,
            Price = origin.Price,
            Title = origin.Title
        };
    }

    public List<Book> ParseList(List<BookDTO> origin)
    {
        if (origin == null) return null!;
        return origin.Select(item => Parse(item)).ToList();
    }
    
    public List<BookDTO> ParseList(List<Book> origin)
    {
        if (origin == null) return null!;
        return origin.Select(item => Parse(item)).ToList();
    }
}