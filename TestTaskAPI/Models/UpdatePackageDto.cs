using AutoMapper;
using TestTask.Application.Common.Mappings;
using TestTask.Application.MediatR.Commands.CreateRecipient;
using TestTask.Application.MediatR.Commands.UpdatePackage;

namespace TestTaskAPI.Models;

public class UpdatePackageDto : IMapWith<UpdatePackageCommand>
{
    public int Id { get; set; }
    public string PackageIdentifier { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string Status { get; set; }
    public int RecipientId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdatePackageDto, UpdatePackageCommand>()
            .ForMember(i => i.Id, j => j.MapFrom(k => k.Id))
            .ForMember(i => i.PackageIdentifier, j => j.MapFrom(k => k.PackageIdentifier))
            .ForMember(i => i.Name, j => j.MapFrom(k => k.Name))
            .ForMember(i => i.Description, j => j.MapFrom(k => k.Description))
            .ForMember(i => i.Status, j => j.MapFrom(k => k.Status))
            .ForMember(i => i.RecipientId, j => j.MapFrom(k => k.RecipientId));
    }
}