namespace EstoqueProduto.Domain.Validations
{
    public class AtualizacaoProdutoValidation : ProdutoValidation
    {
        public AtualizacaoProdutoValidation() 
        {
            ValidarId();
            ValidarNome();
            ValidarDescricao();
            ValidarUnidadeConsumo();
            ValidarValorUnitario();
            ValidarCodigoBarra();
            ValidarDataVencimento();
            ValidarAtivo();
            ValidarCategoria();
        }
    }
}