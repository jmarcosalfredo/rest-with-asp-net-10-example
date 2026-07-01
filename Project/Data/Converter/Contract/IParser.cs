namespace rest_with_asp_net_10_example.Data.Converter.Contract;

public interface IParser<O, D>
{
    D Parse(O origin);
    List<D> ParseList(List<O> origin);
}
