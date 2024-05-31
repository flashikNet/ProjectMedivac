using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

public class Duel
{
    public Guid Id { get; set; }

    [BsonElement("StartTime")] 
    public DateTime StartTime { get; set; } = DateTime.Now;
    
    [BsonElement("TeamA")]
    public Team TeamA { get; set; }
    
    [BsonElement("TeamB")]
    public Team TeamB { get; set; }
    
    [BsonElement("TeamAScore")]
    public int TeamAScore { get; set; }
    
    [BsonElement("TeamBScore")]
    public int TeamBScore { get; set; }
    
    [BsonElement("TeamALineup")]
    public List<User> TeamALineup { get; set; } = new List<User>();

    [BsonElement("TeamBLineup")] 
    public List<User> TeamBLineup { get; set; } = new List<User>();
}