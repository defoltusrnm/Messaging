using System.Text;

namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public interface IMessage<TData>
    where TData : class
{
    TData Data { get; init; }

    Encoding Encoding { get; init; }

    IMessage<string> AsString();

    IMessage<IEnumerable<byte>> AsBytes();

    IMessage<TOutput> AsType<TOutput>(Func<TData, TOutput>? converter = null)
        where TOutput : class;
}
