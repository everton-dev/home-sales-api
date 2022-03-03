using Domain.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : CustomController
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator) =>
            _mediator = mediator;

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(BrandCreateCommand request)
        {
            var result = await _mediator.Send(request, CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new BrandGetAllCommand(), CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _mediator.Send(new BrandGetByIdCommand(id), CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(BrandUpdateCommand request)
        {
            var result = await _mediator.Send(request, CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }
    }
}