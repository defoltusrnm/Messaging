using Messaging.Domain.Commands.Interfaces;

namespace Messaging.Domain.Commands.Primitives;

public class EmptyCommand : ICommand
{
    public string Path => string.Empty;
}
