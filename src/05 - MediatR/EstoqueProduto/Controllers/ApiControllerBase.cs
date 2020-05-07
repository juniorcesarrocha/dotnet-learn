using System.Linq;
using EstoqueProduto.Infra.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EstoqueProduto.Controllers
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {        
        private readonly IRequestNotificator _notifications;
        protected ApiControllerBase(IRequestNotificator notifications)
        {            
            _notifications = notifications;
        }

        protected ActionResult Result(object result = null)
        {
            if (_notifications.HasNotification())
            {
                return ResponseError(result);
            }

            return ResponseSuccess(result);
        }        

        private ActionResult ResponseSuccess(object result = null)
        {            
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        private ActionResult ResponseError(object result = null)
        {            
            return BadRequest(new
            {
                success = false,
                errors = _notifications.Get().Select(n => n.Menssage)
            });
        }
    }
}