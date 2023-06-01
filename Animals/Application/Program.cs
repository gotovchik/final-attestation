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
  }
}