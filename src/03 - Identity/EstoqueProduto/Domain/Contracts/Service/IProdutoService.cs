using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Domain.Contracts.Service
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ListarTodosAsync();
        Task<Produto> BuscarPorIdAsync(int id);
        Task InserirAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
        Task RemoverAsync(int id);
    }
}