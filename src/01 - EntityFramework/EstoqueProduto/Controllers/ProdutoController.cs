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
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        public ProdutoController(IProdutoService produtoService, 
                                IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> Get()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoService.ListarTodosAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<ProdutoViewModel> Get(int id)
        {                        
            return _mapper.Map<ProdutoViewModel>(await _produtoService.BuscarPorIdAsync(id));
        }
        [HttpPost]
        public async Task Inserir(NovoProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _produtoService.InserirAsync(produto);
        }
        [HttpPut]
        public async Task Atualizar(AtualizaProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _produtoService.AtualizarAsync(produto);
        }
        [HttpDelete("{id:int}")]
        public async Task Remover(int id)
        {            
            await _produtoService.RemoverAsync(id);
        }
    }
}
