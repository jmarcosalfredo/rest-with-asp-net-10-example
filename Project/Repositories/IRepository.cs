using rest_with_asp_net_10_example.Model.Base;

namespace rest_with_asp_net_10_example.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    List<T> FindAll();
    T FindById(long id);
    T Create(T item);
    T Update(T item);
    void Delete(long id);
    bool Exists(long id);
}
