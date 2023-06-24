using XJava.Class.Serialization.Attributes;

namespace XJava.Class.Serialization;

public class MethodDefinition
{
    #region Construction

    private MethodDefinition()
    {
    }

    #endregion

    #region Fields

    private MethodAccessFlags _accessFlags;
    private string _name = String.Empty;
    private string _descriptor = String.Empty;
    private CodeAttribute? _code;
    private Dictionary<string, IAttribute> _attributes = new Dictionary<string, IAttribute>();

    #endregion

    #region Properties

    public MethodAccessFlags Access => _accessFlags;

    public string Name => _name;

    public string Descriptor => _descriptor;

    public CodeAttribute? Code => _code;

    public IEnumerable<IAttribute> Attributes => _attributes.Values;

    #endregion

    #region Methods

    internal static MethodDefinition Deserialize(BigEndianBinaryReader reader, ConstantPoolDefinition pool)
    {
        MethodDefinition def = new MethodDefinition();

        def._accessFlags = (MethodAccessFlags)reader.ReadUInt16();
        def._name = pool.GetUtf8(reader.ReadUInt16());
        def._descriptor = pool.GetUtf8(reader.ReadUInt16());

        ushort attribCount = reader.ReadUInt16();

        for (int i = 0; i < attribCount; i++)
        {
            IAttribute attrib = AttributeDefinition.Deserialize(reader, pool);
            if (attrib is CodeAttribute code)
                def._code = code;
            else
            {
                def._attributes.Add(attrib.Name, attrib);
            }
        }

        return def;
    }

    #endregion
}

