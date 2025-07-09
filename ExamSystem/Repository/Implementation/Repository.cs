using ExamSystem.Models;
using ExamSystem.Repository.Interface;

namespace ExamSystem.Repository.Implementation;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ExamContext _context;

    public Repository(ExamContext context)
    {
        _context=context;
    }

    public async Task AddAsync(T entity)
    {
      //await  _context.Set<T>().Add(entity);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}


