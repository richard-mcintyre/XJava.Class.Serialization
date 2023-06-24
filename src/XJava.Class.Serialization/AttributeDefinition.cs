using XJava.Class.Serialization.Attributes;

namespace XJava.Class.Serialization;

public abstract class AttributeDefinition : IAttribute
{
    #region Construction

    internal AttributeDefinition(string name)
    {
        _name = name;
    }

    #endregion

    #region Fields

    private readonly string _name;

    #endregion

    #region Properties

    public string Name => _name;

    #endregion

    #region Methods

    internal static IAttribute Deserialize(BigEndianBinaryReader reader, ConstantPoolDefinition pool)
    {
        string name = pool.GetUtf8(reader.ReadUInt16());

        if (String.Equals(name, AttributeNames.Code, StringComparison.Ordinal))
        {
            CodeAttribute code = new CodeAttribute();
            code.DeserializeData(reader, pool);
            return code;
        }
        else if (String.Equals(name, AttributeNames.LineNumberTable, StringComparison.Ordinal))
        {
            LineNumberAttribute lineNumber = new LineNumberAttribute();
            lineNumber.DeserializeData(reader, pool);
            return lineNumber;
        }
        else if (String.Equals(name, AttributeNames.SourceFile, StringComparison.Ordinal))
        {
            SourceFileAttribute sourceFile = new SourceFileAttribute();
            sourceFile.DeserializeData(reader, pool);
            return sourceFile;
        }

        UnknownAttribute def = new UnknownAttribute(name);
        def.DeserializeData(reader, pool);

        return def;
    }

    internal abstract void DeserializeData(BigEndianBinaryReader reader, ConstantPoolDefinition pool);

    #endregion
}

public class UnknownAttribute : AttributeDefinition
{
    #region Construction

    public UnknownAttribute(string name)
        : base(name)
    {
    }

    #endregion

    #region Fields

    private byte[] _data = Array.Empty<byte>();

    #endregion

    #region Properties

    public byte[] Data => _data;

    #endregion

    #region Methods

    internal override void DeserializeData(BigEndianBinaryReader reader, ConstantPoolDefinition pool)
    {
        uint length = reader.ReadUInt32();
        _data = reader.ReadBytes((int)length);
    }

    #endregion
}

