using BusinessDomain;

namespace Persistence
{
  public class StartDataProvider
  {
    private AnimalsContext db { get; set; }

    public StartDataProvider(AnimalsContext db)
    {
      this.db = db;
    }

    public void Provide()
    {
      db.Database.EnsureCreated();

      if (db.Commands.Any()) return;

      Command command1 = new Command
      {
        Name = "Сидеть!"
      };

      Command command2 = new Command
      {
        Name = "Но, Пошла!"
      };

      Command command3 = new Command
      {
        Name = "Замри!"
      };

      Command command4 = new Command
      {
        Name = "Лапу!"
      };

      Command command5 = new Command
      {
        Name = "Сюда!"
      };

      Cat cat = new Cat
      {
        Name = "Барсик",
        Birthday = new DateOnly(2010, 10, 20)
      };
      cat.Commands.Add(command4);

      Dog dog = new Dog
      {
        Name = "Рекс",
        Birthday = new DateOnly(2012, 5, 12)
      };
      dog.Commands.Add(command1);

      Hamster hamster = new Hamster
      {
        Name = "Хома",
        Birthday = new DateOnly(2020, 8, 27)
      };
      hamster.Commands.Add(command3);

      Donkey donkey = new Donkey
      {
        Name = "Альтаир",
        Birthday = new DateOnly(2008, 4, 14)
      };
      donkey.Commands.Add(command5);

      Horse horse = new Horse
      {
        Name = "Победа",
        Birthday = new DateOnly(2012, 2, 17)
      };
      horse.Commands.Add(command2);

      db.Cats.Add(cat);
      db.Dogs.Add(dog);
      db.Hamsters.Add(hamster);
      db.Donkeys.Add(donkey);
      db.Horses.Add(horse);

      db.SaveChanges();

    }
  }
}