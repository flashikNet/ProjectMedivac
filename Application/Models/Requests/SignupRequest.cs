using System.Text.Json.Serialization;
using Domain.Enums;

namespace Application.Models.Requests;

public class SignupRequest
{
    public string Username { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Race { get; set; }
}