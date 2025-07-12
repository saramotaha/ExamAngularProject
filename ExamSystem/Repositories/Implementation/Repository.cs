using ExamSystem.Models;
using ExamSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Asn1;
using System.Threading.Tasks;

namespace ExamSystem.Repositories.Implementation;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ExamContext   _context;

    public Repository(ExamContext context)
    {
        _context=context;
    }

    public async Task AddAsync(T entity)
    {
       await _context.Set<T>().AddAsync(entity);
    }

    public  Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public Task  Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return Task.CompletedTask;
    }


    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
