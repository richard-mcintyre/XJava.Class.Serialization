namespace XJava.Class.Serialization.Attributes;

public class SourceFileAttribute : AttributeDefinition
{
    #region Construction

    internal SourceFileAttribute()
        : base(AttributeNames.SourceFile)
    {
    }

    #endregion

    #region Fields

    private string _sourceFileName = String.Empty;

    #endregion

    #region Properties

    public string SourceFileName => _sourceFileName;

    #endregion

    #region Methods

    internal override void DeserializeData(BigEndianBinaryReader reader, ConstantPoolDefinition pool)
    {
        reader.ReadUInt32();    // attribute length

        ushort nameIndex = reader.ReadUInt16();
        _sourceFileName = pool.GetUtf8(nameIndex);
    }

    #endregion
}
