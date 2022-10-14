using Messaging.Domain.Commands.Interfaces;
using Messaging.Domain.Messages.Interfaces;
using Messaging.Domain.Packages.Primitives;

namespace Messaging.Domain.Packages.Interface;

public interface IPackage
{
    private readonly static EmptyPackage _empty = new();
    public static IPackage Empty => _empty;

    ICommand Command { get; }
    IMessage Message { get; }
}
