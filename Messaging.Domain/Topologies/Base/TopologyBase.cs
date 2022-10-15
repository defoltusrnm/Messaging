using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Messaging.Domain.Topologies.Base;

public abstract class TopologyBase<TTopology> : IDictionary<string, Type>
{
    private readonly IDictionary<string, Type> _topologies;

    public TopologyBase()
    {
        _topologies = new Dictionary<string, Type>();
    }

    public virtual void Add(string key, Type value)
    {
        if (!value.IsAssignableTo(typeof(TTopology))) 
        {
            throw new ArgumentException("Incorrect type");
        }

        _topologies.Add(key, value);
    }

    public virtual void Add(KeyValuePair<string, Type> item)
    {
        if (item.Value.IsAssignableTo(typeof(TTopology)))
        {
            throw new ArgumentException("Incorrect type");
        }

        _topologies.Add(item);
    }

    #region Interface impl
    public Type this[string key] { get => _topologies[key]; set => _topologies[key] = value; }
    public ICollection<string> Keys => _topologies.Keys;
    public ICollection<Type> Values => _topologies.Values;
    public int Count => _topologies.Count;
    public bool IsReadOnly => _topologies.IsReadOnly;
    public void Clear() => _topologies.Clear();
    public bool Contains(KeyValuePair<string, Type> item) => _topologies.Contains(item);
    public bool ContainsKey(string key) => _topologies.ContainsKey(key);
    public void CopyTo(KeyValuePair<string, Type>[] array, int arrayIndex) => _topologies.CopyTo(array, arrayIndex);
    public IEnumerator<KeyValuePair<string, Type>> GetEnumerator() => _topologies.GetEnumerator();
    public bool Remove(string key) => _topologies.Remove(key);
    public bool Remove(KeyValuePair<string, Type> item) => _topologies.Remove(item);
    public bool TryGetValue(string key, [MaybeNullWhen(false)] out Type value) => _topologies.TryGetValue(key, out value);
    IEnumerator IEnumerable.GetEnumerator() => _topologies.GetEnumerator();
    #endregion Interface impl
}
