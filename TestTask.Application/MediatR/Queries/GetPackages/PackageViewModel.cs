using AutoMapper;
using TestTask.Application.Common.Mappings;
using TestTask.Domain;

namespace TestTask.Application.MediatR.Queries.GetPackages;

public class PackageViewModel : IMapWith<Package>
{
    public int Id { get; set; }
    public string PackageIdentifier { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string Status { get; set; }
    public DateTime LastUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Package, PackageViewModel>()
            .ForMember(i => i.Id, j => j.MapFrom(k => k.Id))
            .ForMember(i => i.PackageIdentifier, j => j.MapFrom(k => k.PackageIdentifier))
            .ForMember(i => i.Name, j => j.MapFrom(k => k.Name))
            .ForMember(i => i.Description, j => j.MapFrom(k => k.Description))
            .ForMember(i => i.Status, j => j.MapFrom(k => k.Status))
            .ForMember(i => i.LastUpdated, j => j.MapFrom(k => k.LastUpdated));
    }
}