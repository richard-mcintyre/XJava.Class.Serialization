using XJava.Class.Serialization.Attributes;

namespace XJava.Class.Serialization;

public class ClassDefinition
{
    record MethodNameAndDescriptor(string Name, string Descriptor);

    #region Construction

    private ClassDefinition()
    {
    }

    #endregion

    #region Fields

    private ushort _majorVersion = 61;
    private ushort _minorVersion;
    private ConstantPoolDefinition _constantPool = new ConstantPoolDefinition();
    private ClassAccessFlags _accessFlags;
    private string _clazzName = String.Empty;
    private string _superClazzName = "java/lang/Object";
    private List<string> _interfaces = new List<string>();
    private Dictionary<string, FieldDefinition> _fields = new Dictionary<string, FieldDefinition>();
    private Dictionary<MethodNameAndDescriptor, MethodDefinition> _methods = new Dictionary<MethodNameAndDescriptor, MethodDefinition>();
    private Dictionary<string, IAttribute> _attributes = new Dictionary<string, IAttribute>();
    private string? _sourceFile;

    #endregion

    #region Properties

    public ushort MajorVersion => _majorVersion;

    public ushort MinorVersion => _minorVersion;

    public ClassAccessFlags Access => _accessFlags;

    public string Name => _clazzName;

    public string SuperName => _superClazzName;

    public IReadOnlyList<string> Interfaces => _interfaces;

    public IEnumerable<FieldDefinition> Fields => _fields.Values;

    public IEnumerable<MethodDefinition> Methods => _methods.Values;

    public IEnumerable<IAttribute> Attributes => _attributes.Values;

    public string? SourceFile => _sourceFile;

    #endregion

    #region Methods

    public FieldDefinition? GetField(string name)
    {
        if (_fields.TryGetValue(name, out FieldDefinition? def))
            return def;

        return default;
    }

    public MethodDefinition? GetMethod(string name, string descriptor)
    {
        MethodNameAndDescriptor key = new MethodNameAndDescriptor(name, descriptor);
        if (_methods.TryGetValue(key, out MethodDefinition? def))
            return def;

        return default;
    }

    public static ClassDefinition Deserialize(Stream stream)
    {
        using BigEndianBinaryReader reader = new BigEndianBinaryReader(stream, leaveOpen: true);

        uint magic = reader.ReadUInt32();
        if (magic != 0xCAFEBABE)
            throw new Exception("Invalid class file");

        ClassDefinition def = new ClassDefinition();
        def._minorVersion = reader.ReadUInt16();
        def._majorVersion = reader.ReadUInt16();
        def._constantPool = ConstantPoolDefinition.Deserialize(stream);
        def._accessFlags = (ClassAccessFlags)reader.ReadUInt16();

        ushort thisClass = reader.ReadUInt16();
        def._clazzName = def._constantPool.GetClassName(thisClass);

        ushort superClass = reader.ReadUInt16();
        def._superClazzName = (superClass != 0) ? def._constantPool.GetClassName(superClass) : "java/lang/Object";

        ushort ifaceCount = reader.ReadUInt16();
        for (int i = 0; i < ifaceCount; i++)
        {
            ushort ifaceIndex = reader.ReadUInt16();
            def._interfaces.Add(def._constantPool.GetClassName(ifaceIndex));
        }

        ushort fieldCount = reader.ReadUInt16();
        for (int i = 0; i < fieldCount; i++)
        {
            FieldDefinition fieldDef = FieldDefinition.Deserialize(reader, def._constantPool);
            def._fields.Add(fieldDef.Name, fieldDef);
        }

        ushort methodCount = reader.ReadUInt16();
        for (int i = 0; i < methodCount; i++)
        {
            MethodDefinition methodDef = MethodDefinition.Deserialize(reader, def._constantPool);
            def._methods.Add(new MethodNameAndDescriptor(methodDef.Name, methodDef.Descriptor), methodDef);
        }

        ushort attribCount = reader.ReadUInt16();
        for (int i = 0; i < attribCount; i++)
        {
            IAttribute attrib = AttributeDefinition.Deserialize(reader, def._constantPool);
            if (attrib is SourceFileAttribute sf)
                def._sourceFile = sf.SourceFileName;
            else
            {
                def._attributes.Add(attrib.Name, attrib);
            }
        }

        return def;
    }

    #endregion
}
