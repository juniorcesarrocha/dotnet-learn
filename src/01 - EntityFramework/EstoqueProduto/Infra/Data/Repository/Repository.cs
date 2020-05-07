using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstoqueProduto.Infra.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly EstoqueProdutoContext _dbContext;

        public Repository(EstoqueProdutoContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> ListarTodosAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public virtual async Task<T> BuscarPorIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<T> InserirAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }
        public T AtualizarAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;            
            return entity;
        }
        public void RemoverAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
        public void Dispose()
        {
            _dbContext?.Dispose();
        }
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}