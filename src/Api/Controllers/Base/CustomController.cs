using Domain.Commands.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CustomController : Controller
    {
        [NonAction]
        protected async Task<IActionResult> ValidationHandlerAsync(DefaultResponse result)
        {
            if (result.Success)
                return await Task.Run(() => Ok(result));

            foreach (var erro in result.Erros)
                ModelState.AddModelError("", erro);

            return await Task.Run(() => BadRequest(result));
        }
    }
}