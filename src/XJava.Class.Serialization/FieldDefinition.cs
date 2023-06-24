using XJava.Class.Serialization.Attributes;

namespace XJava.Class.Serialization;

public class FieldDefinition
{
    #region Construction

    private FieldDefinition()
    {
    }

    #endregion

    #region Fields

    private FieldAccessFlags _accessFlags;
    private string _name = String.Empty;
    private string _descriptor = String.Empty;
    private Dictionary<string, IAttribute> _attributes = new Dictionary<string, IAttribute>();

    #endregion

    #region Properties

    public FieldAccessFlags Access => _accessFlags;

    public string Name => _name;

    public string Descriptor => _descriptor;

    public IEnumerable<IAttribute> Attributes => _attributes.Values;

    #endregion

    #region Methods

    internal static FieldDefinition Deserialize(BigEndianBinaryReader reader, ConstantPoolDefinition pool)
    {
        FieldDefinition def = new FieldDefinition();

        def._accessFlags = (FieldAccessFlags)reader.ReadUInt16();
        def._name = pool.GetUtf8(reader.ReadUInt16());
        def._descriptor = pool.GetUtf8(reader.ReadUInt16());

        ushort attribCount = reader.ReadUInt16();

        for (int i = 0; i < attribCount; i++)
        {
            IAttribute attrib = AttributeDefinition.Deserialize(reader, pool);
            def._attributes.Add(attrib.Name, attrib);
        }

        return def;
    }

    #endregion
}

