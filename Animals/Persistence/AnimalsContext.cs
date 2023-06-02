using BusinessDomain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class AnimalsContext : DbContext
  {
    public DbSet<Cat> Cats { get; set; } = null!;
    public DbSet<Dog> Dogs { get; set; } = null!;
    public DbSet<Hamster> Hamsters { get; set; } = null!;
    public DbSet<Donkey> Donkeys { get; set; } = null!;
    public DbSet<Horse> Horses { get; set; } = null!;
    public DbSet<Command> Commands { get; set; } = null!;

    public AnimalsContext(DbContextOptions<AnimalsContext> opt) : base(opt)
    {

    }
  }
}