namespace XJava.Class.Serialization.Attributes;

public class LineNumberAttribute : AttributeDefinition
{
    #region Construction

    internal LineNumberAttribute()
        : base(AttributeNames.LineNumberTable)
    {
    }

    #endregion

    #region Fields

    private List<LineNumberTableEntry> _entries = new List<LineNumberTableEntry>();

    #endregion

    #region Properties

    public IReadOnlyList<LineNumberTableEntry> Entries => _entries;

    #endregion

    #region Methods

    internal override void DeserializeData(BigEndianBinaryReader reader, ConstantPoolDefinition pool)
    {
        reader.ReadUInt32();    // attribute length

        ushort count = reader.ReadUInt16();
        for (int i = 0; i < count; i++)
        {
            ushort startPC = reader.ReadUInt16();
            ushort lineNumber = reader.ReadUInt16();

            _entries.Add(new LineNumberTableEntry(startPC, lineNumber));
        }
    }

    #endregion
}
