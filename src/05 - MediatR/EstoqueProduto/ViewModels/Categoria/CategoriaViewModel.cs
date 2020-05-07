using System.ComponentModel.DataAnnotations;

namespace EstoqueProduto.ViewModels
{
    public class CategoriaViewModel
    {
        public int Id { set; get; }                
        public string Nome { set; get; }                
        public string Descricao { set; get; }
    }
}