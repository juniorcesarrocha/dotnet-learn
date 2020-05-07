using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;
using EstoqueProduto.Domain.Validations;
using EstoqueProduto.Infra.Notifications;

namespace EstoqueProduto.Domain.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;   
        private readonly IRequestNotificator _notifications;
        public CategoriaService(ICategoriaRepository categoriaRepository,
                                IRequestNotificator notifications)
        {
            _categoriaRepository = categoriaRepository;  
            _notifications = notifications;
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
            var validationResult = new NovaCategoriaValidation().Validate(categoria);

            if (!validationResult.IsValid)  
            {
                _notifications.Add(validationResult);                
                return;
            }

            await _categoriaRepository.InserirAsync(categoria);
            await _categoriaRepository.CommitAsync();                                    
        }        
        public async Task AtualizarAsync(Categoria categoria)
        {
            var validationResult = new AtualizacaoCategoriaValidation().Validate(categoria);

            if (!validationResult.IsValid)  
            {
                _notifications.Add(validationResult);                
                return;
            }

            _categoriaRepository.AtualizarAsync(categoria);
            await _categoriaRepository.CommitAsync();
        }                
        public async Task RemoverAsync(int id)
        {
            var categoria = await BuscarPorIdAsync(id) ?? new Categoria();
            var validationResult = new ExclusaoCategoriaValidation().Validate(categoria);

            if (!validationResult.IsValid)  
            {
                _notifications.Add(validationResult);                
                return;
            }
            
            _categoriaRepository.RemoverAsync(categoria);
            await _categoriaRepository.CommitAsync();
        }
    }
}