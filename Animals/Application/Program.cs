using Application.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence;

public class Program
{
  public static void Main(string[] args)
  {
    var configuration = new ConfigurationBuilder()
      .AddJsonFile("appsettings.json")
      .Build();

    var connectionOption = new DbContextOptionsBuilder<AnimalsContext>()
      .UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection"))
      .Options;

    var db = new AnimalsContext(connectionOption);
    var provider = new StartDataProvider(db);
    provider.Provide();

    var app = new AnimalConsoleView(db);

    app.Greetings();
    app.Menu();
    ConsoleKeyInfo key = Console.ReadKey();
    while (!(key.KeyChar == '0'))
    {
      switch (key.KeyChar)
      {
        case '1':
          app.ShowAllAnimals();
          app.Menu();
          key = Console.ReadKey();
          break;
        case '2':
          app.AddAnimal();
          app.Menu();
          key = Console.ReadKey();
          break;
        case '3':
          app.ShowAnimalCommands();
          app.Menu();
          key = Console.ReadKey();
          break;
        case '4':
          app.LearnNewCommand();
          app.Menu();
          key = Console.ReadKey();
          break;
        default:
          Console.WriteLine($"Такого пункта меню нет. Попробуйте еще раз!");
          app.Menu();
          key = Console.ReadKey();
          break;
      }
    }






  }
}