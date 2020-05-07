using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;
using EstoqueProduto.Domain.Validations;
using EstoqueProduto.Infra.Notifications;
using MediatR;

namespace EstoqueProduto.Domain.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IRequestNotificator _notifications;
        public EstoqueService(IEstoqueRepository estoqueRepository,
                            IRequestNotificator notifications)
        {
            _estoqueRepository = estoqueRepository;
            _notifications = notifications;
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
            var validationResult = new NovoEstoqueValidation().Validate(estoque);

            if (!validationResult.IsValid)  
            {
                _notifications.Add(validationResult);                
                return;
            }

            await _estoqueRepository.InserirAsync(estoque);
            await _estoqueRepository.CommitAsync();
        }

        public async Task AtualizarAsync(Estoque estoque)
        {
            var validationResult = new AtualizacaoEstoqueValidation().Validate(estoque);

            if (!validationResult.IsValid)  
            {
                _notifications.Add(validationResult);                
                return;
            }

            _estoqueRepository.AtualizarAsync(estoque);
            await _estoqueRepository.CommitAsync();
        }
        public async Task RemoverAsync(int id)
        {
            var estoque = await BuscarPorIdAsync(id) ?? new Estoque();
            var validationResult = new ExclusaoEstoqueValidation().Validate(estoque);

            if (!validationResult.IsValid)  
            {
                _notifications.Add(validationResult);                
                return;
            }

            _estoqueRepository.RemoverAsync(estoque);
            await _estoqueRepository.CommitAsync();
        }
    }
}