using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

public class SignInInfo
{
    [BsonElement("Email")]
    public string Email { get; set; }
    
    [BsonElement("Password")]
    public string Password { get; set; }
}