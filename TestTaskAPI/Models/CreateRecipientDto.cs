using AutoMapper;
using TestTask.Application.Common.Mappings;
using TestTask.Application.MediatR.Commands.CreateRecipient;

namespace TestTaskAPI.Models;

public class CreateRecipientDto : IMapWith<CreateRecipientCommand>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateRecipientDto, CreateRecipientCommand>()
            .ForMember(i => i.Name, j => j.MapFrom(k => k.Name))
            .ForMember(i => i.Address, j => j.MapFrom(k => k.Address));
    }
}