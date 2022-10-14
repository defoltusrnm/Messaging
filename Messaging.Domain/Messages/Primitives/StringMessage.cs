using Messaging.Domain.Messages.Base;

namespace Messaging.Domain.Messages.Primitives;

public class StringMessage : MessageBase<string>
{
    public StringMessage(string content) 
        : base(content)
    { }

    public override string AsString() => Content;
}
