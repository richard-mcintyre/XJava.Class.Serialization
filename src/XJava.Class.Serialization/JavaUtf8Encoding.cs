using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization
{
    public class JavaUtf8Encoding : Encoding
    {
        public override int GetByteCount(char[] chars, int index, int count)
        {
            int result = 0;

            for (int i = 0; i < count; i++)
            {
                int codepoint;

                char ch = chars[index + i];
                if (Char.IsHighSurrogate(ch))
                {
                    codepoint = Char.ConvertToUtf32(ch, chars[index + 1]);
                    i++;
                }
                else
                {
                    codepoint = ch;
                }

                if (codepoint > 0xffff)
                    result += 6;
                else if (codepoint >= 0x0800 && codepoint <= 0xffff)
                    result += 3;
                else if (codepoint == 0x0000 || (codepoint >= 0x0080 && codepoint <= 0x07FF))
                    result += 2;
                else
                    result++;
            }

            return result;
        }

        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            for (int i = 0; i < charCount; i++)
            {
                int codepoint;

                char ch = chars[charIndex + i];
                if (Char.IsHighSurrogate(ch))
                {
                    codepoint = Char.ConvertToUtf32(ch, chars[charIndex + 1]);
                    i++;
                }
                else
                {
                    codepoint = ch;
                }

                if (codepoint > 0xffff)
                {
                    codepoint -= 0x10000;

                    ushort high = (ushort)((codepoint >> 10) & 0b11_1111_1111);
                    ushort low = (ushort)(codepoint & 0b11_1111_1111);

                    bytes[byteIndex] = 0b1110_1101;
                    bytes[byteIndex + 1] = (byte)(0b1010_0000 | ((high >> 6) & 0b0000_1111));
                    bytes[byteIndex + 2] = (byte)(0b1000_0000 | (high & 0b0011_1111));
                    bytes[byteIndex + 3] = 0b1110_1101;
                    bytes[byteIndex + 4] = (byte)(0b1011_0000 | ((low >> 6) & 0b0000_1111));
                    bytes[byteIndex + 5] = (byte)(0b1000_0000 | (low & 0b0011_1111));
                    byteIndex += 6;
                }
                else if (codepoint >= 0x0800 && codepoint <= 0xffff)
                {
                    bytes[byteIndex] = (byte)(0b1110_0000 | ((codepoint >> 12) & 0b0000_1111));
                    bytes[byteIndex + 1] = (byte)(0b1000_0000 | ((codepoint >> 6) & 0b0011_1111));
                    bytes[byteIndex + 2] = (byte)(0b1000_0000 | (codepoint & 0b0011_1111));
                    byteIndex += 3;
                }
                else if (codepoint == 0x0000 || (codepoint >= 0x0080 && codepoint <= 0x07FF))
                {
                    bytes[byteIndex] = (byte)(0b1100_0000 | (codepoint >> 6));
                    bytes[byteIndex + 1] = (byte)(0b1000_0000 | (codepoint & 0b0011_1111));
                    byteIndex += 2;
                }
                else
                {
                    bytes[byteIndex] = (byte)codepoint;
                    byteIndex++;
                }
            }

            return byteIndex;
        }

        public override int GetCharCount(byte[] bytes, int index, int count)
        {
            int result = 0;

            for (int i = index; i < index + count; i++)
            {
                // Code points above \uffff are represented by separately encoding the two surrogate code units of their UTF-16 representation
                // Each of the surrogate code uits is represented by 3 bytes
                if (i + 5 <= index + count &&
                        bytes[i] == 0b1110_1101 && (bytes[i + 1] & 0b1111_0000) == 0b1010_0000 && (bytes[i + 2] & 0b1100_0000) == 0b1000_0000 &&
                        bytes[i + 3] == 0b1110_1101 && (bytes[i + 4] & 0b1111_0000) == 0b1011_0000 && (bytes[i + 5] & 0b1100_0000) == 0b1000_0000)
                {
                    result += 2;
                    i += 5;
                }
                // Code points in the range \u0800 to \uffff are represented by 3 bytes
                else if (i + 2 < index + count &&
                         (bytes[i] & 0b1111_0000) == 0b1110_0000 &&
                         (bytes[i + 1] & 0b1100_0000) == 0b1000_0000 &&
                         (bytes[i + 2] & 0b1100_0000) == 0b1000_0000)
                {
                    result++;
                    i += 2;
                }
                // The null code point (\u0000) and code points in the range \u0080 to \u07FF are represented by a pair of bytes
                else if (i + 1 < index + count &&
                         (bytes[i] & 0b1110_0000) == 0b1100_0000 &&
                         (bytes[i + 1] & 0b1100_0000) == 0b1000_0000)
                {
                    result++;
                    i++;
                }
                // Code points in the range of \u0001 to \u007f are represented by a single byte
                else if ((bytes[i] & 0b1000_0000) == 0)
                {
                    result++;
                }
                else
                    throw new NotImplementedException();
            }

            return result;
        }

        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            for (int i = byteIndex; i < byteIndex + byteCount; i++)
            {
                // Code points above \uffff are represented by separately encoding the two surrogate code units of their UTF-16 representation
                // Each of the surrogate code uits is represented by 3 bytes
                if (i + 5 <= byteIndex + byteCount &&
                        bytes[i] == 0b1110_1101 && (bytes[i + 1] & 0b1111_0000) == 0b1010_0000 && (bytes[i + 2] & 0b1100_0000) == 0b1000_0000 &&
                        bytes[i + 3] == 0b1110_1101 && (bytes[i + 4] & 0b1111_0000) == 0b1011_0000 && (bytes[i + 5] & 0b1100_0000) == 0b1000_0000)
                {
                    byte v = (byte)(bytes[i + 1] & 0b0000_1111);
                    byte w = (byte)(bytes[i + 2] & 0b0011_1111);

                    byte y = (byte)(bytes[i + 4] & 0b0000_1111);
                    byte z = (byte)(bytes[i + 5] & 0b0011_1111);
                    i += 5;

                    int high = (v << 6) | w;
                    high += 0xd800;

                    int low = (y << 6) | z;
                    low += 0xdc00;

                    int codepoint = Char.ConvertToUtf32((char)high, (char)low);
                    chars[charIndex] = Char.ConvertFromUtf32(codepoint)[0];
                    chars[charIndex + 1] = Char.ConvertFromUtf32(codepoint)[1];
                    charIndex += 2;
                }
                // Code points in the range \u0800 to \uffff are represented by 3 bytes
                else if (i + 2 < byteIndex + byteCount &&
                         (bytes[i] & 0b1111_0000) == 0b1110_0000 &&
                         (bytes[i + 1] & 0b1100_0000) == 0b1000_0000 &&
                         (bytes[i + 2] & 0b1100_0000) == 0b1000_0000)
                {
                    byte x = bytes[i];
                    byte y = bytes[i + 1];
                    byte z = bytes[i + 2];
                    i += 2;

                    int codepoint = ((x & 0b0000_1111) << 12) + ((y & 0b0011_1111) << 6) + (z & 0b0011_1111);
                    chars[charIndex] = Char.ConvertFromUtf32(codepoint)[0];
                    charIndex++;
                }
                // The null code point (\u0000) and code points in the range \u0080 to \u07FF are represented by a pair of bytes
                else if (i + 1 < byteIndex + byteCount &&
                         (bytes[i] & 0b1110_0000) == 0b1100_0000 &&
                         (bytes[i + 1] & 0b1100_0000) == 0b1000_0000)
                {
                    byte x = bytes[i];
                    byte y = bytes[i + 1];
                    i++;

                    chars[charIndex] = Char.ConvertFromUtf32(((x & 0b0001_1111) << 6) + (y & 0b0011_1111))[0];
                    charIndex++;
                }
                // Code points in the range of \u0001 to \u007f are represented by a single byte
                else if ((bytes[i] & 0b1000_0000) == 0)
                {
                    chars[charIndex] = Char.ConvertFromUtf32(bytes[i])[0];
                    charIndex++;
                }
                else
                    throw new NotImplementedException();
            }

            return charIndex;
        }

        public override int GetMaxByteCount(int charCount) => charCount * 6;

        public override int GetMaxCharCount(int byteCount) => byteCount;
    }
}
