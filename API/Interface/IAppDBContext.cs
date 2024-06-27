using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Interface;

public interface IAppDBContext
{
    DbSet<Category> Categories { get; set; }
    DbSet<Post> Posts { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}