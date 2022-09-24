using ServerMessaging.Lib.Infrastructure.Interfaces;
using System.Text;

#nullable disable

namespace ServerMessaging.Lib.Infrastructure.Primirives;

public class ByteMessage : IMessage<IEnumerable<byte>>
{
    public IEnumerable<byte> Data { get; init; }

    public Encoding Encoding { get; init; } = Encoding.Default;

    public IMessage<IEnumerable<byte>> AsBytes() => this;

    public IMessage<string> AsString() => new StringMessage
    {
        Data = Encoding.GetString(Data.ToArray()),
        Encoding = Encoding
    };

    public IMessage<TOutput> AsType<TOutput>(Func<IEnumerable<byte>, TOutput> converter = null) where TOutput : class
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
