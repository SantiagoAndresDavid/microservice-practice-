using API.Entities;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Context;

public class AppDBContext: DbContext, IAppDBContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       
        optionsBuilder.UseSqlServer(@"Server=172.19.0.2,1433;Database=API;user id=sa;password=<YourStrong@Passw0rd>;Persist Security Info=False;Encrypt=False;TrustServerCertificate=True;");
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return base.SaveChangesAsync(cancellationToken);
        
    }
}
