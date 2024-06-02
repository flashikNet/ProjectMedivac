using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

public class Team
{
    public Guid Id { get; set; }
    
    [BsonElement("TeamName")]
    public string TeamName { get; set; }

    [BsonElement("Members")] 
    public List<User>? Members { get; set; } = new List<User>();
}