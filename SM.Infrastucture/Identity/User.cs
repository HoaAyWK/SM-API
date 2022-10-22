using Microsoft.AspNetCore.Identity;

namespace SM.Infrastructure.Indentity;

public class User : IdentityUser
{
    public string? Avatar { get; private set; }
}