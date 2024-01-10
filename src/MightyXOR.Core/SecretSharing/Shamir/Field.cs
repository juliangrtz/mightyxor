namespace MightyXOR.Core.SecretSharing.Shamir;

/// <summary>
/// A class representation of a 2^8 (256) Galois field.
/// Adapted from <see href="https://github.com/fauzanhilmi/GaloisField"></see>
/// </summary>
public class Field
{
    private readonly byte _value;

    // Irreducible polynomial
    // x^8 + x^4 + x^3 + x^2 + 1
    // 0x11 == 1011
    private const int Polynomial = 0x11D;

    // Variables used in Exp and Log table generation
    private const byte Generator = 0x2;

    public const int Order = 256;

    private static readonly byte[] Exp;
    private static readonly byte[] Log;

    public Field(byte value)
    {
        _value = value;
    }

    // Generates Exp and Log table for faster multiplication
    static Field()
    {
        Exp = new byte[Order];
        Log = new byte[Order];

        byte val = 0x01;
        for (var i = 0; i < Order; i++)
        {
            Exp[i] = val;
            if (i < Order - 1)
            {
                Log[val] = (byte)i;
            }
            val = Multiply(Generator, val);
        }
    }

    // Russian peasant multiplication
    private static byte Multiply(byte a, byte b)
    {
        byte result = 0;

        while (b != 0)
        {
            if ((b & 1) != 0)
            {
                result ^= a;
            }

            var highestBit = (byte)(a & 0x80);
            a <<= 1;

            if (highestBit != 0)
            {
                a ^= Polynomial & 0xFF;
            }

            b >>= 1;
        }

        return result;
    }

    /*
     * (Algebraic) operators
     */

    public static explicit operator Field(byte b)
        => new(b);

    public static explicit operator byte(Field field)
        => field._value;

    public static Field operator +(Field fieldA, Field fieldB)
    {
        var result = (byte)(fieldA._value ^ fieldB._value);
        return new Field(result);
    }

    public static Field operator -(Field fieldA, Field fieldB)
    {
        var bres = (byte)(fieldA._value ^ fieldB._value);
        return new Field(bres);
    }

    public static Field operator *(Field fieldA, Field fieldB)
    {
        Field result = new(0);

        if (fieldA._value != 0 && fieldB._value != 0)
        {
            var bResult = (byte)((Log[fieldA._value] + Log[fieldB._value]) % (Order - 1));
            bResult = Exp[bResult];
            result = new Field(bResult);
        }

        return result;
    }

    public static Field operator /(Field fieldA, Field fieldB)
    {
        if (fieldB._value == 0)
        {
            throw new ArgumentException("Divisor cannot be 0", nameof(fieldB));
        }

        var result = new Field(0);
        if (fieldA._value != 0)
        {
            var bResult = (byte)((Order - 1 + Log[fieldA._value] - Log[fieldB._value]) % (Order - 1));
            bResult = Exp[bResult];
            result = new Field(bResult);
        }

        return result;
    }

    public static bool operator ==(Field fieldA, Field fieldB)
        => fieldA._value == fieldB._value;

    public static bool operator !=(Field fieldA, Field fieldB)
        => fieldA._value != fieldB._value;

    public static Field Pow(Field field, byte exponent)
    {
        var result = new Field(1);

        for (byte i = 0; i < exponent; i++)
        {
            result *= field;
        }

        return result;
    }

    private bool Equals(Field other) => _value == other._value;

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Field)obj);
    }

    public override int GetHashCode() => _value.GetHashCode();

    public override string ToString() => _value.ToString();
}