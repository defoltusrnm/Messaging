using Messaging.Domain.Messages.Base;

namespace Messaging.Domain.Messages.Primitives;

public class Message<TContent> : MessageBase<TContent>
{
    public Message(TContent content) 
        : base(content)
    { }

    public override string AsString() => $"{Content}";
}
