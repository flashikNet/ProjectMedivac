using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

public class TeamInvite
{
    public Guid Id { get; set; }
    
    [BsonElement("InviteFrom")]
    public Team TeamInviter { get; set; }
    
    [BsonElement("RecipientUser")]
    public User RecipientUser { get; set; }
    
    [BsonElement("Pending")]
    public bool Pending { get; set; }
    
    [BsonElement("Accepted")]
    public bool Accepted { get; set; }
}