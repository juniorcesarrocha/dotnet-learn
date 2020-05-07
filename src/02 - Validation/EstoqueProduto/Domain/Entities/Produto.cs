using System;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueProduto.Domain.Entities
{
    public class Produto : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string UnidadeConsumo { get; private set; }
        public decimal ValorUnitario { get; private set; }        
        public string CodigoBarra { get; private set; }
        public DateTime? DataVencimento { get; private set; }
        public bool Ativo { get; private set; }
        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }
        public Estoque Estoque { get; private set; }
        public IReadOnlyCollection<MovimentacaoEntradaProduto> MovimentacaoEntradaProdutos => _listaMovimentacaoEntrada;
        public IReadOnlyCollection<MovimentacaoSaidaProduto> MovimentacaoSaidaProdutos => _listaMovimentacaoSaida;        
        private readonly List<MovimentacaoEntradaProduto> _listaMovimentacaoEntrada;
        private readonly List<MovimentacaoSaidaProduto> _listaMovimentacaoSaida;
        public Produto() 
        {
            this._listaMovimentacaoEntrada = new List<MovimentacaoEntradaProduto>();
            this._listaMovimentacaoSaida = new List<MovimentacaoSaidaProduto>();
        }
        public Produto(int id, string nome, decimal valorUnitario, int quantidade, int categoriaId) 
        {
            this.Id = id;
            this.Nome = nome;
            this.ValorUnitario = valorUnitario;
            this.CategoriaId = categoriaId;
            this.Ativo = true;
            this._listaMovimentacaoEntrada = new List<MovimentacaoEntradaProduto>();
            this._listaMovimentacaoSaida = new List<MovimentacaoSaidaProduto>();
        }
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
        public int BuscarQuantidadeAtual() 
        {
            var quantidadeEntrada = SomarQuantidadesMovimentacaoEntrada();
            var quantidadeSaida = SomarQuantidadesMovimentacaoSaida();
            return (quantidadeEntrada - quantidadeSaida);
        }
                
        public MovimentacaoEntradaProduto BuscarUltimaMovimentacaoEntradaRealizada() => this._listaMovimentacaoEntrada.OrderByDescending(x => x.Id).FirstOrDefault();
        public MovimentacaoSaidaProduto BuscarUltimaMovimentacaoSaidaRealizada() => this._listaMovimentacaoSaida.OrderByDescending(x => x.Id).FirstOrDefault();
        private int SomarQuantidadesMovimentacaoEntrada() => this._listaMovimentacaoEntrada.Sum(x => x.QuantidadeEntrada);        
        private int SomarQuantidadesMovimentacaoSaida() => this._listaMovimentacaoSaida.Sum(x => x.QuantidadeSaida);        
    }
}