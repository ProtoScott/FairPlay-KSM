using System;

namespace Protostream.Support.Throws
{
    sealed internal class ArgumentThrow
    {
        internal static void IfNull(Func<object> creator, string message, string paramName)
        {
            object obj = null;
            if (creator != null) obj = creator();   
            if (obj == null) throw new ArgumentNullException(paramName, message);
        }

        internal static void IfNull(object obj, string message, string paramName)
        {
            if (obj == null) throw new ArgumentNullException(paramName, message);
        }
        
        internal static void IfLackingBytes(ReadOnlyMemory<byte> buffer, int size, string message, string paramName)
        {
            if (size < 0) throw new ArgumentOutOfRangeException("Invalid size length. ¿Integer overflow?", nameof(size));
            if (buffer.Length < 0) throw new ArgumentOutOfRangeException("Invalid size length. ¿Integer overflow?", nameof(buffer.Length));
            if (buffer.Length < size) throw new ArgumentException(message, paramName);
        }
        
        internal static void IfLackingBytes(byte[] buffer, int size, string message, string paramName)
        {
            if (buffer == null) throw new ArgumentNullException(message, paramName);
            if (size < 0) throw new ArgumentOutOfRangeException("Invalid size length. ¿Integer overflow?", nameof(size));
            if (buffer.Length < 0) throw new ArgumentOutOfRangeException("Invalid size length. ¿Integer overflow?", nameof(buffer.Length));
            if (buffer.Length < size) throw new ArgumentException(message, paramName);
        }
        
        internal static void IfTooMuchBytes(ReadOnlyMemory<byte> buffer, int size, string message, string paramName)
        {
            if (size < 0) throw new ArgumentOutOfRangeException("Invalid size length. ¿Integer overflow?", nameof(size));
            if (buffer.Length < 0) throw new ArgumentOutOfRangeException("Invalid size length. ¿Integer overflow?", nameof(buffer.Length));
            if (buffer.Length > size) throw new ArgumentException(message, paramName);
        }
        
        internal static void IfLengthNot(ReadOnlyMemory<byte> buffer, int size, string message, string paramName)
        {
            if (size < 0) throw new ArgumentOutOfRangeException("Invalid size length. ¿Integer overflow?", nameof(size));
            if (buffer.Length < 0) throw new ArgumentOutOfRangeException("Invalid size length. ¿Integer overflow?", nameof(buffer.Length));
            if (buffer.Length != size) throw new ArgumentException(message, paramName);
        }
        
        internal static void IfLengthNot(byte[] buffer, int size, string message, string paramName)
        {
            if (buffer == null) throw new ArgumentNullException(message, paramName);
            if (size < 0) throw new ArgumentOutOfRangeException("Invalid size length. ¿Integer overflow?", nameof(size));
            if (buffer.Length < 0) throw new ArgumentOutOfRangeException("Invalid size length. ¿Integer overflow?", nameof(buffer.Length));
            if (buffer.Length != size) throw new ArgumentException(message, paramName);
        }
        
        internal static void IfLengthNotMultiple(ReadOnlyMemory<byte> buffer, int multiple, string message, string paramName)
        {
            if (multiple < 1) throw new ArgumentOutOfRangeException("Invalid size length. ¿Integer overflow?", nameof(multiple));
            if (buffer.Length < 0) throw new ArgumentOutOfRangeException("Invalid size length. ¿Integer overflow?", nameof(buffer.Length));
            if (buffer.Length % multiple != 0) throw new ArgumentException(message, paramName);
        }
        
        internal static void IfLengthNotMultiple(byte[] buffer, int multiple, string message, string paramName)
        {
            if (buffer == null) throw new ArgumentNullException(message, paramName);
            if (multiple < 1) throw new ArgumentOutOfRangeException("Invalid size length. ¿Integer overflow?", nameof(multiple));
            if (buffer.Length < 0) throw new ArgumentOutOfRangeException("Invalid size length. ¿Integer overflow?", nameof(buffer.Length));
            if (buffer.Length % multiple != 0) throw new ArgumentException(message, paramName);
        }
    }
}
