using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Domain.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;
        public EstoqueService(IEstoqueRepository estoqueRepository) 
        {
            _estoqueRepository = estoqueRepository;
        }
        public async Task<IEnumerable<Estoque>> ListarTodosAsync()
        {
            return await _estoqueRepository.ListarTodosAsync();
        }
        public async Task<Estoque> BuscarPorIdAsync(int id)
        {
            return await _estoqueRepository.BuscarPorIdAsync(id);
        }
        public async Task<Estoque> BuscarPorIdProdutoAsync(int idProduto)
        {
            return await _estoqueRepository.BuscarPorIdProdutoAsync(idProduto);
        }
        public async Task InserirAsync(Estoque estoque)
        {
            await _estoqueRepository.InserirAsync(estoque);
            await _estoqueRepository.CommitAsync();
        }

        public async Task AtualizarAsync(Estoque estoque)
        {
            _estoqueRepository.AtualizarAsync(estoque);
            await _estoqueRepository.CommitAsync();
        }
        public async Task RemoverAsync(int id)
        {
            var estoque = await BuscarPorIdAsync(id);
            _estoqueRepository.RemoverAsync(estoque);
            await _estoqueRepository.CommitAsync();
        }
    }
}