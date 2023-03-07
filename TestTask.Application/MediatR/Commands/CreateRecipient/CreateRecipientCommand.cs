using MediatR;

namespace TestTask.Application.MediatR.Commands.CreateRecipient;

public class CreateRecipientCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Address { get; set; }
}