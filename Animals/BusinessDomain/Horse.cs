namespace BusinessDomain
{
  public class Horse
  {
    public Guid id { get; set; }
    public string? Name { get; set; }
    public DateOnly? Birthday { get; set; }
    public ICollection<Command> Commands { get; set; } = new List<Command>();
  }
}