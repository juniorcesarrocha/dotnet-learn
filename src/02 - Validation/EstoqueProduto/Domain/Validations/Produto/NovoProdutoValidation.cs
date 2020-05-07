namespace EstoqueProduto.Domain.Validations
{
    public class NovoProdutoValidation : ProdutoValidation
    {
        public NovoProdutoValidation() 
        {
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