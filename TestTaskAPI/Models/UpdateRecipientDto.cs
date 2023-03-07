using AutoMapper;
using TestTask.Application.Common.Mappings;
using TestTask.Application.MediatR.Commands.UpdatePackage;
using TestTask.Application.MediatR.Commands.UpdateRecipient;

namespace TestTaskAPI.Models;

public class UpdateRecipientDto : IMapWith<UpdateRecipientCommand>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateRecipientDto, UpdateRecipientCommand>()
            .ForMember(i => i.Id, j => j.MapFrom(k => k.Id))
            .ForMember(i => i.Name, j => j.MapFrom(k => k.Name))
            .ForMember(i => i.Address, j => j.MapFrom(k => k.Address));
    }
}