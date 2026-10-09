using Microsoft.EntityFrameworkCore;
using GameHubApi.Models;
namespace GameHubApi.Data;

public class GameHubDbContext : DbContext
{
    public GameHubDbContext(
        DbContextOptions<GameHubDbContext> options)
        : base(options)
    {
    }

    public DbSet<Account> Account { get; set; }
}
