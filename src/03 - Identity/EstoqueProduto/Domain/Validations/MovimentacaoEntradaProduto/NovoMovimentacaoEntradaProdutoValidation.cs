namespace EstoqueProduto.Domain.Validations
{
    public class NovoMovimentacaoEntradaProdutoValidation : MovimentacaoEntradaProdutoValidation
    {
        public NovoMovimentacaoEntradaProdutoValidation()
        {
            ValidarProduto();
            ValidarQuantidade();
            ValidarDataEntrada();
        }
    }
}