using MightyXOR.Common.Serialization;
using MightyXOR.Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Linq;
using JsonSerializer = MightyXOR.Common.Serialization.JsonSerializer;

namespace MightyXOR.UnitTests.Common.Serialization;

public class SerializerTests
{
    private JsonSerializer _jsonSerializer = null!;
    private BsonSerializer _bsonSerializer = null!;

    private readonly MightyXorFileHeader _dummyMightyXorHeader = new()
    {
        Name = "Test",
        Extension = ".txt",
        Length = 42,
        CreationTime = DateTime.Now,
        CreationTimeUtc = DateTime.UtcNow,
        LastAccessTime = DateTime.Now,
        LastAccessTimeUtc = DateTime.UtcNow,
        LastWriteTime = DateTime.Now,
        LastWriteTimeUtc = DateTime.UtcNow,
        ReadOnly = true,
        Md5Hash = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF, 0xAA, 0xBB, 0xCC, 0xDD }
    };

    [SetUp]
    public void Setup()
    {
        var defaultSettings = new JsonSerializerSettings();
        _jsonSerializer = new JsonSerializer(defaultSettings);
        _bsonSerializer = new BsonSerializer(defaultSettings);
    }

    [Test]
    public void Test_Empty_Array()
    {
        // Given
        var emptyArray = Array.Empty<int>();

        // When
        var jsonResult = _jsonSerializer.SerializeObject(emptyArray);

        // Then
        const string expectedJson = @"[]";
        Assert.AreEqual(expectedJson, jsonResult);
        Assert.AreEqual(emptyArray, _jsonSerializer.DeserializeObject<int[]>(jsonResult));
    }

    [Test]
    public void Test_Integer_Array()
    {
        // Given
        var emptyArray = new[] { 3, 1, 4, 1, 5, 9 };

        // When
        var result = _jsonSerializer.SerializeObject(emptyArray);

        // Then
        const string expectedJson = @"[3,1,4,1,5,9]";
        Assert.AreEqual(expectedJson, result);
        Assert.AreEqual(emptyArray, _jsonSerializer.DeserializeObject<int[]>(result));
    }

    [Test]
    public void Test_MightyXOR_File_Header()
    {
        // When
        var jsonResult = _jsonSerializer.SerializeObject(_dummyMightyXorHeader);
        var bsonResult = _bsonSerializer.SerializeObject(_dummyMightyXorHeader);

        // Then
        var deserializedJson = _jsonSerializer.DeserializeObject<MightyXorFileHeader>(jsonResult);
        var deserializedBson = _bsonSerializer.DeserializeObject<MightyXorFileHeader>(bsonResult.ToArray());

        Assert.AreEqual(_dummyMightyXorHeader, deserializedJson);
        Assert.AreEqual(_dummyMightyXorHeader, deserializedBson);
    }

    [Test]
    public void Test_MightyXOR_File_With_Header()
    {
        // Given
        var mightyXorFile = new MightyXorFile(_dummyMightyXorHeader, new byte[] { 0xDE, 0xAD, 0xBE, 0xEF });

        // When
        var jsonResult = _jsonSerializer.SerializeObject(mightyXorFile);
        var bsonResult = _bsonSerializer.SerializeObject(mightyXorFile);

        // Then
        var deserializedJson = _jsonSerializer.DeserializeObject<MightyXorFile>(jsonResult);
        var deserializedBson = _bsonSerializer.DeserializeObject<MightyXorFile>(bsonResult.ToArray());

        Assert.AreEqual(mightyXorFile, deserializedJson);
        Assert.AreEqual(mightyXorFile, deserializedBson);
    }

    [Test]
    public void Test_MightyXOR_File_Without_Header()
    {
        // Given
        var mightyXorFile = new MightyXorFile(null!, new byte[] { 0xDE, 0xAD, 0xBE, 0xEF });

        // When
        var jsonResult = _jsonSerializer.SerializeObject(mightyXorFile);
        var bsonResult = _bsonSerializer.SerializeObject(mightyXorFile);

        // Then
        var deserializedJson = _jsonSerializer.DeserializeObject<MightyXorFile>(jsonResult);
        var deserializedBson = _bsonSerializer.DeserializeObject<MightyXorFile>(bsonResult.ToArray());

        Assert.AreEqual(mightyXorFile, deserializedJson);
        Assert.AreEqual(mightyXorFile, deserializedBson);
    }
}