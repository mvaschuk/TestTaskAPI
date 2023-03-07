using MediatR;
using TestTask.Domain;

namespace TestTask.Application.MediatR.Commands.CreatePackage;

public class CreatePackageCommand : IRequest<int>
{
    public string PackageIdentifier { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int RecipientId { get; set; }
}