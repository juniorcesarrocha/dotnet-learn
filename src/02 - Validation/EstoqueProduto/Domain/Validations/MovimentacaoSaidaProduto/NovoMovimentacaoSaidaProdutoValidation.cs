namespace EstoqueProduto.Domain.Validations
{
    public class NovoMovimentacaoSaidaProdutoValidation : MovimentacaoSaidaProdutoValidation
    {
        public NovoMovimentacaoSaidaProdutoValidation()
        {
            ValidarProduto();
            ValidarQuantidade();
            ValidarDataSaida();
        }
    }
}