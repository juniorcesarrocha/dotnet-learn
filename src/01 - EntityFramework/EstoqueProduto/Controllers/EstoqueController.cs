using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;
using EstoqueProduto.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EstoqueProduto.Controllers
{
    [ApiController]
    [Route("api/estoques")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;
        private readonly IMapper _mapper;
        public EstoqueController(IEstoqueService estoqueService, 
                                IMapper mapper)
        {
            _estoqueService = estoqueService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<EstoqueViewModel>> Get()
        {
            return _mapper.Map<IEnumerable<EstoqueViewModel>>(await _estoqueService.ListarTodosAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<EstoqueViewModel> Get(int id)
        {
            return _mapper.Map<EstoqueViewModel>(await _estoqueService.BuscarPorIdAsync(id));
        }
        [HttpGet("produto/{id:int}")]
        public async Task<EstoqueViewModel> BuscarPorIdProduto(int id)
        {
            return _mapper.Map<EstoqueViewModel>(await _estoqueService.BuscarPorIdProdutoAsync(id));
        }
        [HttpPost]
        public async Task Inserir(NovoEstoqueViewModel estoqueViewModel)
        {
            var estoque = _mapper.Map<Estoque>(estoqueViewModel);
            await _estoqueService.InserirAsync(estoque);
        }
        [HttpPut]
        public async Task Atualizar(EstoqueViewModel estoqueViewModel)
        {
            var estoque = _mapper.Map<Estoque>(estoqueViewModel);
            await _estoqueService.AtualizarAsync(estoque);
        }
        [HttpDelete("{id:int}")]
        public async Task Remover(int id)
        {            
            await _estoqueService.RemoverAsync(id);
        }
    }
}
