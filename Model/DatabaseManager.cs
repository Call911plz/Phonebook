
using System.Reflection;

class DatabaseManager
{
    // Create

    // Read
    public void ViewAllContacts()
    {
        using var db = new DatabaseContext();

        foreach(Contact contact in db.Contacts)
        {
            Console.WriteLine(contact);
        }
    }

    public void ViewAllCategory()
    {
        using var db = new DatabaseContext();

        foreach(Category category in db.Categories)
        {
            Console.WriteLine(category);
        }
    }

    // Update

    // Delete
}