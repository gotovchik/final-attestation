namespace BusinessDomain
{
  public interface IAnimal
  {
    public string? Name { get; set; }
    public DateOnly? Birthday { get; set; }
    public ICollection<Command> Commands { get; set; }
  }
}