namespace BusinessDomain
{
  public class Cat
  {
    public Guid id { get; set; }
    public string? Name { get; set; }
    public DateOnly? Birthday { get; set; }
    public ICollection<Command> Commands { get; set; } = new List<Command>();
  }
}