using System;

namespace ContasCorrentes.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable 
        where TEntity : class
    {
        int Create(TEntity entity);
        int Delete(int Id);
        TEntity Find(int Id);
        int Update(TEntity entity);
    }
}
