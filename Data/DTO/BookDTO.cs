namespace rest_with_asp_net_10_example.Data.DTO;

public class BookDTO
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public decimal Price { get; set; }
    public DateTime LaunchDate { get; set; }
}
