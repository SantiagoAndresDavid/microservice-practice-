using API.Entities;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Context;

public class AppDBContext: DbContext, IAppDBContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=API;User Id=sa;Password=<YourStrong@Passw0rd>;TrustServerCertificate=True");
    }
}
