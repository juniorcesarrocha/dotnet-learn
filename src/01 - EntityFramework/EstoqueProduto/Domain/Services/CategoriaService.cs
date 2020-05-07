using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Domain.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository) 
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<IEnumerable<Categoria>> ListarTodosAsync()
        {
            return await _categoriaRepository.ListarTodosAsync();
        }
        public async Task<Categoria> BuscarPorIdAsync(int id)
        {
            return await _categoriaRepository.BuscarPorIdAsync(id);
        }
        public async Task InserirAsync(Categoria categoria)
        {
            await _categoriaRepository.InserirAsync(categoria);
            await _categoriaRepository.CommitAsync();
        }        
        public async Task AtualizarAsync(Categoria categoria)
        {
            _categoriaRepository.AtualizarAsync(categoria);
            await _categoriaRepository.CommitAsync();
        }                
        public async Task RemoverAsync(int id)
        {
            var categoria = await BuscarPorIdAsync(id);
            _categoriaRepository.RemoverAsync(categoria);
            await _categoriaRepository.CommitAsync();
        }
    }
}