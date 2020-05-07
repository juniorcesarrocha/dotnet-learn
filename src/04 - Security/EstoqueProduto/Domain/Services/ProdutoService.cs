using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;
using EstoqueProduto.Domain.Validations;
using EstoqueProduto.Infra.Notifications;

namespace EstoqueProduto.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IRequestNotificator _notifications;
        public ProdutoService(IProdutoRepository produtoRepository,
                                IRequestNotificator notifications)
        {
            _produtoRepository = produtoRepository;
            _notifications = notifications;
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
            var validationResult = new NovoProdutoValidation().Validate(produto);

            if (!validationResult.IsValid)  
            {
                _notifications.Add(validationResult);                
                return;
            }

            await _produtoRepository.InserirAsync(produto);
            await _produtoRepository.CommitAsync();
        }        
        public async Task AtualizarAsync(Produto produto)
        {
            var validationResult = new AtualizacaoProdutoValidation().Validate(produto);

            if (!validationResult.IsValid)  
            {
                _notifications.Add(validationResult);                
                return;
            }

            _produtoRepository.AtualizarAsync(produto);
            await _produtoRepository.CommitAsync();
        }                
        public async Task RemoverAsync(int id)
        {
            var produto = await BuscarPorIdAsync(id) ?? new Produto();
            var validationResult = new ExclusaoProdutoValidation().Validate(produto);

            if (!validationResult.IsValid)  
            {
                _notifications.Add(validationResult);                
                return;
            }

            _produtoRepository.RemoverAsync(produto);
            await _produtoRepository.CommitAsync();
        }
    }
}