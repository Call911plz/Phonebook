
using Microsoft.EntityFrameworkCore;

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

    public async Task UpdateEntityAsync(Contact updatedContact)
    {
        using var db = new DatabaseContext();
        
        var contactFromDB = await db.Contacts
            .Where(contact => contact.Id == updatedContact.Id)
            .FirstAsync();
        
        contactFromDB.Name = updatedContact.Name;
        contactFromDB.Email = updatedContact.Email;
        contactFromDB.PhoneNumber = updatedContact.PhoneNumber;
        contactFromDB.ServiceProvider = updatedContact.ServiceProvider;
        contactFromDB.CategoryName = updatedContact.CategoryName;
        
        await db.SaveChangesAsync();
    }

    public async Task DeleteEntityAsync(Contact contactToDelete)
    {
        using var db = new DatabaseContext();

        var contactFromDB = await db.Contacts
            .Where(contact => contact.Id == contactToDelete.Id)
            .FirstAsync();
        
        db.Remove(contactFromDB);

        await db.SaveChangesAsync();
    }
}