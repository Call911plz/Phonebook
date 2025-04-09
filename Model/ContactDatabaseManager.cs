
class ContactDatabaseManager : DatabaseManagerBase
{
    public async Task CreateEntityAsync(Contact contact)
    {
        using var db = new DatabaseContext();
        db.Add(contact);
        await db.SaveChangesAsync();
    }

    public new List<Contact> GetAllEntity()
    {
        using var db = new DatabaseContext();
        return db.Contacts.ToList();
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