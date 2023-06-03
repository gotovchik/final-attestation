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

    public void ShowAllCommands()
    {
      List<Command> commands = Controller.GetAllCommands();
      Console.WriteLine($"Все команды, изучаемые в реестре:");

      foreach (Command command in commands)
      {
        Console.WriteLine($"\t{command.Name}");
      }
    }

    public void AddCommand()
    {
      Console.WriteLine($"Введите название команды, которую хотели бы добавить для изучения:");
      string? name = Console.ReadLine();
      Controller.AddCommand(name);
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

    public void LearnNewCommand()
    {
      Console.WriteLine($"Введите кличку животного, которого обучили новой команде:");
      string? name = Console.ReadLine();
      while (name == String.Empty || Controller.FindByName(name) is null)
      {
        Console.WriteLine("Животного с такой кличкой нет в реестре. Проверьте, правильно ли вы вводите кличку и попробуйте еще раз!");
        name = Console.ReadLine();
      }
      Console.WriteLine($"Введите команду, которую выучило животное:");
      string? commandName = Console.ReadLine();
      while (commandName == String.Empty)
      {
        Console.WriteLine("Недопускается пустое значение. Введите команду!");
        commandName = Console.ReadLine();
      }
      Controller.LearnNewCommand(name, commandName);
    }
    public void ShowAnimalCommands()
    {
      Console.WriteLine($"Введите кличку животного, команды которого хотели бы узнать:");
      string? name = Console.ReadLine();
      while (name == String.Empty || Controller.FindByName(name) is null)
      {
        Console.WriteLine("Животного с такой кличкой нет в реестре. Проверьте, правильно ли вы вводите кличку и попробуйте еще раз!");
        name = Console.ReadLine();
      }
      List<Command> animalCommands = Controller.GetAnimalCommands(name);
      Console.WriteLine($"Команды, выученные животным: {name}");

      foreach (Command command in animalCommands)
      {
        Console.WriteLine($"\t{command.Name}");
      }
    }
  }
}