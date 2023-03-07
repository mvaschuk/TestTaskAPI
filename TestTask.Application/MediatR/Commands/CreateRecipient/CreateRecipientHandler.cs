using MediatR;
using TestTask.Application.Interfaces;
using TestTask.Domain;

namespace TestTask.Application.MediatR.Commands.CreateRecipient;

public class CreatePackageHandler : IRequestHandler<CreateRecipientCommand, int>
{
    private readonly ITestTaskDbContext _dbContext;

    public CreatePackageHandler(ITestTaskDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
    }
    public async Task<int> Handle(CreateRecipientCommand request, CancellationToken cancellationToken)
    {
        var recipient = new Recipient
        {
            Name = request.Name,
            Address = request.Address
        };

        await _dbContext.Recipients.AddAsync(recipient, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return recipient.Id;
    }
}