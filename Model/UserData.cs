
public class UserData : Entity
{
    public string DisplayName { get; set; } = "";
    public string Email { get; set; } = "";
    public string EmailPassword { get; set; } = "";

    public override string ToString()
    {
        return Id.ToString() + "\t" + DisplayName + "\t" + Email + "\t" + EmailPassword;
    }
}