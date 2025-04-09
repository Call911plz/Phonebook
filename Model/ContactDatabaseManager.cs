
class ContactDatabaseManager : DatabaseManagerBase
{
    public async Task CreateEntityAsync(Contact contact)
    {
        using var db = new DatabaseContext();
        db.Add(contact);
        await db.SaveChangesAsync();
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