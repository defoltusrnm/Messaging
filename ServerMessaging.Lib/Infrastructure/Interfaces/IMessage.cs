namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public interface IMessage<TData>
{
    TData Message { get; }

    IMessage<string> AsString();

    IMessage<IEnumerable<byte>> AsBytes();

    IMessage<TOutput> AsType<TOutput>();
}
