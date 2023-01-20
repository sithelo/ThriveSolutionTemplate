using CardTransactionHostedService.Core.Entities;
using CardTransactionHostedService.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CardTransactionHostedService.Infrastructure.Data;


public class TransactionRepository : IRepository
{
  private readonly AppDbContext _dbContext;

  public TransactionRepository(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public T GetById<T>(int id) where T : BaseEntity
  {
    return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
  }

  public List<T> List<T>() where T : BaseEntity
  {
    return _dbContext.Set<T>().ToList();
  }

  public T Add<T>(T entity) where T : BaseEntity
  {
    _dbContext.Set<T>().Add(entity);
    _dbContext.SaveChanges();

    return entity;
  }

  public void Delete<T>(T entity) where T : BaseEntity
  {
    _dbContext.Set<T>().Remove(entity);
    _dbContext.SaveChanges();
  }

  public void Update<T>(T entity) where T : BaseEntity
  {
    _dbContext.Entry(entity).State = EntityState.Modified;
    _dbContext.SaveChanges();
  }
}
