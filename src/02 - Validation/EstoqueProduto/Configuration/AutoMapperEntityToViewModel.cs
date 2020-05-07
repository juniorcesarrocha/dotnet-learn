using AutoMapper;
using EstoqueProduto.Domain.Entities;
using EstoqueProduto.ViewModels;

namespace EstoqueProduto.Configuration
{
    public class AutoMapperEntityToViewModel : Profile
    {
        public AutoMapperEntityToViewModel()
        {
            CategoriaMap();
            ProdutoMap();
            EstoqueMap();
            MovimentacaoEntradaProduto();
            MovimentacaoSaidaProduto();
        }

        private void CategoriaMap()
        {
            CreateMap<Categoria, CategoriaViewModel>();
        }

        private void ProdutoMap()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ForPath(dest => dest.QuantidadeAtual, opt => opt.MapFrom(src => src.BuscarQuantidadeAtual()))
                .ForPath(dest => dest.UltimaMovimentacaoEntradaProdutos, opt => opt.MapFrom(src => src.BuscarUltimaMovimentacaoEntradaRealizada()))
                .ForPath(dest => dest.UltimaMovimentacaoSaidaProdutos, opt => opt.MapFrom(src => src.BuscarUltimaMovimentacaoSaidaRealizada()));
        }

        private void EstoqueMap() 
        {
            CreateMap<Estoque, EstoqueViewModel>();
        }

        private void MovimentacaoEntradaProduto() 
        {
            CreateMap<MovimentacaoEntradaProduto, MovimentacaoEntradaProdutoViewModel>();
        }

        private void MovimentacaoSaidaProduto() 
        {
            CreateMap<MovimentacaoSaidaProduto, MovimentacaoSaidaProdutoViewModel>();
        }
    }
}