using XJava.Class.Serialization.ConstantPoolItems;

namespace XJava.Class.Serialization;

internal class ConstantPoolDefinitionSerializer : IConstantPoolDefinitionSerializer
{
    private static readonly IItemSerializer _utf8Serializer = new ItemUtf8Serializer();
    private static readonly IItemSerializer _integerSerializer = new ItemIntegerSerializer();
    private static readonly IItemSerializer _floatSerializer = new ItemFloatSerializer();
    private static readonly IItemSerializer _longSerializer = new ItemLongSerializer();
    private static readonly IItemSerializer _doubleSerializer = new ItemDoubleSerializer();
    private static readonly IItemSerializer _classSerializer = new ItemClassSerializer();
    private static readonly IItemSerializer _stringSeralizer = new ItemStringSerializer();
    private static readonly IItemSerializer _fieldRefSerializer = new ItemFieldRefSerializer();
    private static readonly IItemSerializer _methodRefSerializer = new ItemMethodRefSerializer();
    private static readonly IItemSerializer _ifaceMethodRefSerializer = new ItemInterfaceMethodRefSerializer();
    private static readonly IItemSerializer _nameAndTypeSerializer = new ItemNameAndTypeSerializer();
    private static readonly IItemSerializer _methodHandleSerializer = new ItemMethodHandleSerializer();
    private static readonly IItemSerializer _methodTypeSerializer = new ItemMethodTypeSerializer();
    private static readonly IItemSerializer _invokeDynamicSerializer = new ItemInvokeDynamicSerializer();

    public IEnumerable<IItem> Deserialize(Stream stream)
    {
        List<IItem> items = new List<IItem>();

        using (BigEndianBinaryReader reader = new BigEndianBinaryReader(stream, leaveOpen: true))
        {
            ushort count = reader.ReadUInt16();

            for (int i = 1; i < count; i++)
            {
                Tag tag = (Tag)reader.ReadByte();

                IItemSerializer serializer = GetItemSerializer(tag);

                IItem item = serializer.Deserialize(reader);
                items.Add(item);

                if (tag == Tag.Long || tag == Tag.Double)
                {
                    i++;
                    items.Add(ItemNone.Instance);
                }
            }
        }

        return items;
    }

    public void Serialize(Stream stream, IEnumerable<IItem> items)
    {
        using (BigEndianBinaryWriter writer = new BigEndianBinaryWriter(stream, leaveOpen: true))
        {
            ushort count = (ushort)items.Count();

            writer.WriteUInt16(count);

            for (int index = 1; index < count; index++)
            {
                IItem item = items.ElementAt(index);

                writer.WriteByte((byte)item.Tag);
                if (item.Tag == Tag.None)
                    continue;

                IItemSerializer serializer = GetItemSerializer(item.Tag);
                serializer.Serialize(writer, item);

                if (item.Tag == Tag.Long || item.Tag == Tag.Double)
                    index++;
            }
        }
    }

    private static IItemSerializer GetItemSerializer(Tag tag)
    {
        switch (tag)
        {
            case Tag.Utf8:
                return _utf8Serializer;
            case Tag.Integer:
                return _integerSerializer;
            case Tag.Float:
                return _floatSerializer;
            case Tag.Long:
                return _longSerializer;
            case Tag.Double:
                return _doubleSerializer;
            case Tag.Class:
                return _classSerializer;
            case Tag.String:
                return _stringSeralizer;
            case Tag.FieldRef:
                return _fieldRefSerializer;
            case Tag.MethodRef:
                return _methodRefSerializer;
            case Tag.InterfaceMethodRef:
                return _ifaceMethodRefSerializer;
            case Tag.NameAndType:
                return _nameAndTypeSerializer;
            case Tag.MethodHandle:
                return _methodHandleSerializer;
            case Tag.MethodType:
                return _methodTypeSerializer;
            case Tag.InvokeDynamic:
                return _invokeDynamicSerializer;

            default:
                throw new Exception($"Unsupported constant pool item {tag}");
        }
    }
}
