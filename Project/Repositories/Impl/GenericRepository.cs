using Microsoft.EntityFrameworkCore;
using rest_with_asp_net_10_example.Model.Base;
using rest_with_asp_net_10_example.Model.Context;

namespace rest_with_asp_net_10_example.Repositories.Impl;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private MSSQLContext _context;
    private DbSet<T> _dataset;

    public GenericRepository(MSSQLContext context)
    {
        _context = context;
        _dataset = context.Set<T>();
    }
    public List<T> FindAll()
    {
        return _dataset.ToList();
    }

    public T FindById(long id)
    {
        return _dataset.Find(id)!;
    }

    public T Create(T item)
    {
        _dataset.Add(item);
        _context.SaveChanges();
        return item;
    }

    public T Update(T item)
    {
        var existingItem = _dataset.Find(item.Id);
        if (existingItem == null)
        {
            throw new Exception("Item not found");
        }

        _context.Entry(existingItem).CurrentValues.SetValues(item);
        _context.SaveChanges();
        return item;
    }

    public void Delete(long id)
    {
        var existingItem = _dataset.Find(id);
        if (existingItem == null)
        {
            throw new Exception("Item not found");
        }
        _dataset.Remove(existingItem);
        _context.SaveChanges();
    }

    public bool Exists(long id)
    {
        return _dataset.Any(e => e.Id == id);
    }
}
