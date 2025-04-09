
public class Contact : Entity 
{
    public string? Name { get; set; } 
    public string? Email { get; set; } 
    public string? PhoneNumber { get; set; }
    public string? ServiceProvider { get; set; } 
    public string? CategoryName { get; set; }

    public override string ToString()
    {
        return Id + "\t" + Name + "\t" + Email + "\t" + PhoneNumber + "\t" + ServiceProvider + "\t" + CategoryName;
    }

    public static Contact Default => new Contact 
    {
        Id = default,
        Name = null,
        Email = null,
        PhoneNumber = null,
        ServiceProvider = null,
        CategoryName = null,
    };
}