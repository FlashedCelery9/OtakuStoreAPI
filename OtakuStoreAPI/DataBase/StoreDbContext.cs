using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OtakuStoreAPI.Models;

namespace OtakuStoreAPI.DataBase;

public class StoreDbContext : IdentityDbContext<AppUser> 
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
}