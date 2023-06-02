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
  }
}
