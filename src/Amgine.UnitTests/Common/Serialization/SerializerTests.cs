using Amgine.Common.Serialization;
using Amgine.Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Linq;
using JsonSerializer = Amgine.Common.Serialization.JsonSerializer;

namespace Amgine.UnitTests.Common.Serialization;

public class SerializerTests
{
    private JsonSerializer _jsonSerializer = null!;
    private BsonSerializer _bsonSerializer = null!;

    private readonly AmgineFileHeader _dummyAmgineHeader = new()
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
    public void Test_Amgine_File_Header()
    {
        // When
        var jsonResult = _jsonSerializer.SerializeObject(_dummyAmgineHeader);
        var bsonResult = _bsonSerializer.SerializeObject(_dummyAmgineHeader);

        // Then
        var deserializedJson = _jsonSerializer.DeserializeObject<AmgineFileHeader>(jsonResult);
        var deserializedBson = _bsonSerializer.DeserializeObject<AmgineFileHeader>(bsonResult.ToArray());

        Assert.AreEqual(_dummyAmgineHeader, deserializedJson);
        Assert.AreEqual(_dummyAmgineHeader, deserializedBson);
    }

    [Test]
    public void Test_Amgine_File_With_Header()
    {
        // Given
        var amgineFile = new AmgineFile(_dummyAmgineHeader, new byte[] { 0xDE, 0xAD, 0xBE, 0xEF });

        // When
        var jsonResult = _jsonSerializer.SerializeObject(amgineFile);
        var bsonResult = _bsonSerializer.SerializeObject(amgineFile);

        // Then
        var deserializedJson = _jsonSerializer.DeserializeObject<AmgineFile>(jsonResult);
        var deserializedBson = _bsonSerializer.DeserializeObject<AmgineFile>(bsonResult.ToArray());

        Assert.AreEqual(amgineFile, deserializedJson);
        Assert.AreEqual(amgineFile, deserializedBson);
    }

    [Test]
    public void Test_Amgine_File_Without_Header()
    {
        // Given
        var amgineFile = new AmgineFile(null!, new byte[] { 0xDE, 0xAD, 0xBE, 0xEF });

        // When
        var jsonResult = _jsonSerializer.SerializeObject(amgineFile);
        var bsonResult = _bsonSerializer.SerializeObject(amgineFile);

        // Then
        var deserializedJson = _jsonSerializer.DeserializeObject<AmgineFile>(jsonResult);
        var deserializedBson = _bsonSerializer.DeserializeObject<AmgineFile>(bsonResult.ToArray());

        Assert.AreEqual(amgineFile, deserializedJson);
        Assert.AreEqual(amgineFile, deserializedBson);
    }
}