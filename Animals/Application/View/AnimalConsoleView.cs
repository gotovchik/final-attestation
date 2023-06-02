using Application.Controllers;
using BusinessDomain;
using Persistence;

namespace Application.View
{
  public class AnimalConsoleView
  {
    private AnimalController Controller { get; set; }

    public AnimalConsoleView(AnimalsContext db)
    {
      Controller = new AnimalController(db);
    }

    public void ShowAllAnimals()
    {
      List<IAnimal> animals = Controller.GetAllAnimals();
      foreach (var animal in animals)
      {
        Console.WriteLine("{0}|{1}", animal.Name, animal.Birthday);
        Console.WriteLine($"\tВыученные команды:");

        foreach (var command in animal.Commands)
        {
          Console.WriteLine($"\t{command.Name}");
        }

      }
    }

    public void AddAnimal()
    {
      Console.WriteLine("Какое животное хотите добавить?\n\t1.Кошка\n\t2.Собака\n\t3.Хомяк\n\t4.Лошадь\n\t5.Осел");
      ConsoleKeyInfo key = Console.ReadKey();
      string? animal;
      char keyChar = key.KeyChar;
      switch (keyChar)
      {
        case '1':
          animal = "cat";
          break;
        case '2':
          animal = "dog";
          break;
        case '3':
          animal = "hamster";
          break;
        case '4':
          animal = "horse";
          break;
        default:
          animal = "donkey";
          break;
      }
      Console.WriteLine("Введите кличку животного:");
      string? name = Console.ReadLine();
      while (name == String.Empty)
      {
        Console.WriteLine("Недопускается пустое значение. Введите кличку!");
        name = Console.ReadLine();
      }
      Console.WriteLine("Введите дату рождения в формате dd/MM/yyyy: ");
      string? line = Console.ReadLine();
      DateTime dt;
      while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
      {
        Console.WriteLine($"Неправильно написана дата, попробуйте еще раз!");
        line = Console.ReadLine();
      }
      DateOnly birthday = DateOnly.FromDateTime(dt);
      Controller.AddAnimal(animal, name, birthday);



    }
  }
}