using Spectre.Console;

static class DisplayMenu
{
    public static MenuEnums.Main MainMenu()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<MenuEnums.Main>()
                .Title("[bold grey]Select[/]")
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(Enum.GetValues<MenuEnums.Main>())
                .UseConverter( (input) => {
                    return input switch 
                    {
                        MenuEnums.Main.MANAGECONTACTS => "Manage contacts",
                        MenuEnums.Main.MANAGECATEGORY => "Manage category",
                        MenuEnums.Main.SENDEMAIL => "Send Email",
                        MenuEnums.Main.SENDSMS => "Send SMS",
                        MenuEnums.Main.EXIT => "Exit",
                        _ => input.ToString() // Will be an error.
                    };
                })
        );
    }
    public static MenuEnums.Contact Contact()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<MenuEnums.Contact>()
                .Title("[bold grey]Select[/]")
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(Enum.GetValues<MenuEnums.Contact>())
                .UseConverter( (input) => {
                    return input switch 
                    {
                        MenuEnums.Contact.ADDCONTACT => "Add contact",
                        MenuEnums.Contact.DELETECONTACT => "Delete contact",
                        MenuEnums.Contact.UPDATECONTACT => "Update contact",
                        MenuEnums.Contact.READCONTACT => "View all contact",
                        MenuEnums.Contact.BACK => "Back",
                        _ => input.ToString() // Will be an error.
                    };
                })
        );
    }
    public static MenuEnums.Category Category()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<MenuEnums.Category>()
                .Title("[bold grey]Select[/]")
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(Enum.GetValues<MenuEnums.Category>())
                .UseConverter( (input) => {
                    return input switch 
                    {
                        MenuEnums.Category.ADDCATEGORY => "Add category",
                        MenuEnums.Category.DELETECATEGORY => "Delete category",
                        MenuEnums.Category.UPDATECATEGORY => "Update category",
                        MenuEnums.Category.READCATEGORY => "View all category",
                        MenuEnums.Category.BACK => "Back",
                        _ => input.ToString() // Will be an error.
                    };
                })
        );
    }
}