using System;
using System.Collections.Generic;

namespace EstoqueProduto.Domain.Entities
{
    public class MovimentacaoEntradaProduto : Entity
    {
        public DateTime DataEntrada { get; private set; }        
        public int QuantidadeEntrada { get; private set; }        
        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }

        public MovimentacaoEntradaProduto() {}
        public MovimentacaoEntradaProduto(int id, int quantidadeEntrada, int produtoId) 
        {
            this.Id = id;
            this.DataEntrada = DateTime.UtcNow;
            this.QuantidadeEntrada = quantidadeEntrada;            
            this.ProdutoId = produtoId;
        }
    }
}