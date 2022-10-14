using Messaging.Domain.Messages.Primitives;

namespace Messaging.Domain.Messages.Interfaces;

public interface IMessage
{
    private readonly static EmptyMessage _empty = new();
    public static IMessage Empty => _empty;

    object? GetContent();
    string AsString();
}

public interface IMessage<out TContent> : IMessage
{
    TContent Content { get; }
}
