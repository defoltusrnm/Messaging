namespace Messaging.Domain.Messages.Interfaces;

public interface IMessageFactory
{
    IMessage Create(string content);
}