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
    app.AddAnimal();


  }
}