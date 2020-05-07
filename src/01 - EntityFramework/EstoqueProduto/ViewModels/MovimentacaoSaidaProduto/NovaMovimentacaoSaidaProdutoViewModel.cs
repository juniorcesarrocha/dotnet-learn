using System;
using System.ComponentModel.DataAnnotations;

namespace EstoqueProduto.ViewModels
{
    public class NovaMovimentacaoSaidaProdutoViewModel
    {        
        public DateTime DataSaida { get; set; }             
        public int QuantidadeSaida { get; set; }
        public int ProdutoId { get; set; }
    }
}