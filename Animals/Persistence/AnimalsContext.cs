using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessDomain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class AnimalsContext : DbContext
  {
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<Hamster> Hamsters { get; set; }
    public DbSet<Donkey> Donkeys { get; set; }
    public DbSet<Horse> Horses { get; set; }
    public DbSet<Command> Commands { get; set; }

    public AnimalsContext(DbContextOptions<AnimalsContext> opt) : base(opt)
    {

    }
  }
}