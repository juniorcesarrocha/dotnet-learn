using System.Collections.Generic;
using System.Linq;

namespace EstoqueProduto.Domain.Entities
{
    public class Estoque : Entity
    {
        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public string Localizacao { get; private set; }
        public int QuantidadeMinima { get; private set; }
        public int? QuantidadeMaxima { get; private set; }

        public Estoque() {}
        public Estoque(int id, string localizacao, int quantidadeMinima, int produtoId) 
        {
            this.Id = id;
            this.Localizacao = localizacao;
            this.QuantidadeMinima = quantidadeMinima;            
            this.ProdutoId = produtoId;
        }                
        public void AdicionarQuantidadeMaxima(int quantidadeMaxima) => this.QuantidadeMaxima = quantidadeMaxima;
    }
}