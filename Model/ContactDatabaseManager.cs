
class ContactDatabaseManager : DatabaseManagerBase
{
    public override void CreateEntity()
    {
        base.CreateEntity();
    }

    public override void ViewAllEntity()
    {
        using var db = new DatabaseContext();

        foreach(Contact contact in db.Contacts)
        {
            Console.WriteLine(contact);
        }
    }

    public override void UpdateEntity()
    {
        base.UpdateEntity();
    }

    public override void DeleteEntity()
    {
        base.DeleteEntity();
    }
}