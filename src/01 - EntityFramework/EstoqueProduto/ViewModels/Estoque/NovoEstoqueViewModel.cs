using System.ComponentModel.DataAnnotations;

namespace EstoqueProduto.ViewModels
{
    public class NovoEstoqueViewModel
    {                
        public int ProdutoId { get; set; }
        public string Localizacao { get;  set; }                
        public int QuantidadeMinima { get; set; }
        public int? QuantidadeMaxima { get; set; }
    }
}