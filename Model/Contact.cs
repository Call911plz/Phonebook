
class Contact (int id, string name, string email, string phoneNumber) : Entity (id)
{
    public string Name => name;
    public string Email => email;
    public string PhoneNumber => phoneNumber;
    public string? CategoryName { get; set; }

}