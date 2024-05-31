using Domain.Entities;
using Domain.Enums;

namespace Domain.Extensions;

public static class UserExtensions
{
    public static bool IsValid(this User user)
    {
        return !string.IsNullOrEmpty(user.Username) &&
               !string.IsNullOrEmpty(user.Nickname) && user.SignInInfo != null &&
               !string.IsNullOrEmpty(user.SignInInfo.Email) &&
               !string.IsNullOrEmpty(user.SignInInfo.Password) &&
               Enum.IsDefined(typeof(Races), user.Race);
    }
}