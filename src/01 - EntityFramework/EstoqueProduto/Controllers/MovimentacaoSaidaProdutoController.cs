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
    [Route("api/saida-produtos")]
    public class MovimentacaoSaidaProdutoController : ControllerBase
    {
        private readonly IMovimentacaoSaidaProdutoService _movimentacaoSaidaProdutoService;
        private readonly IMapper _mapper;
        public MovimentacaoSaidaProdutoController(IMovimentacaoSaidaProdutoService movimentacaoSaidaProdutoService, 
                                IMapper mapper)
        {
            _movimentacaoSaidaProdutoService = movimentacaoSaidaProdutoService;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task Inserir(NovaMovimentacaoSaidaProdutoViewModel movimentacaoSaidaProdutoViewModel)
        {
            var movimentacaoSaidaProduto = _mapper.Map<MovimentacaoSaidaProduto>(movimentacaoSaidaProdutoViewModel);
            await _movimentacaoSaidaProdutoService.InserirAsync(movimentacaoSaidaProduto);
        }
        [HttpPut]
        public async Task Atualizar(MovimentacaoSaidaProdutoViewModel movimentacaoSaidaProdutoViewModel)
        {
            var movimentacaoSaidaProduto = _mapper.Map<MovimentacaoSaidaProduto>(movimentacaoSaidaProdutoViewModel);
            await _movimentacaoSaidaProdutoService.AtualizarAsync(movimentacaoSaidaProduto);
        }        
    }
}
