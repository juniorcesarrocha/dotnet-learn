using System.Threading.Tasks;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Domain.Contracts.Data
{
    public interface IEstoqueRepository : IRepository<Estoque>
    {
        Task<Estoque> BuscarPorIdProdutoAsync(int idProduto);
    }
}