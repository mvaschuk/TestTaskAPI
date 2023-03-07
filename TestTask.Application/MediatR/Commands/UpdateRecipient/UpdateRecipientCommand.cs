using MediatR;

namespace TestTask.Application.MediatR.Commands.UpdateRecipient;

public class UpdateRecipientCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}