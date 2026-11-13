using Microsoft.AspNetCore.Identity;

namespace OtakuStoreAPI.Models;

public class AppUser : IdentityUser
{
    public string? Address {get;set;}
    
}