using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Domain.Contracts.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<IEnumerable<T>> ListarTodosAsync();
        Task<T> BuscarPorIdAsync(int id);
        Task<T> InserirAsync(T entity);        
        T AtualizarAsync(T entity);
        void RemoverAsync(T entity);
        Task CommitAsync();
    }
}