using AutoMapper;
using TestTask.Application.Common.Mappings;
using TestTask.Application.MediatR.Commands.CreatePackage;
using TestTask.Application.MediatR.Commands.CreateRecipient;

namespace TestTaskAPI.Models;

public class CreatePackageDto : IMapWith<CreatePackageCommand>
{
    public string PackageIdentifier { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int RecipientId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePackageDto, CreatePackageCommand>()
            .ForMember(i => i.Name, j => j.MapFrom(k => k.Name))
            .ForMember(i => i.RecipientId, j => j.MapFrom(k => k.RecipientId))
            .ForMember(i => i.Description, j => j.MapFrom(k => k.Description))
            .ForMember(i => i.PackageIdentifier, j => j.MapFrom(k => k.PackageIdentifier));
    }
}