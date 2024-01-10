using MightyXOR.Core.SecretSharing.Shamir;
using NUnit.Framework;

namespace MightyXOR.UnitTests.Core.SecretSharing
{
    internal class FieldTests
    {
        [Test]
        public void Test_Explicit_Casting()
        {
            // Given
            const byte sampleByte = 0x42;

            // When
            var field = new Field(sampleByte);

            // Then
            Assert.AreEqual(sampleByte, (byte)field);
            Assert.AreEqual(field, (Field)sampleByte);
        }

        [Test]
        public void Test_Plus_Operator()
        {
            // Given
            byte a = 0x42, b = 0x20;
            var fieldA = new Field(a);
            var fieldB = new Field(b);

            // When
            byte result = (byte)(fieldA + fieldB);

            // Then
            Assert.AreEqual((byte)(a ^ b), result);
        }

        [Test]
        public void Test_Minus_Operator()
        {
            // Given
            byte a = 0x42, b = 0x20;
            var fieldA = new Field(a);
            var fieldB = new Field(b);

            // When
            byte result = (byte)(fieldA - fieldB);

            // Then
            Assert.AreEqual((byte)(a ^ b), result);
        }

        [Test]
        public void Test_Multiplication_Operator()
        {
            // Given
            byte a = 128, b = 3;
            var fieldA = new Field(a);
            var fieldB = new Field(b);

            // When
            byte result = (byte)(fieldA * fieldB);
            byte expectedResult = 157; // https://hp.vector.co.jp/authors/VA021385/galois_calc.htm

            // Then
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Test_Division_Operator()
        {
            // Given
            byte a = 128, b = 3;
            var fieldA = new Field(a);
            var fieldB = new Field(b);

            // When
            byte result = (byte)(fieldA / fieldB);
            byte expectedResult = 139; // https://hp.vector.co.jp/authors/VA021385/galois_calc.htm

            // Then
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Test_Power_Operator()
        {
            // Given
            byte a = 128;
            byte exponent = 3;
            var fieldA = new Field(a);

            // When
            byte result = (byte)(Field.Pow(fieldA, exponent));
            byte expectedResult = 117; // https://hp.vector.co.jp/authors/VA021385/galois_calc.htm

            // Then
            Assert.AreEqual(expectedResult, result);
        }
    }
}