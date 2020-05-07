using System.Collections.Generic;

namespace EstoqueProduto.Domain.Entities
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public ICollection<Produto> Produtos { get; set; }

        public Categoria() {}
        public Categoria(int id, string nome, string descricao) 
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
        }
    }
}