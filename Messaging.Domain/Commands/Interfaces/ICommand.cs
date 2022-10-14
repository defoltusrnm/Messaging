using Messaging.Domain.Commands.Primitives;

namespace Messaging.Domain.Commands.Interfaces;

public interface ICommand
{
    private readonly static EmptyCommand _empty = new ();
    public static ICommand Empty => _empty;

    string Path { get; }
}
