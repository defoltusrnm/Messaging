using ServerMessaging.Lib.Infrastructure.Interfaces;
using System.Text;

namespace ServerMessaging.Lib.Infrastructure.Primirives;

public class StringMessage : IMessage<string>
{    
    public string Data { get; init; } = string.Empty;

    public Encoding Encoding { get; init; } = Encoding.Default;

    public IMessage<IEnumerable<byte>> AsBytes() => new ByteMessage()
    {
        Data = Encoding.GetBytes(Data)
    };

    public IMessage<string> AsString() => this;

    public IMessage<TOutput> AsType<TOutput>(Func<string, TOutput>? converter = null) where TOutput : class
    {
        if (converter == null)
        {
            throw new InvalidOperationException("Use converter with strings");
        }

        return new Message<TOutput>
        {
            Data = converter(Data)
        };
    }
}
