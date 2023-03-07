using MediatR;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Interfaces;
using TestTask.Application.MediatR.Commands.UpdateRecipient;

namespace TestTask.Application.MediatR.Commands.UpdatePachage;

public class UpdateRecipientHandler : IRequestHandler<UpdateRecipientCommand>
{
    private readonly ITestTaskDbContext _dbContext;

    public UpdateRecipientHandler(ITestTaskDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
    }
    public async Task<Unit> Handle(UpdateRecipientCommand request, CancellationToken cancellationToken)
    {
        var recipient = await _dbContext.Recipients.FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);
        if (recipient == null)
        {
            throw new Exception($"Entity Recipient with Id:{request.Id} not found");
        }

        recipient.Name = request.Name;
        recipient.Address = request.Address;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}