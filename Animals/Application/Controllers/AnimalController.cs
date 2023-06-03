using BusinessDomain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Controllers
{
  public class AnimalController
  {
    private AnimalsContext db;
    public AnimalController(AnimalsContext db)
    {
      this.db = db;
    }

    public List<Command> GetAllCommands()
    {
      return db.Commands.ToList();
    }

    public void AddCommand(string? name)
    {
      Command command = new Command
      {
        Name = name
      };
      db.Commands.Add(command);
      db.SaveChanges();
    }
    public List<IAnimal> GetAllAnimals()
    {
      List<IAnimal> animals = new();
      animals.AddRange(db.Cats.Include(c => c.Commands).ToList());
      animals.AddRange(db.Dogs.Include(c => c.Commands).ToList());
      animals.AddRange(db.Hamsters.Include(c => c.Commands).ToList());
      animals.AddRange(db.Horses.Include(c => c.Commands).ToList());
      animals.AddRange(db.Donkeys.Include(c => c.Commands).ToList());
      return animals;
    }

    public void AddAnimal(string type, string? name, DateOnly birthday)
    {
      IAnimal animal;
      switch (type)
      {
        case "cat":
          animal = new Cat
          {
            Name = name,
            Birthday = birthday
          };
          db.Cats.Add((Cat)animal);
          break;
        case "dog":
          animal = new Dog
          {
            Name = name,
            Birthday = birthday
          };
          db.Dogs.Add((Dog)animal);
          break;
        case "hamster":
          animal = new Hamster
          {
            Name = name,
            Birthday = birthday
          };
          db.Hamsters.Add((Hamster)animal);
          break;
        case "horse":
          animal = new Horse
          {
            Name = name,
            Birthday = birthday
          };
          db.Horses.Add((Horse)animal);
          break;
        case "donkey":
          animal = new Donkey
          {
            Name = name,
            Birthday = birthday
          };
          db.Donkeys.Add((Donkey)animal);
          break;
      }
      db.SaveChanges();
    }

    public IAnimal? FindByName(string name)
    {
      if (!(db.Cats.Find(name) is null))
      {
        return db.Cats.Find(name);
      }
      if (!(db.Dogs.Find(name) is null))
      {
        return db.Dogs.Find(name);
      }
      if (!(db.Hamsters.Find(name) is null))
      {
        return db.Hamsters.Find(name);
      }
      if (!(db.Horses.Find(name) is null))
      {
        return db.Horses.Find(name);
      }
      if (!(db.Donkeys.Find(name) is null))
      {
        return db.Donkeys.Find(name);
      }
      return null;
    }
    public void LearnNewCommand(string name, string commandName)
    {
      FindByName(name).Commands.Add(new Command { Name = commandName });
      db.SaveChanges();
    }

    public List<Command> GetAnimalCommands(string name) =>
      FindByName(name).Commands.ToList();

  }
}
