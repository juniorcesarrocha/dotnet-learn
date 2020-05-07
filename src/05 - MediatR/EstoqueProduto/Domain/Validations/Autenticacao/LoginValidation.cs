namespace EstoqueProduto.Domain.Validations
{
    public class LoginValidation : AutenticacaoValidation
    {
        public LoginValidation() 
        {
            ValidarEmail();
        }
    }
}