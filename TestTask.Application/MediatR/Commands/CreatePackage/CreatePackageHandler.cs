using MediatR;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Interfaces;
using TestTask.Domain;

namespace TestTask.Application.MediatR.Commands.CreatePackage;

public class CreatePackageHandler : IRequestHandler<CreatePackageCommand, int>
{
    private readonly ITestTaskDbContext _dbContext;

    public CreatePackageHandler(ITestTaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
    {

        var recipient = await _dbContext.Recipients.FirstOrDefaultAsync(i => i.Id == request.RecipientId, cancellationToken);

        if (recipient == null)
        {
            throw new Exception($"Entity Recipient with Id:{request.RecipientId} not found");
        }

        var package = new Package
        {
            PackageIdentifier = request.PackageIdentifier,
            Name = request.Name,
            Description = request.Description,
            Status = "RECEIVED",
            Recipient = recipient,
            LastUpdated = DateTime.Now
        };

        await _dbContext.Packages.AddAsync(package, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return package.Id;
    }
}