namespace XJava.Class.Serialization.Tests;

public class ClassDefinition_DeserializeTests
{
    private ClassDefinition _classDef;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        using (Stream stream = File.OpenRead(@"..\..\..\TestClassFiles\HelloWorld.class"))
        {
            _classDef = ClassDefinition.Deserialize(stream);
        }


    }

    [Test]
    public void Version()
    {
        Assert.That(_classDef.MajorVersion, Is.EqualTo(61), "Major version");
        Assert.That(_classDef.MinorVersion, Is.EqualTo(0), "Minor version");
    }

    [Test]
    public void ClassAccessFlags()
    {
        Assert.That(_classDef.Access, Is.EqualTo(
            XJava.Class.Serialization.ClassAccessFlags.Public |
            XJava.Class.Serialization.ClassAccessFlags.Final |
            XJava.Class.Serialization.ClassAccessFlags.Super));
    }

    [Test]
    public void ThisClass() =>
        Assert.That(_classDef.Name, Is.EqualTo("HelloWorld"));

    [Test]
    public void SuperClass() =>
        Assert.That(_classDef.SuperName, Is.EqualTo("java/lang/Object"));

    [Test]
    public void InterfaceCount() =>
        Assert.That(_classDef.Interfaces.Count, Is.Zero);

    [Test]
    public void FieldCount()
    {
        Assert.That(_classDef.Fields.Count, Is.EqualTo(1));

        FieldDefinition? fieldDef = _classDef.GetField("_message");
        Assert.IsNotNull(fieldDef);

        Assert.That(fieldDef.Access, Is.EqualTo(FieldAccessFlags.Private | FieldAccessFlags.Static));
        Assert.That(fieldDef.Name, Is.EqualTo("_message"));
        Assert.That(fieldDef.Descriptor, Is.EqualTo("Ljava/lang/String;"));
        Assert.That(fieldDef.Attributes.Count(), Is.Zero);
    }

    [Test]
    public void Methods()
    {
        Assert.That(_classDef.Methods.Count, Is.EqualTo(3));

        // Static constructor
        MethodDefinition? methodDef = _classDef.GetMethod("<clinit>", "()V");
        Assert.IsNotNull(methodDef);

        Assert.That(methodDef.Access, Is.EqualTo(MethodAccessFlags.Static));
        Assert.That(methodDef.Name, Is.EqualTo("<clinit>"));
        Assert.That(methodDef.Descriptor, Is.EqualTo("()V"));
        Assert.That(methodDef.Attributes.Count(), Is.Zero);

        Assert.That(methodDef.Code, Is.Not.Null);
        Assert.That(methodDef.Code.Name, Is.EqualTo("Code"));
        Assert.That(methodDef.Code.MaxStack, Is.EqualTo(1));
        Assert.That(methodDef.Code.MaxLocals, Is.EqualTo(0));
        Assert.That(methodDef.Code.ByteCode, Is.EqualTo(new byte[] { 0x12, 0x19, 0xb3, 0x00, 0x0d, 0xb1 }));
        Assert.That(methodDef.Code.Exceptions.Count, Is.EqualTo(0));
        Assert.That(methodDef.Code.Attributes.Count(), Is.EqualTo(0));

        Assert.That(methodDef.Code.LineNumbers, Is.Not.Null);
        Assert.That(methodDef.Code.LineNumbers.Entries, Is.EqualTo(new LineNumberTableEntry[]
        { 
            new LineNumberTableEntry(StartPC: 0, LineNumber: 3)
        }));

        // Instance constructor
        methodDef = _classDef.GetMethod("<init>", "()V");
        Assert.IsNotNull(methodDef);

        Assert.That(methodDef.Access, Is.EqualTo(MethodAccessFlags.Public));
        Assert.That(methodDef.Name, Is.EqualTo("<init>"));
        Assert.That(methodDef.Descriptor, Is.EqualTo("()V"));
        Assert.That(methodDef.Attributes.Count(), Is.Zero);

        Assert.That(methodDef.Code, Is.Not.Null);
        Assert.That(methodDef.Code.Name, Is.EqualTo("Code"));
        Assert.That(methodDef.Code.MaxStack, Is.EqualTo(1));
        Assert.That(methodDef.Code.MaxLocals, Is.EqualTo(1));
        Assert.That(methodDef.Code.ByteCode, Is.EqualTo(new byte[] { 0x2a, 0xb7, 0x00, 0x01, 0xb1 }));
        Assert.That(methodDef.Code.Exceptions.Count, Is.EqualTo(0));
        Assert.That(methodDef.Code.Attributes.Count(), Is.EqualTo(0));

        Assert.That(methodDef.Code.LineNumbers, Is.Not.Null);
        Assert.That(methodDef.Code.LineNumbers.Entries, Is.EqualTo(new LineNumberTableEntry[]
        {
            new LineNumberTableEntry(StartPC: 0, LineNumber: 1)
        }));

        // main
        methodDef = _classDef.GetMethod("main", "([Ljava/lang/String;)V");                                                
        Assert.IsNotNull(methodDef);

        Assert.That(methodDef.Access, Is.EqualTo(MethodAccessFlags.Public | MethodAccessFlags.Static));
        Assert.That(methodDef.Name, Is.EqualTo("main"));
        Assert.That(methodDef.Descriptor, Is.EqualTo("([Ljava/lang/String;)V"));
        Assert.That(methodDef.Attributes.Count(), Is.Zero);

        Assert.That(methodDef.Code, Is.Not.Null);
        Assert.That(methodDef.Code.Name, Is.EqualTo("Code"));
        Assert.That(methodDef.Code.MaxStack, Is.EqualTo(2));
        Assert.That(methodDef.Code.MaxLocals, Is.EqualTo(1));
        Assert.That(methodDef.Code.ByteCode, Is.EqualTo(new byte[] { 0xb2, 0x00, 0x07, 0xb2, 0x00, 0x0d, 0xb6, 0x00, 0x13, 0xb1 }));
        Assert.That(methodDef.Code.Exceptions.Count(), Is.EqualTo(0));
        Assert.That(methodDef.Code.Attributes.Count(), Is.EqualTo(0));

        Assert.That(methodDef.Code.LineNumbers, Is.Not.Null);
        Assert.That(methodDef.Code.LineNumbers.Entries, Is.EqualTo(new LineNumberTableEntry[]
        {
            new LineNumberTableEntry(StartPC: 0, LineNumber: 7),
            new LineNumberTableEntry(StartPC: 9, LineNumber: 8)
        }));
    }

    [Test]
    public void ClassFileAttributes()
    {
        Assert.That(_classDef.Attributes.Count(), Is.EqualTo(0));

        Assert.That(_classDef.SourceFile, Is.EqualTo("HelloWorld.java"));
    }
}