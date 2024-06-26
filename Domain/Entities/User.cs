﻿using Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    
    [BsonElement("Username")]
    public string Username { get; set; }
    
    [BsonElement("SignInInfo")]
    public SignInInfo SignInInfo { get; set; }
    
    [BsonElement("Nickname")]
    public string Nickname { get; set; }
    
    [BsonElement("Race")]
    public string Race { get; set; }
    
    [BsonElement("Team")]
    public Team? Team { get; set; }
    
    [BsonElement("Role")]
    public Roles Role { get; set; }

    [BsonElement("Invites")] 
    public List<TeamInvite>? Invites { get; set; } = new List<TeamInvite>();

    [BsonElement("DuelInvites")]
    public List<DuelInvite>? DuelInvites { get; set; } = new List<DuelInvite>();
    
    [BsonElement("CurrentDuel")]
    public Duel? CurrentDuel { get; set; }
}