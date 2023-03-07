using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Application.MediatR.Commands.CreateRecipient;
using TestTask.Application.MediatR.Commands.UpdateRecipient;
using TestTaskAPI.Models;

namespace TestTaskAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecipientController : ControllerBase
    {
        private IMediator _mediator => HttpContext.RequestServices.GetService<IMediator>() ?? throw new ArgumentException(nameof(IMediator));
        private readonly IMapper _mapper;

        public RecipientController(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CreateRecipientDto createRecipientDto)
        {
            var command = _mapper.Map<CreateRecipientCommand>(createRecipientDto);
            var id = await _mediator.Send(command);
            Response.StatusCode = 200;
            return id;
        }
        [HttpPost]
        public async Task Update([FromBody] UpdateRecipientDto createRecipientDto)
        {
            var command = _mapper.Map<UpdateRecipientCommand>(createRecipientDto);
            await _mediator.Send(command);
            Response.StatusCode = 200;
        }
    }
}
