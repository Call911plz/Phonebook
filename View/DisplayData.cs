using Spectre.Console;

static class DisplayData
{

    public static void ContactTable(List<Contact> contacts)
    {
        Table table = new();
        
        table.AddColumns(["Id", "Name", "Email", "Phone Number", "Service Provider", "Category"]);
        for (int i = 0; i < contacts.Count; i++)
        {
            table.AddRow([
                (i + 1).ToString(), 
                contacts[i].Name ?? "", 
                contacts[i].Email ?? "",
                contacts[i].PhoneNumber ?? "",
                contacts[i].ServiceProvider ?? "",
                contacts[i].CategoryName ?? "",
            ]);
        }

        AnsiConsole.Write(table);
    }

    public static void CategoryTable(List<Category> categories)
    {
        Table table = new();

        table.AddColumns(["Id", "Name"]);
        for (int i = 0; i < categories.Count; i++)
        {
            table.AddRow([
                (i + 1).ToString(),
                categories[i].Name
            ]);
        }

        AnsiConsole.Write(table);
    }
}