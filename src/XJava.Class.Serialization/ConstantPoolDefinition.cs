using XJava.Class.Serialization.ConstantPoolItems;

namespace XJava.Class.Serialization;

internal class ConstantPoolDefinition
{
    #region Construction

    public ConstantPoolDefinition()
    {
        _items.Add(ItemNone.Instance);
    }

    #endregion

    #region Fields

    private static readonly IConstantPoolDefinitionSerializer _serializer = new ConstantPoolDefinitionSerializer();

    private readonly List<IItem> _items = new List<IItem>();

    #endregion

    #region Properties

    internal IReadOnlyList<IItem> Items => _items;

    #endregion

    #region Methods

    internal T GetItem<T>(int index)
        where T : IItem
    {
        Tag tag = TagUtils.GetTagForType<T>();

        IItem item = _items[index];
        if (item.Tag != tag)
            throw new Exception($"Item at index {index} is not {tag} (its a {item.Tag})");

        return (T)item;
    }

    internal int AddItem<T>(T item)
        where T : IItem
    {
        int index = _items.Count;

        _items.Add(item);
        if (item.Tag == Tag.Long || item.Tag == Tag.Double)
            _items.Add(ItemNone.Instance);

        return index;
    }

    public string GetClassName(int index)
    {
        ItemClass item = GetItem<ItemClass>(index);
        return GetItem<ItemUtf8>(item.NameIndex).Value;
    }

    public string GetUtf8(int index)
    {
        ItemUtf8 item = GetItem<ItemUtf8>(index);
        return item.Value;
    }

    public void Serialize(Stream stream) =>
        _serializer.Serialize(stream, _items);

    public static ConstantPoolDefinition Deserialize(Stream stream)
    {
        ConstantPoolDefinition def = new ConstantPoolDefinition();
        def._items.AddRange(_serializer.Deserialize(stream));

        return def;
    }

    #endregion
}
