using System;
using System.Collections.Generic;

namespace EstoqueProduto.Domain.Entities
{
    public class MovimentacaoSaidaProduto : Entity
    {        
        public DateTime DataSaida { get; private set; }     
        public int QuantidadeSaida { get; private set; }
        public int ProdutoId { get; private set; }        
        public Produto Produto { get; private set; }

        public MovimentacaoSaidaProduto() {}
        public MovimentacaoSaidaProduto(int id, int quantidadeSaida, int produtoId) 
        {
            this.Id = id;
            this.DataSaida = DateTime.UtcNow;
            this.QuantidadeSaida = quantidadeSaida;            
            this.ProdutoId = produtoId;
        }
    }
}