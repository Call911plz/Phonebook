using Spectre.Console;

static class DisplayData
{

    public static void ContactTable(List<Contact> contacts)
    {
        Table table = new();
        
        table.AddColumns(["Id", "Name", "Email", "Phone Number", "Service Provider", "Category"]);
        foreach (Contact contact in contacts)
        {
            table.AddRow([
                contact.Id.ToString(), 
                contact.Name ?? "", 
                contact.Email ?? "",
                contact.PhoneNumber ?? "",
                contact.ServiceProvider ?? "",
                contact.CategoryName ?? "",
            ]);
        }

        AnsiConsole.Write(table);
    }
}