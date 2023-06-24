namespace XJava.Class.Serialization;

public static class OpCodes
{
    #region Construction

    static OpCodes()
    {
        foreach (OpCode op in OpCodes.All)
            _codes.Add((ByteCode)op.Code, op);
    }

    #endregion

    #region Fields

    private static readonly Dictionary<ByteCode, OpCode> _codes = new Dictionary<ByteCode, OpCode>();

    #endregion

    #region OpCodes

    public static OpCode aaload { get; } = 
        new OpCode(nameof(aaload), (byte)ByteCode.aaload,
            Description: "Load reference from array");

    public static OpCode aastore { get; } = 
        new OpCode(nameof(aastore), (byte)ByteCode.aastore,
            Description: "Store into reference array");

    public static OpCode aconst_null { get; } = 
        new OpCode(nameof(aconst_null), (byte)ByteCode.aconst_null,
            Description: "Push null");

    public static OpCode aload { get; } = 
        new OpCode(nameof(aload), (byte)ByteCode.aload, 1,
            Description: "Load reference from local variable");

    public static OpCode aload_0 { get; } = 
        new OpCode(nameof(aload_0), (byte)ByteCode.aload_0,
            Description: "Load reference from local variable");

    public static OpCode aload_1 { get; } = 
        new OpCode(nameof(aload_1), (byte)ByteCode.aload_1,
            Description: "Load reference from local variable");

    public static OpCode aload_2 { get; } = 
        new OpCode(nameof(aload_2), (byte)ByteCode.aload_2,
            Description: "Load reference from local variable");

    public static OpCode aload_3 { get; } = 
        new OpCode(nameof(aload_3), (byte)ByteCode.aload_3,
            Description: "Load reference from local variable");

    public static OpCode anewarray { get; } = 
        new OpCode(nameof(anewarray), (byte)ByteCode.anewarray, 2,
            Description: "Create new array of reference");

    public static OpCode areturn { get; } = 
        new OpCode(nameof(areturn), (byte)ByteCode.areturn,
            Description: "Return reference from method");

    public static OpCode arraylength { get; } = 
        new OpCode(nameof(arraylength), (byte)ByteCode.arraylength,
            Description: "Get length of array");

    public static OpCode astore { get; } = 
        new OpCode(nameof(astore), (byte)ByteCode.astore, 1,
            Description: "Store reference into local variable");

    public static OpCode astore_0 { get; } = 
        new OpCode(nameof(astore_0), (byte)ByteCode.astore_0,
            Description: "Store reference into local variable");

    public static OpCode astore_1 { get; } = 
        new OpCode(nameof(astore_1), (byte)ByteCode.astore_1,
            Description: "Store reference into local variable");

    public static OpCode astore_2 { get; } = 
        new OpCode(nameof(astore_2), (byte)ByteCode.astore_2,
            Description: "Store reference into local variable");

    public static OpCode astore_3 { get; } = 
        new OpCode(nameof(astore_3), (byte)ByteCode.astore_3,
            Description: "Store reference into local variable");

    public static OpCode athrow { get; } = 
        new OpCode(nameof(athrow), (byte)ByteCode.athrow,
            Description: "Throw exception or error");

    public static OpCode baload { get; } = 
        new OpCode(nameof(baload), (byte)ByteCode.baload,
            Description: "Load byte or boolean from array");

    public static OpCode bastore { get; } = 
        new OpCode(nameof(bastore), (byte)ByteCode.bastore,
            Description: "Store into byte or boolean array");

    public static OpCode bipush { get; } = 
        new OpCode(nameof(bipush), (byte)ByteCode.bipush, 1,
            Description: "Push byte");

    public static OpCode breakpoint { get; } = 
        new OpCode(nameof(breakpoint), (byte)ByteCode.breakpoint,
            Description: "Breakpoint");

    public static OpCode caload { get; } = 
        new OpCode(nameof(caload), (byte)ByteCode.caload,
            Description: "Load char from array");

    public static OpCode castore { get; } = 
        new OpCode(nameof(castore), (byte)ByteCode.castore,
            Description: "Store into char array");

    public static OpCode checkcast { get; } = 
        new OpCode(nameof(checkcast), (byte)ByteCode.checkcast, 2,
            Description: "Check whether object is of given type");

    public static OpCode d2f { get; } = 
        new OpCode(nameof(d2f), (byte)ByteCode.d2f,
            Description: "Convert double to float");

    public static OpCode d2i { get; } = 
        new OpCode(nameof(d2i), (byte)ByteCode.d2i,
            Description: "Convert double to int");

    public static OpCode d2l { get; } = 
        new OpCode(nameof(d2l), (byte)ByteCode.d2l,
            Description: "Convert double to long");

    public static OpCode dadd { get; } = 
        new OpCode(nameof(dadd), (byte)ByteCode.dadd,
            Description: "Add double");

    public static OpCode daload { get; } = 
        new OpCode(nameof(daload), (byte)ByteCode.daload,
            Description: "Load double from array");

    public static OpCode dastore { get; } = 
        new OpCode(nameof(dastore), (byte)ByteCode.dastore,
            Description: "Store into double array");

    public static OpCode dcmpg { get; } = 
        new OpCode(nameof(dcmpg), (byte)ByteCode.dcmpg,
            Description: "Compare double");

    public static OpCode dcmpl { get; } = 
        new OpCode(nameof(dcmpl), (byte)ByteCode.dcmpl,
            Description: "Compare double");

    public static OpCode dconst_0 { get; } = 
        new OpCode(nameof(dconst_0), (byte)ByteCode.dconst_0,
            Description: "Push double");

    public static OpCode dconst_1 { get; } = 
        new OpCode(nameof(dconst_1), (byte)ByteCode.dconst_1,
            Description: "Push double");

    public static OpCode ddiv { get; } = 
        new OpCode(nameof(ddiv), (byte)ByteCode.ddiv,
            Description: "Divide double");

    public static OpCode dload { get; } = 
        new OpCode(nameof(dload), (byte)ByteCode.dload, 1,
            Description: "Load double from local variable");

    public static OpCode dload_0 { get; } = 
        new OpCode(nameof(dload_0), (byte)ByteCode.dload_0,
            Description: "Load double from local variable");

    public static OpCode dload_1 { get; } = 
        new OpCode(nameof(dload_1), (byte)ByteCode.dload_1,
            Description: "Load double from local variable");

    public static OpCode dload_2 { get; } = 
        new OpCode(nameof(dload_2), (byte)ByteCode.dload_2,
            Description: "Load double from local variable");

    public static OpCode dload_3 { get; } = 
        new OpCode(nameof(dload_3), (byte)ByteCode.dload_3,
            Description: "Load double from local variable");

    public static OpCode dmul { get; } = 
        new OpCode(nameof(dmul), (byte)ByteCode.dmul,
            Description: "Multiply double");

    public static OpCode dneg { get; } = 
        new OpCode(nameof(dneg), (byte)ByteCode.dneg,
            Description: "Negate double");

    public static OpCode drem { get; } = 
        new OpCode(nameof(drem), (byte)ByteCode.drem,
            Description: "Remainder double");

    public static OpCode dreturn { get; } = 
        new OpCode(nameof(dreturn), (byte)ByteCode.dreturn,
            Description: "Return double from method");

    public static OpCode dstore { get; } = 
        new OpCode(nameof(dstore), (byte)ByteCode.dstore, 1,
            Description: "Store double into local variable");

    public static OpCode dstore_0 { get; } = 
        new OpCode(nameof(dstore_0), (byte)ByteCode.dstore_0,
            Description: "Store double into local variable");

    public static OpCode dstore_1 { get; } = 
        new OpCode(nameof(dstore_1), (byte)ByteCode.dstore_1,
            Description: "Store double into local variable");

    public static OpCode dstore_2 { get; } = 
        new OpCode(nameof(dstore_2), (byte)ByteCode.dstore_2,
            Description: "Store double into local variable");

    public static OpCode dstore_3 { get; } = 
        new OpCode(nameof(dstore_3), (byte)ByteCode.dstore_3,
            Description: "Store double into local variable");

    public static OpCode dsub { get; } = 
        new OpCode(nameof(dsub), (byte)ByteCode.dsub,
            Description: "Subtract double");

    public static OpCode dup { get; } = 
        new OpCode(nameof(dup), (byte)ByteCode.dup,
            Description: "Duplicate the top operand stack value");

    public static OpCode dup_x1 { get; } = 
        new OpCode(nameof(dup_x1), (byte)ByteCode.dup_x1,
            Description: "Duplicate the top operand stack value and insert two values down");

    public static OpCode dup_x2 { get; } = 
        new OpCode(nameof(dup_x2), (byte)ByteCode.dup_x2,
            Description: "Duplicate the top operand stack value and insert two or three values down");

    public static OpCode dup2 { get; } = 
        new OpCode(nameof(dup2), (byte)ByteCode.dup2,
            Description: "Duplicate the top one or two operand stack values");

    public static OpCode dup2_x1 { get; } = 
        new OpCode(nameof(dup2_x1), (byte)ByteCode.dup2_x1,
            Description: "Duplicate the top one or two operand stack values and insert two or three values down");

    public static OpCode dup2_x2 { get; } = 
        new OpCode(nameof(dup2_x2), (byte)ByteCode.dup2_x2,
            Description: "Duplicate the top one or two operand stack values and insert two, three, or four values down");

    public static OpCode f2d { get; } = 
        new OpCode(nameof(f2d), (byte)ByteCode.f2d,
            Description: "Convert float to double");

    public static OpCode f2i { get; } = 
        new OpCode(nameof(f2i), (byte)ByteCode.f2i,
            Description: "Convert float to int");

    public static OpCode f2l { get; } = 
        new OpCode(nameof(f2l), (byte)ByteCode.f2l,
            Description: "Convert float to long");

    public static OpCode fadd { get; } = 
        new OpCode(nameof(fadd), (byte)ByteCode.fadd,
            Description: "Add float");

    public static OpCode faload { get; } = 
        new OpCode(nameof(faload), (byte)ByteCode.faload,
            Description: "Load float from array");

    public static OpCode fastore { get; } = 
        new OpCode(nameof(fastore), (byte)ByteCode.fastore,
            Description: "Store into float array");

    public static OpCode fcmpg { get; } = 
        new OpCode(nameof(fcmpg), (byte)ByteCode.fcmpg,
            Description: "Compare float");

    public static OpCode fcmpl { get; } = 
        new OpCode(nameof(fcmpl), (byte)ByteCode.fcmpl,
            Description: "Compare float");

    public static OpCode fconst_0 { get; } = 
        new OpCode(nameof(fconst_0), (byte)ByteCode.fconst_0,
            Description: "Push float");

    public static OpCode fconst_1 { get; } = 
        new OpCode(nameof(fconst_1), (byte)ByteCode.fconst_1,
            Description: "Push float");

    public static OpCode fconst_2 { get; } = 
        new OpCode(nameof(fconst_2), (byte)ByteCode.fconst_2,
            Description: "Push float");

    public static OpCode fdiv { get; } = 
        new OpCode(nameof(fdiv), (byte)ByteCode.fdiv,
            Description: "Divide float");

    public static OpCode fload { get; } = 
        new OpCode(nameof(fload), (byte)ByteCode.fload, 1,
            Description: "Load float from local variable");

    public static OpCode fload_0 { get; } = 
        new OpCode(nameof(fload_0), (byte)ByteCode.fload_0,
            Description: "Load float from local variable");

    public static OpCode fload_1 { get; } = 
        new OpCode(nameof(fload_1), (byte)ByteCode.fload_1,
            Description: "Load float from local variable");

    public static OpCode fload_2 { get; } = 
        new OpCode(nameof(fload_2), (byte)ByteCode.fload_2,
            Description: "Load float from local variable");

    public static OpCode fload_3 { get; } = 
        new OpCode(nameof(fload_3), (byte)ByteCode.fload_3,
            Description: "Load float from local variable");

    public static OpCode fmul { get; } = 
        new OpCode(nameof(fmul), (byte)ByteCode.fmul,
            Description: "Multiply float");

    public static OpCode fneg { get; } = 
        new OpCode(nameof(fneg), (byte)ByteCode.fneg,
            Description: "Negate float");

    public static OpCode frem { get; } = 
        new OpCode(nameof(frem), (byte)ByteCode.frem,
            Description: "Remainder float");

    public static OpCode freturn { get; } = 
        new OpCode(nameof(freturn), (byte)ByteCode.freturn,
            Description: "Return float from method");

    public static OpCode fstore { get; } = 
        new OpCode(nameof(fstore), (byte)ByteCode.fstore, 1,
            Description: "Store float into local variable");

    public static OpCode fstore_0 { get; } = 
        new OpCode(nameof(fstore_0), (byte)ByteCode.fstore_0,
            Description: "Store float into local variable");

    public static OpCode fstore_1 { get; } = 
        new OpCode(nameof(fstore_1), (byte)ByteCode.fstore_1,
            Description: "Store float into local variable");

    public static OpCode fstore_2 { get; } = 
        new OpCode(nameof(fstore_2), (byte)ByteCode.fstore_2,
            Description: "Store float into local variable");

    public static OpCode fstore_3 { get; } = 
        new OpCode(nameof(fstore_3), (byte)ByteCode.fstore_3,
            Description: "Store float into local variable");

    public static OpCode fsub { get; } = 
        new OpCode(nameof(fsub), (byte)ByteCode.fsub,
            Description: "Subtract float");

    public static OpCode getfield { get; } = 
        new OpCode(nameof(getfield), (byte)ByteCode.getfield, 2,
            Description: "Fetch field from object");

    public static OpCode getstatic { get; } = 
        new OpCode(nameof(getstatic), (byte)ByteCode.getstatic, 2,
            Description: "Get static field from class");

    public static OpCode @goto { get; } = 
        new OpCode(nameof(@goto), (byte)ByteCode.@goto, 2,
            Description: "Branch always");

    public static OpCode goto_w { get; } = 
        new OpCode(nameof(goto_w), (byte)ByteCode.goto_w, 4,
            Description: "Branch always (wide index)");

    public static OpCode i2b { get; } = 
        new OpCode(nameof(i2b), (byte)ByteCode.i2b,
            Description: "Convert int to byte");

    public static OpCode ic2 { get; } = 
        new OpCode(nameof(ic2), (byte)ByteCode.ic2,
            Description: "Convert int to char");

    public static OpCode i2d { get; } = 
        new OpCode(nameof(i2d), (byte)ByteCode.i2d,
            Description: "Convert int to double");

    public static OpCode i2f { get; } = 
        new OpCode(nameof(i2f), (byte)ByteCode.i2f,
            Description: "Convert int to float");

    public static OpCode i2l { get; } = 
        new OpCode(nameof(i2l), (byte)ByteCode.i2l,
            Description: "Convert int to long");

    public static OpCode i2s { get; } = 
        new OpCode(nameof(i2s), (byte)ByteCode.i2s,
            Description: "Convert int to short");

    public static OpCode iadd { get; } = 
        new OpCode(nameof(iadd), (byte)ByteCode.iadd,
            Description: "Add int");

    public static OpCode iaload { get; } = 
        new OpCode(nameof(iaload), (byte)ByteCode.iaload,
            Description: "Load int from array");

    public static OpCode iand { get; } = 
        new OpCode(nameof(iand), (byte)ByteCode.iand,
            Description: "Boolean AND int");

    public static OpCode iastore { get; } = 
        new OpCode(nameof(iastore), (byte)ByteCode.iastore,
            Description: "Store into int array");

    public static OpCode iconst_m1 { get; } = 
        new OpCode(nameof(iconst_m1), (byte)ByteCode.iconst_m1,
            Description: "Push int constant");

    public static OpCode iconst_0 { get; } = 
        new OpCode(nameof(iconst_0), (byte)ByteCode.iconst_0,
            Description: "Push int constant");

    public static OpCode iconst_1 { get; } = 
        new OpCode(nameof(iconst_1), (byte)ByteCode.iconst_1,
            Description: "Push int constant");

    public static OpCode iconst_2 { get; } = 
        new OpCode(nameof(iconst_2), (byte)ByteCode.iconst_2,
            Description: "Push int constant");

    public static OpCode iconst_3 { get; } = 
        new OpCode(nameof(iconst_3), (byte)ByteCode.iconst_3,
            Description: "Push int constant");

    public static OpCode iconst_4 { get; } = 
        new OpCode(nameof(iconst_4), (byte)ByteCode.iconst_4,
            Description: "Push int constant");

    public static OpCode iconst_5 { get; } = 
        new OpCode(nameof(iconst_5), (byte)ByteCode.iconst_5,
            Description: "Push int constant");

    public static OpCode idiv { get; } = 
        new OpCode(nameof(idiv), (byte)ByteCode.idiv,
            Description: "Divide int");

    public static OpCode if_acmpeq { get; } = 
        new OpCode(nameof(if_acmpeq), (byte)ByteCode.if_acmpeq, 2,
            Description: "Branch if reference comparison succeeds");

    public static OpCode if_acmpne { get; } = 
        new OpCode(nameof(if_acmpne), (byte)ByteCode.if_acmpne, 2,
            Description: "Branch if reference comparison succeeds");

    public static OpCode if_icmpeq { get; } = 
        new OpCode(nameof(if_icmpeq), (byte)ByteCode.if_icmpeq, 2,
            Description: "Branch if int comparison succeeds");

    public static OpCode if_icmpne { get; } = 
        new OpCode(nameof(if_icmpne), (byte)ByteCode.if_icmpne, 2,
            Description: "Branch if int comparison succeeds");

    public static OpCode if_icmplt { get; } = 
        new OpCode(nameof(if_icmplt), (byte)ByteCode.if_icmplt, 2,
            Description: "Branch if int comparison succeeds");

    public static OpCode if_icmpge { get; } = 
        new OpCode(nameof(if_icmpge), (byte)ByteCode.if_icmpge, 2,
            Description: "Branch if int comparison succeeds");

    public static OpCode if_icmpgt { get; } = 
        new OpCode(nameof(if_icmpgt), (byte)ByteCode.if_icmpgt, 2,
            Description: "Branch if int comparison succeeds");

    public static OpCode if_icmple { get; } = 
        new OpCode(nameof(if_icmple), (byte)ByteCode.if_icmple, 2,
            Description: "Branch if int comparison succeeds");

    public static OpCode ifeq { get; } = 
        new OpCode(nameof(ifeq), (byte)ByteCode.ifeq, 2,
            Description: "Branch if int comparison with zero succeeds");

    public static OpCode ifne { get; } = 
        new OpCode(nameof(ifne), (byte)ByteCode.ifne, 2,
            Description: "Branch if int comparison with zero succeeds");

    public static OpCode iflt { get; } = 
        new OpCode(nameof(iflt), (byte)ByteCode.iflt, 2,
            Description: "Branch if int comparison with zero succeeds");

    public static OpCode ifge { get; } = 
        new OpCode(nameof(ifge), (byte)ByteCode.ifge, 2,
            Description: "Branch if int comparison with zero succeeds");

    public static OpCode ifgt { get; } = 
        new OpCode(nameof(ifgt), (byte)ByteCode.ifgt, 2,
            Description: "Branch if int comparison with zero succeeds");

    public static OpCode ifle { get; } = 
        new OpCode(nameof(ifle), (byte)ByteCode.ifle, 2,
            Description: "Branch if int comparison with zero succeeds");

    public static OpCode ifnonnull { get; } = 
        new OpCode(nameof(ifnonnull), (byte)ByteCode.ifnonnull, 2,
            Description: "Branch if reference not null");

    public static OpCode ifnull { get; } = 
        new OpCode(nameof(ifnull), (byte)ByteCode.ifnull, 2,
            Description: "Branch if reference is null");

    public static OpCode iinc { get; } = 
        new OpCode(nameof(iinc), (byte)ByteCode.iinc, 2,
            Description: "Increment local variable by constant");

    public static OpCode iload { get; } = 
        new OpCode(nameof(iload), (byte)ByteCode.iload, 1,
            Description: "Load int from local variable");

    public static OpCode iload_0 { get; } = 
        new OpCode(nameof(iload_0), (byte)ByteCode.iload_0,
            Description: "Load int from local variable");

    public static OpCode iload_1 { get; } = 
        new OpCode(nameof(iload_1), (byte)ByteCode.iload_1,
            Description: "Load int from local variable");

    public static OpCode iload_2 { get; } = 
        new OpCode(nameof(iload_2), (byte)ByteCode.iload_2,
            Description: "Load int from local variable");

    public static OpCode iload_3 { get; } = 
        new OpCode(nameof(iload_3), (byte)ByteCode.iload_3,
            Description: "Load int from local variable");

    public static OpCode impdep1 { get; } = 
        new OpCode(nameof(impdep1), (byte)ByteCode.impdep1,
            Description: "Implementation dependant 1");

    public static OpCode impdep2 { get; } = 
        new OpCode(nameof(impdep2), (byte)ByteCode.impdep2,
            Description: "Implementation dependant 2");

    public static OpCode imul { get; } = 
        new OpCode(nameof(imul), (byte)ByteCode.imul,
            Description: "Multiply int");

    public static OpCode ineg { get; } = 
        new OpCode(nameof(ineg), (byte)ByteCode.ineg,
            Description: "Negate int");

    public static OpCode instanceof { get; } = 
        new OpCode(nameof(instanceof), (byte)ByteCode.instanceof, 2,
            Description: "Determine if object is of given type");

    public static OpCode invokedynamic { get; } = 
        new OpCode(nameof(invokedynamic), (byte)ByteCode.invokedynamic, 4,
            Description: "Invoke dynamic method");

    public static OpCode invokeinterface { get; } = 
        new OpCode(nameof(invokeinterface), (byte)ByteCode.invokeinterface, 4,
            Description: "Invoke interface method");

    public static OpCode invokespecial { get; } = 
        new OpCode(nameof(invokespecial), (byte)ByteCode.invokespecial, 2,
            Description: "Invoke instance method; special handling for superclass, private, and instance initialization method invocations");

    public static OpCode invokestatic { get; } = 
        new OpCode(nameof(invokestatic), (byte)ByteCode.invokestatic, 2,
            Description: "Invoke a class (static) method");

    public static OpCode invokevirtual { get; } = 
        new OpCode(nameof(invokevirtual), (byte)ByteCode.invokevirtual, 2,
            Description: "Invoke instance method; dispatch based on class");

    public static OpCode ior { get; } = 
        new OpCode(nameof(ior), (byte)ByteCode.ior,
            Description: "Boolean OR int");

    public static OpCode irem { get; } = 
        new OpCode(nameof(irem), (byte)ByteCode.irem,
            Description: "Remainder int");

    public static OpCode ireturn { get; } = 
        new OpCode(nameof(ireturn), (byte)ByteCode.ireturn,
            Description: "Return int from method");

    public static OpCode ishl { get; } = 
        new OpCode(nameof(ishl), (byte)ByteCode.ishl,
            Description: "Shift left int");

    public static OpCode ishr { get; } = 
        new OpCode(nameof(ishr), (byte)ByteCode.ishr,
            Description: "Arithmetic shift right int");

    public static OpCode istore { get; } = 
        new OpCode(nameof(istore), (byte)ByteCode.istore, 1,
            Description: "Store int into local variable");

    public static OpCode istore_0 { get; } = 
        new OpCode(nameof(istore_0), (byte)ByteCode.istore_0,
            Description: "Store int into local variable");

    public static OpCode istore_1 { get; } = 
        new OpCode(nameof(istore_1), (byte)ByteCode.istore_1,
            Description: "Store int into local variable");

    public static OpCode istore_2 { get; } = 
        new OpCode(nameof(istore_2), (byte)ByteCode.istore_2,
            Description: "Store int into local variable");

    public static OpCode istore_3 { get; } = 
        new OpCode(nameof(istore_3), (byte)ByteCode.istore_3,
            Description: "Store int into local variable");

    public static OpCode isub { get; } = 
        new OpCode(nameof(isub), (byte)ByteCode.isub,
            Description: "Subtract int");

    public static OpCode iushr { get; } = 
        new OpCode(nameof(iushr), (byte)ByteCode.iushr,
            Description: "Logical shift right int");

    public static OpCode ixor { get; } = 
        new OpCode(nameof(ixor), (byte)ByteCode.ixor,
            Description: "Boolean XOR int");

    public static OpCode jsr { get; } = 
        new OpCode(nameof(jsr), (byte)ByteCode.jsr, 2,
            Description: "Jump subroutine");

    public static OpCode jsr_w { get; } = 
        new OpCode(nameof(jsr_w), (byte)ByteCode.jsr_w, 4,
            Description: "Jump subroutine (wide index)");

    public static OpCode l2d { get; } = 
        new OpCode(nameof(l2d), (byte)ByteCode.l2d,
            Description: "Convert long to double");

    public static OpCode l2f { get; } = 
        new OpCode(nameof(l2f), (byte)ByteCode.l2f,
            Description: "Convert long to float");

    public static OpCode l2i { get; } = 
        new OpCode(nameof(l2i), (byte)ByteCode.l2i,
            Description: "Convert long to int");

    public static OpCode ladd { get; } = 
        new OpCode(nameof(ladd), (byte)ByteCode.ladd,
            Description: "Add long");

    public static OpCode laload { get; } = 
        new OpCode(nameof(laload), (byte)ByteCode.laload,
            Description: "Load long from array");

    public static OpCode land { get; } = 
        new OpCode(nameof(land), (byte)ByteCode.land,
            Description: "Boolean AND long");

    public static OpCode lastore { get; } = 
        new OpCode(nameof(lastore), (byte)ByteCode.lastore,
            Description: "Store into long array");

    public static OpCode lcmp { get; } = 
        new OpCode(nameof(lcmp), (byte)ByteCode.lcmp,
            Description: "Compare long");

    public static OpCode lconst_0 { get; } = 
        new OpCode(nameof(lconst_0), (byte)ByteCode.lconst_0,
            Description: "Push long constant");

    public static OpCode lconst_1 { get; } = 
        new OpCode(nameof(lconst_1), (byte)ByteCode.lconst_1,
            Description: "Push long constant");

    public static OpCode ldc { get; } = 
        new OpCode(nameof(ldc), (byte)ByteCode.ldc, 1,
            Description: "Push item from run-time constant pool");

    public static OpCode ldc_w { get; } = 
        new OpCode(nameof(ldc_w), (byte)ByteCode.ldc_w, 2,
            Description: "Push item from run-time constant pool (wide index)");

    public static OpCode ldc2_w { get; } = 
        new OpCode(nameof(ldc2_w), (byte)ByteCode.ldc2_w, 2,
            Description: "Push long or double from run-time constant pool (wide index)");

    public static OpCode ldiv { get; } = 
        new OpCode(nameof(ldiv), (byte)ByteCode.ldiv,
            Description: "Divide long");

    public static OpCode lload { get; } = 
        new OpCode(nameof(lload), (byte)ByteCode.lload, 1,
            Description: "Load long from local variable");

    public static OpCode lload_0 { get; } = 
        new OpCode(nameof(lload_0), (byte)ByteCode.lload_0,
            Description: "Load long from local variable");

    public static OpCode lload_1 { get; } = 
        new OpCode(nameof(lload_1), (byte)ByteCode.lload_1,
            Description: "Load long from local variable");

    public static OpCode lload_2 { get; } = 
        new OpCode(nameof(lload_2), (byte)ByteCode.lload_2,
            Description: "Load long from local variable");

    public static OpCode lload_3 { get; } = 
        new OpCode(nameof(lload_3), (byte)ByteCode.lload_3,
            Description: "Load long from local variable");

    public static OpCode lmul { get; } = 
        new OpCode(nameof(lmul), (byte)ByteCode.lmul,
            Description: "Multiply long");

    public static OpCode lneg { get; } = 
        new OpCode(nameof(lneg), (byte)ByteCode.lneg,
            Description: "Negate long");

    public static OpCode lookupswitch { get; } = 
        new OpCode(nameof(lookupswitch), (byte)ByteCode.lookupswitch, -1,
            Description: "Access jump table by key match and jump");

    public static OpCode lor { get; } = 
        new OpCode(nameof(lor), (byte)ByteCode.lor,
            Description: "Boolean OR long");

    public static OpCode lrem { get; } = 
        new OpCode(nameof(lrem), (byte)ByteCode.lrem,
            Description: "Remainder long");

    public static OpCode lreturn { get; } = 
        new OpCode(nameof(lreturn), (byte)ByteCode.lreturn,
            Description: "Return long from method");

    public static OpCode lshl { get; } = 
        new OpCode(nameof(lshl), (byte)ByteCode.lshl,
            Description: "Shift left long");

    public static OpCode lshr { get; } = 
        new OpCode(nameof(lshr), (byte)ByteCode.lshr,
            Description: "Arithmetic shift right long");

    public static OpCode lstore { get; } = 
        new OpCode(nameof(lstore), (byte)ByteCode.lstore, 1,
            Description: "Store long into local variable");

    public static OpCode lstore_0 { get; } = 
        new OpCode(nameof(lstore_0), (byte)ByteCode.lstore_0,
            Description: "Store long into local variable");

    public static OpCode lstore_1 { get; } = 
        new OpCode(nameof(lstore_1), (byte)ByteCode.lstore_1,
            Description: "Store long into local variable");

    public static OpCode lstore_2 { get; } = 
        new OpCode(nameof(lstore_2), (byte)ByteCode.lstore_2,
            Description: "Store long into local variable");

    public static OpCode lstore_3 { get; } = 
        new OpCode(nameof(lstore_3), (byte)ByteCode.lstore_3,
            Description: "Store long into local variable");

    public static OpCode lsub { get; } = 
        new OpCode(nameof(lsub), (byte)ByteCode.lsub,
            Description: "Subtract long");

    public static OpCode lushr { get; } = 
        new OpCode(nameof(lushr), (byte)ByteCode.lushr,
            Description: "Logical shift right long");

    public static OpCode lxor { get; } = 
        new OpCode(nameof(lxor), (byte)ByteCode.lxor,
            Description: "Boolean XOR long");

    public static OpCode monitorenter { get; } = 
        new OpCode(nameof(monitorenter), (byte)ByteCode.monitorenter,
            Description: "Enter monitor for object");

    public static OpCode monitorexit { get; } = 
        new OpCode(nameof(monitorexit), (byte)ByteCode.monitorexit,
            Description: "Exit monitor for object");

    public static OpCode multianewarray { get; } = 
        new OpCode(nameof(multianewarray), (byte)ByteCode.multianewarray, 3,
            Description: "Create new multidimensional array");

    public static OpCode @new { get; } = 
        new OpCode(nameof(@new), (byte)ByteCode.@new, 2,
            Description: "Create new object");

    public static OpCode newarray { get; } = 
        new OpCode(nameof(newarray), (byte)ByteCode.newarray, 1,
            Description: "Create new array");

    public static OpCode nop { get; } = 
        new OpCode(nameof(nop), (byte)ByteCode.nop,
            Description: "Do nothing");

    public static OpCode pop { get; } = 
        new OpCode(nameof(pop), (byte)ByteCode.pop,
            Description: "Pop the top operand stack value");

    public static OpCode pop2 { get; } = 
        new OpCode(nameof(pop2), (byte)ByteCode.pop2,
            Description: "Pop the top one or two operand stack values");

    public static OpCode putfield { get; } = 
        new OpCode(nameof(putfield), (byte)ByteCode.putfield, 2,
            Description: "Set field in object");

    public static OpCode putstatic { get; } = 
        new OpCode(nameof(putstatic), (byte)ByteCode.putstatic, 2,
            Description: "Set static field in class");

    public static OpCode ret { get; } = 
        new OpCode(nameof(ret), (byte)ByteCode.ret, 1,
            Description: "Return from subroutine");

    public static OpCode @return { get; } = 
        new OpCode(nameof(@return), (byte)ByteCode.@return,
            Description: "Return void from method");

    public static OpCode saload { get; } = 
        new OpCode(nameof(saload), (byte)ByteCode.saload,
            Description: "Load short from array");

    public static OpCode sastore { get; } = 
        new OpCode(nameof(sastore), (byte)ByteCode.sastore,
            Description: "Store into short array");

    public static OpCode sipush { get; } = 
        new OpCode(nameof(sipush), (byte)ByteCode.sipush, 2,
            Description: "Push short");

    public static OpCode swap { get; } = 
        new OpCode(nameof(swap), (byte)ByteCode.swap,
            Description: "Swap the top two operand stack values");

    public static OpCode tableswitch { get; } = 
        new OpCode(nameof(tableswitch), (byte)ByteCode.tableswitch, -1,
            Description: "Access jump table by index and jump");

    public static OpCode wide { get; } = 
        new OpCode(nameof(wide), (byte)ByteCode.wide, -1,
            Description: "Extend local variable index by additional bytes");

    #endregion

    #region All 

    public static OpCode[] All { get; } = new OpCode[]
    {
        aaload,
        aastore,
        aconst_null,
        aload,
        aload_0,
        aload_1,
        aload_2,
        aload_3,
        anewarray,
        areturn,
        arraylength,
        astore,
        astore_0,
        astore_1,
        astore_2,
        astore_3,
        athrow,
        baload,
        bastore,
        bipush,
        breakpoint,
        caload,
        castore,
        checkcast,
        d2f,
        d2i,
        d2l,
        dadd,
        daload,
        dastore,
        dcmpg,
        dcmpl,
        dconst_0,
        dconst_1,
        ddiv,
        dload,
        dload_0,
        dload_1,
        dload_2,
        dload_3,
        dmul,
        dneg,
        drem,
        dreturn,
        dstore,
        dstore_0,
        dstore_1,
        dstore_2,
        dstore_3,
        dsub,
        dup,
        dup_x1,
        dup_x2,
        dup2,
        dup2_x1,
        dup2_x2,
        f2d,
        f2i,
        f2l,
        fadd,
        faload,
        fastore,
        fcmpg,
        fcmpl,
        fconst_0,
        fconst_1,
        fconst_2,
        fdiv,
        fload,
        fload_0,
        fload_1,
        fload_2,
        fload_3,
        fmul,
        fneg,
        frem,
        freturn,
        fstore,
        fstore_0,
        fstore_1,
        fstore_2,
        fstore_3,
        fsub,
        getfield,
        getstatic,
        @goto,
        goto_w,
        i2b,
        ic2,
        i2d,
        i2f,
        i2l,
        i2s,
        iadd,
        iaload,
        iand,
        iastore,
        iconst_m1,
        iconst_0,
        iconst_1,
        iconst_2,
        iconst_3,
        iconst_4,
        iconst_5,
        idiv,
        if_acmpeq,
        if_acmpne,
        if_icmpeq,
        if_icmpne,
        if_icmplt,
        if_icmpge,
        if_icmpgt,
        if_icmple,
        ifeq,
        ifne,
        iflt,
        ifge,
        ifgt,
        ifle,
        ifnonnull,
        ifnull,
        iinc,
        iload,
        iload_0,
        iload_1,
        iload_2,
        iload_3,
        impdep1,
        impdep2,
        imul,
        ineg,
        instanceof,
        invokedynamic,
        invokeinterface,
        invokespecial,
        invokestatic,
        invokevirtual,
        ior,
        irem,
        ireturn,
        ishl,
        ishr,
        istore,
        istore_0,
        istore_1,
        istore_2,
        istore_3,
        isub,
        iushr,
        ixor,
        jsr,
        jsr_w,
        l2d,
        l2f,
        l2i,
        ladd,
        laload,
        land,
        lastore,
        lcmp,
        lconst_0,
        lconst_1,
        ldc,
        ldc_w,
        ldc2_w,
        ldiv,
        lload,
        lload_0,
        lload_1,
        lload_2,
        lload_3,
        lmul,
        lneg,
        lookupswitch,
        lor,
        lrem,
        lreturn,
        lshl,
        lshr,
        lstore,
        lstore_0,
        lstore_1,
        lstore_2,
        lstore_3,
        lsub,
        lushr,
        lxor,
        monitorenter,
        monitorexit,
        multianewarray,
        @new,
        newarray,
        nop,
        pop,
        pop2,
        putfield,
        putstatic,
        ret,
        @return,
        saload,
        sastore,
        sipush,
        swap,
        tableswitch,
        wide
    };

    #endregion

    #region Methods

    public static OpCode GetOpCode(byte code) => _codes[(ByteCode)code];

    internal static OpCode GetOpCode(ByteCode code) => _codes[code];

    #endregion

}
