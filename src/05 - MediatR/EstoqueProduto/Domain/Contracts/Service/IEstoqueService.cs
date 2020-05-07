using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Domain.Contracts.Service
{
    public interface IEstoqueService
    {
        Task<IEnumerable<Estoque>> ListarTodosAsync();
        Task<Estoque> BuscarPorIdAsync(int id);
        Task<Estoque> BuscarPorIdProdutoAsync(int idProduto);
        Task InserirAsync(Estoque estoque);
        Task AtualizarAsync(Estoque estoque);
        Task RemoverAsync(int id);
    }
}