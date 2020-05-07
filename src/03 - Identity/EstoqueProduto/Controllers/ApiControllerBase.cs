using System.Linq;
using EstoqueProduto.Infra.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EstoqueProduto.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        protected readonly IRequestNotificator _notificator;

        protected ApiControllerBase(IRequestNotificator notificator)
        {
            _notificator = notificator;
        }

        protected ActionResult Result(object result = null)
        {
            if (_notificator.HasNotification())
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
                errors = _notificator.Get().Select(n => n.Mensage)
            });
        }
    }
}