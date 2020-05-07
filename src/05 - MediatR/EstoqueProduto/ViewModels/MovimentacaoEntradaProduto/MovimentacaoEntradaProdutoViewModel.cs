using System;
using System.ComponentModel.DataAnnotations;

namespace EstoqueProduto.ViewModels
{
    public class MovimentacaoEntradaProdutoViewModel
    {        
        public int Id { set; get; }
        public DateTime DataEntrada { get; set; }                        
        public int QuantidadeEntrada { get; set; }                
        public int ProdutoId { get; set; }
    }
}