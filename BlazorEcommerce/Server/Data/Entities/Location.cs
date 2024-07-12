namespace BlazorEcommerce.Server;

public class Location
{
    public Guid  Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Address { get; set; }
}
