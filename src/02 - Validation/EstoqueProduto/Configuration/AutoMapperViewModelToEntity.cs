using AutoMapper;
using EstoqueProduto.Domain.Entities;
using EstoqueProduto.ViewModels;

namespace EstoqueProduto.Configuration
{
    public class AutoMapperViewModelToEntity : Profile
    {
        public AutoMapperViewModelToEntity()
        {
            CategoriaMap();
            ProdutoMap();
            EstoqueMap();
            MovimentacaoEntradaProduto();
            MovimentacaoSaidaProduto();
        }

        private void CategoriaMap()
        {
            CreateMap<CategoriaViewModel, Categoria>();
        }

        private void ProdutoMap()
        {
            CreateMap<ProdutoViewModel, Produto>();
        }

        private void EstoqueMap() 
        {
            CreateMap<EstoqueViewModel, Estoque>();
        }

        private void MovimentacaoEntradaProduto() 
        {
            CreateMap<MovimentacaoEntradaProdutoViewModel, MovimentacaoEntradaProduto>();
        }

        private void MovimentacaoSaidaProduto() 
        {
            CreateMap<MovimentacaoSaidaProdutoViewModel, MovimentacaoSaidaProduto>();
        }
    }
}