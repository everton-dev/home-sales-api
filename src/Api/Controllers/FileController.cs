using Domain.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : CustomController
    {
        private readonly IMediator _mediator;

        public FileController(IMediator mediator) =>
            _mediator = mediator;

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(FileUploadCommand request)
        {
            var result = await _mediator.Send(request, CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }

        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> Get(FileGetCommand request)
        {
            var result = await _mediator.Send(request, CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll(string folder)
        {
            var result = await _mediator.Send(new FileGetAllCommand(folder), CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }
    }
}