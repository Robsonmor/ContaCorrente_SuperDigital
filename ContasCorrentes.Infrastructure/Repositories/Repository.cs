using ContasCorrentes.Domain.Interfaces.Repositories;
using ContasCorrentes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContasCorrentes.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EFContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(EFContext dbcontext)
        {
            _dbContext = dbcontext;
            _dbSet = dbcontext.Set<TEntity>();
        }

        public virtual int Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return _dbContext.SaveChanges();
        }

        public virtual int Delete(int Id)
        {
            // Nao costuma ser utilizado
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            _dbContext.Dispose();
        }

        public virtual TEntity Find(int Id)
        {
           return _dbSet.Find(Id);
        }

        public virtual int Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
