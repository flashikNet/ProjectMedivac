﻿using Domain.Enums;

namespace Domain.Entities
{
    public class User : EntityBase
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string BattleNetAccount { get; set; }
        public required string Password { get; set; }
        public string Status { get; set; } = "";
        public required Roles Role { get; set; }
        public required Races Race { get; set; }
        public required uint MMR {  get; set; }
        public Team? Team { get; set; }

    }
}
