using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Domain.Contracts.Service
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ListarTodosAsync();
        Task<Categoria> BuscarPorIdAsync(int id);
        Task InserirAsync(Categoria categoria);
        Task AtualizarAsync(Categoria categoria);
        Task RemoverAsync(int id);        
    }
}