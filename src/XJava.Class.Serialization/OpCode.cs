namespace XJava.Class.Serialization;

/// <summary>
/// Represents an opcode
/// </summary>
/// <param name="Mnemonic">Text representing the opcode</param>
/// <param name="Code">Byte value of the opcode</param>
/// <param name="ArgsLength">Number of bytes for the arguments or -1 if its variable</param>
public record OpCode(string Mnemonic, byte Code, sbyte ArgsLength = 0, string Description = "");
