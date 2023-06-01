namespace BusinessDomain
{
  public class Donkey
  {
    public Guid id { get; set; }
    public string? Name { get; set; }
    public DateOnly? Birthday { get; set; }
    public List<Command> Commands { get; set; }
  }
}