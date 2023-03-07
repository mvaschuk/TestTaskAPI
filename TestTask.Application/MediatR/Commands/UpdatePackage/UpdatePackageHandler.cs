using MediatR;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Interfaces;

namespace TestTask.Application.MediatR.Commands.UpdatePackage;

public class UpdatePackageHandler : IRequestHandler<UpdatePackageCommand>
{
    private readonly ITestTaskDbContext _dbContext;

    public UpdatePackageHandler(ITestTaskDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
    }
    public async Task<Unit> Handle(UpdatePackageCommand request, CancellationToken cancellationToken)
    {
        var package = await _dbContext.Packages.Include(i => i.Recipient).FirstOrDefaultAsync(j => j.Id == request.Id, cancellationToken);
        if (package == null)
        {
            throw new Exception($"Entity Package with Id:{request.Id} not found");
        }

        package.Name = request.Name;
        package.PackageIdentifier = request.PackageIdentifier;
        package.Description = request.Description;
        package.Status = request.Status;

        if (package.Recipient.Id != request.RecipientId)
        {
            var recipient = await _dbContext.Recipients.FirstOrDefaultAsync(i => i.Id == request.RecipientId, cancellationToken);
            if (recipient == null)
            {
                throw new Exception($"Entity Recipient with Id:{request.Id} not found");
            }
            package.Recipient = recipient;
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}