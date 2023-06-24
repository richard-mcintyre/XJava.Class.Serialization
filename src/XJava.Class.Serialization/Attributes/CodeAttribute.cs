namespace XJava.Class.Serialization.Attributes;

public class CodeAttribute : AttributeDefinition
{
    #region Construction

    internal CodeAttribute()
        : base(AttributeNames.Code)
    {
    }

    #endregion

    #region Fields

    private ushort _maxStack;
    private ushort _maxLocals;
    private byte[] _byteCode = Array.Empty<byte>();
    private List<ExceptionTableEntry> _exceptions = new List<ExceptionTableEntry>();
    private Dictionary<string, IAttribute> _attributes = new Dictionary<string, IAttribute>();

    private LineNumberAttribute? _lineNumbers;

    #endregion

    #region Properties

    public ushort MaxStack => _maxStack;

    public ushort MaxLocals => _maxLocals;

    public byte[] ByteCode => _byteCode;

    public IReadOnlyList<ExceptionTableEntry> Exceptions => _exceptions;

    public IEnumerable<IAttribute> Attributes => _attributes.Values;

    public LineNumberAttribute? LineNumbers => _lineNumbers;

    #endregion

    #region Methods

    internal override void DeserializeData(BigEndianBinaryReader reader, ConstantPoolDefinition pool)
    {
        reader.ReadUInt32();    // attribute length

        _maxStack = reader.ReadUInt16();
        _maxLocals = reader.ReadUInt16();

        uint length = reader.ReadUInt32();
        _byteCode = reader.ReadBytes((int)length);

        ushort exceptionCount = reader.ReadUInt16();
        for (int i = 0; i < exceptionCount; i++)
        {
            ushort startPC = reader.ReadUInt16();
            ushort endPC = reader.ReadUInt16();
            ushort handlerPC = reader.ReadUInt16();

            ushort catchTypeIndex = reader.ReadUInt16();
            string catchType = pool.GetClassName(catchTypeIndex);

            _exceptions.Add(new ExceptionTableEntry(startPC, endPC, handlerPC, catchType));
        }

        ushort attribCount = reader.ReadUInt16();
        for (int i = 0; i < attribCount; i++)
        {
            IAttribute attrib = AttributeDefinition.Deserialize(reader, pool);

            if (attrib is LineNumberAttribute lineNumber)
                _lineNumbers = lineNumber;
            else
            {
                _attributes.Add(attrib.Name, attrib);
            }
        }
    }

    #endregion
}
