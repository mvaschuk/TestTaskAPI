using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.Application.MediatR.Commands.CreatePackage;
using TestTask.Application.MediatR.Commands.UpdatePackage;
using TestTask.Application.MediatR.Queries.GetPackages;
using TestTaskAPI.Models;

namespace TestTaskAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private IMediator _mediator => HttpContext.RequestServices.GetService<IMediator>() ?? throw new ArgumentException(nameof(IMediator));
        private readonly IMapper _mapper;

        public PackageController(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public async Task<PackageListViewModel> GetAll()
        {
            return await _mediator.Send(new GetPackagesQuery());
        }
        [HttpGet]
        public async Task<PackageListViewModel> GetAllDelivered()
        {
            return await _mediator.Send(new GetPackagesQuery
            {
                Status = "DELIVERED"
            });
        }
        [HttpGet]
        public async Task<PackageViewModel> GetById(int id)
        {
            return _mediator.Send(new GetPackagesQuery
            {
                Id = id
            }).Result.Packages.FirstOrDefault(i => true);
        }
        [HttpGet]
        public async Task<PackageListViewModel> GetAllForRecipient(int recipientId)
        {
            return await _mediator.Send(new GetPackagesQuery
            {
                RecipientId = recipientId
            });
        }
        [HttpPost]
        public async Task<int> Create([FromBody] CreatePackageDto createRecipientDto)
        {
            var command = _mapper.Map<CreatePackageCommand>(createRecipientDto);
            var id = await _mediator.Send(command);
            Response.StatusCode = 200;
            return id;
        }
        [HttpPost]
        public async Task Update([FromBody] UpdatePackageDto createRecipientDto)
        {
            var command = _mapper.Map<UpdatePackageCommand>(createRecipientDto);
            await _mediator.Send(command);
        }
    }
}
