using MediatR;

namespace TestTask.Application.MediatR.Queries.GetPackages;

public class GetPackagesQuery : IRequest<PackageListViewModel>
{
    public string? Status { get; set; }
    public int? Id { get; set; }
    public int? RecipientId { get; set; }
}