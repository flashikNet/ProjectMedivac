namespace Domain.Entities
{
    public class Team
    {
        public uint Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; } = "";
        public List<User> Users { get; set; } = new();
    }
}
