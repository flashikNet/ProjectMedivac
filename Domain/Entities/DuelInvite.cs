using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

public class DuelInvite
{
    public Guid Id { get; set; }
    
    [BsonElement("TeamId")]
    public Guid TeamId { get; set; }

    [BsonElement("InvitedBy")]
    public Guid InvitedBy { get; set; }

    [BsonElement("InviteDate")]
    public DateTime InviteDate { get; set; }
    
    [BsonElement("Accepted")]
    public bool Accepted { get; set; }
}