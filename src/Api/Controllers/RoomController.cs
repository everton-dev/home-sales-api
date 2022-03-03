using Domain.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : CustomController
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator) =>
            _mediator = mediator;

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(RoomCreateCommand request)
        {
            var result = await _mediator.Send(request, CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new RoomGetAllCommand(), CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _mediator.Send(new RoomGetByIdCommand(id), CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(RoomUpdateCommand request)
        {
            var result = await _mediator.Send(request, CancellationToken.None);
            return await base.ValidationHandlerAsync(result);
        }
    }
}