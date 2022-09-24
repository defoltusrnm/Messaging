using ServerMessaging.Lib.Infrastructure.Interfaces;
using System.Text;

#nullable disable

namespace ServerMessaging.Lib.Infrastructure.Primirives;

public class Message<TData> : IMessage<TData>
    where TData : class
{
    public TData Data { get; init; }

    public Encoding Encoding { get; init; } = Encoding.Default;

    public IMessage<IEnumerable<byte>> AsBytes()
    {
        StringMessage message = new() 
        {
            Data = Data.ToString(),
            Encoding = Encoding,
        };

        return message.AsBytes();
    }

    public IMessage<string> AsString() => new StringMessage
    {
        Data = Data.ToString(),
        Encoding = Encoding,
    };

    public IMessage<TOutput> AsType<TOutput>(Func<TData, TOutput> converter = null) where TOutput : class
    {
        if (converter == null)
        {
            return new Message<TOutput>
            {
                Data = Data as TOutput
            };
        }

        return new Message<TOutput>
        {
            Data = converter(Data)
        };
    }
}
