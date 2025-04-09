
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
}