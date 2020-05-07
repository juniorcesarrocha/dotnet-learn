using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository) 
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<IEnumerable<Produto>> ListarTodosAsync()
        {
            return await _produtoRepository.ListarTodosAsync();
        }
        public async Task<Produto> BuscarPorIdAsync(int id)
        {
            return await _produtoRepository.BuscarPorIdAsync(id);
        }
        public async Task InserirAsync(Produto produto)
        {
            await _produtoRepository.InserirAsync(produto);
            await _produtoRepository.CommitAsync();
        }        
        public async Task AtualizarAsync(Produto produto)
        {
            _produtoRepository.AtualizarAsync(produto);
            await _produtoRepository.CommitAsync();
        }                
        public async Task RemoverAsync(int id)
        {
            var produto = await BuscarPorIdAsync(id);
            _produtoRepository.RemoverAsync(produto);
            await _produtoRepository.CommitAsync();
        }
    }
}