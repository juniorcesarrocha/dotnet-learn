using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstoqueProduto.ViewModels
{
    public class AtualizaProdutoViewModel
    {
        public int Id { set; get; }                
        public string Nome { get; set; }                
        public string Descricao { get; set; }                
        public string UnidadeConsumo { get; set; }        
        public decimal ValorUnitario { get; set; }                
        public int QuantidadeAtual { get; set; }                
        public string CodigoBarra { get; set; }                
        public DateTime? DataVencimento { get; set; }                
        public bool Ativo { get; set; }        
        public int CategoriaId { get; set; }
    }
}