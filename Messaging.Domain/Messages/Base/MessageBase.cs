using Messaging.Domain.Messages.Interfaces;

namespace Messaging.Domain.Messages.Base;

public abstract class MessageBase<TContent> : IMessage<TContent>
{
    public MessageBase(TContent content)
    {
        Content = content;
    }

    public virtual TContent Content { get; }

    public abstract string AsString();

    object? IMessage.GetContent() => Content;
}
