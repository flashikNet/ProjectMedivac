using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Data;

public class SerializerConfig
{
    static SerializerConfig()
    {
        BsonSerializer.RegisterSerializer(typeof(Guid), new GuidSerializer(BsonType.String));
    }

    public static void RegisterSerializers()
    {
    }
}