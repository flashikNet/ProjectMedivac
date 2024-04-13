using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class SignInReq
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
