using Messaging.Domain.Messages.Base;
using System.Text;

namespace Messaging.Domain.Messages.Primitives;

public class BytesMessage : MessageBase<IEnumerable<byte>>
{
    private readonly Encoding _encoding;

    public BytesMessage(IEnumerable<byte> content, Encoding encoding)
        : base(content)
    {
        _encoding = encoding;
    }

    public override string AsString() => _encoding.GetString(Content.ToArray());
}
