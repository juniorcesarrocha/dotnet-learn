using System.Threading.Tasks;

namespace EstoqueProduto.Infra.Http
{
    public interface IEmail
    {
         Task SendEmailAsync(string email, string subject, string message);
    }
}