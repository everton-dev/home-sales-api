using Domain.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : CustomController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) =>
            _mediator = mediator;

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(ProductCreateCommand request)
        {
            var result = await _mediator.Send(request, CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new ProductGetAllCommand(), CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _mediator.Send(new ProductGetByIdCommand(id), CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }

        [HttpPost]
        [Route("sell")]
        public async Task<IActionResult> Update(ProductSellCommand request)
        {
            var result = await _mediator.Send(request, CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(ProductUpdateCommand request)
        {
            var result = await _mediator.Send(request, CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }
    }
}