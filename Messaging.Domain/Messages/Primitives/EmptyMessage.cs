namespace Messaging.Domain.Messages.Primitives;

public class EmptyMessage : StringMessage
{
    public EmptyMessage() 
        : base("")
    { }
}
