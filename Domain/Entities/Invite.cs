namespace Domain.Entities
{
    public class Invite : EntityBase
    {
        public User Inviter {  get; set; }
        public User Invited { get; set; }
        public string Content { get; set; }
    }
}
