using System.Net.Mail;
using Spectre.Console;

public static class GetData
{
    public static Contact NewContact(Contact? existingContact = null)
    {
        existingContact ??= Contact.Default;

        Contact contact = new()
        {
            Id = existingContact.Id, // will already be default if existingContact is not set 
            Name = ContactName(existingContact.Name),
            Email = ContactEmail(existingContact.Email),
            PhoneNumber = ContactPhoneNumber(existingContact.PhoneNumber),
            ServiceProvider = existingContact.ServiceProvider ?? null,
            CategoryName = ContactCategory(existingContact.CategoryName),
        };
        return contact;
    }
    static string? ContactName(string? existingName = null) 
    { 
        return AnsiConsole.Prompt(
            new TextPrompt<string?>("[bold grey]Enter contact's name:[/]")
                .AllowEmpty()
                .DefaultValue(existingName)
        ); 
    }
    static string? ContactEmail(string? existingEmail = null) 
    { 
        string? unparsedEmail = AnsiConsole.Prompt(
            new TextPrompt<string?>("[bold grey]Enter contact's email:[/]")
                .AllowEmpty()
                .DefaultValue(existingEmail)
                .Validate( (email) => {
                    if (email == null)
                        return ValidationResult.Success();
                    if (!MailAddress.TryCreate(email, out var i))
                        return ValidationResult.Error("[bold red]Invalid email[/]");
                    return ValidationResult.Success();
                })
        ); 
        if (unparsedEmail == null)
            return null;
        if (!MailAddress.TryCreate(unparsedEmail, out var parsedEmail))
            return parsedEmail.ToString();
        return null;
    }
    static string? ContactPhoneNumber(string? existingPhoneNumber = null) 
    {
        var userInput = AnsiConsole.Prompt(
            new TextPrompt<string?>("[bold grey]Enter contact's phone number (###)-###-####:[/]")
                .AllowEmpty()
                .DefaultValue(existingPhoneNumber)
                .Validate( (number) => {
                    if (number == null)
                        return ValidationResult.Success();
                    if (!TryParsePhoneNumber(number, out number))
                        return ValidationResult.Error("[bold red]Invalid number[/]");
                    return ValidationResult.Success();
                })
        );
        _ = TryParsePhoneNumber(userInput, out userInput);
        return userInput;
    }
    static bool TryParsePhoneNumber(string number, out string result)
    {
        result = "";

        // Checking for invalid numbers
        foreach(char letter in number)
        {
            if (char.IsNumber(letter))
                result += letter;
            
            // Checking for letters
            if (char.IsAsciiLetter(letter))
                return false;
        }
        // Checking for not 10 numbers
        if (result.Length != 10)
            return false;
        
        return true;
    }
    static string? ContactCategory(string? existingName = null) 
    { 
        // TODO: implement selection/multi-selection when category implemented
        return null; 
    }


    public static Category NewCategory(Category? existingCategory = null)
    {
        existingCategory ??= new Category();

        Category category = new()
        {
            Id = existingCategory.Id,
            Name = CategoryName(existingCategory.Name),
        };
        return category;
    }
    static string CategoryName(string existingName = "") 
    { 
        return AnsiConsole.Prompt(
            new TextPrompt<string>("[bold grey]Enter category's name:[/]")
                .DefaultValue(existingName)
        ); 
    }


    public static UserData NewUserData(UserData? existingUserData = null)
    {
        existingUserData ??= new UserData();

        UserData userData = new()
        {
            Id = existingUserData.Id,
            DisplayName = UserDataDisplayName(existingUserData.DisplayName),
            Email = UserDataEmail(existingUserData.Email),
            EmailPassword = UserDataEmailPassword(existingUserData.EmailPassword),
        };

        return userData;
    }
    
    private static string UserDataDisplayName(string existingName = "")
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>("[bold grey]Enter a display name:[/]")
                .DefaultValue(existingName)
        ); 
    }

    private static string UserDataEmail(string existingEmail = "")
    {
        string? unparsedEmail = AnsiConsole.Prompt(
            new TextPrompt<string?>("[bold grey]Enter your email (currently only accepting gmail):[/]")
                .AllowEmpty()
                .DefaultValue(existingEmail)
                .Validate( (email) => {
                    if (!MailAddress.TryCreate(email, out var i))
                        return ValidationResult.Error("[bold red]Invalid email[/]");
                    if (!email.Contains("@gmail.com"))
                        return ValidationResult.Error("[bold red]Invalid email. Use gmail[/]");
                    return ValidationResult.Success();
                })
        ); 
        MailAddress.TryCreate(unparsedEmail, out var parsedEmail);
        return parsedEmail.ToString();
    }

    private static string UserDataEmailPassword(string existingPassword = "")
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>("[bold grey]Enter a your email's password:[/]")
                .DefaultValue(existingPassword)
        ); 
    }

    public static T EntityFromList<T>(List<T> entities) where T : Entity 
    {
        TextPrompt<int> textPrompt = new("[bold grey]Enter Id:[/]");
        textPrompt.AddChoices(Enumerable.Range(1, entities.Count).ToList());
        textPrompt.ShowChoices(false);

        return entities[AnsiConsole.Prompt(textPrompt) - 1];
    }

    public static T EntityFromSelection<T>(List<T> entities) where T : Entity
    {
        SelectionPrompt<T> prompt = new();
        prompt.Title("[bold grey]Select[/]");
        prompt.AddChoices(entities);
        prompt.UseConverter( userInput => {
            return userInput.ToString() ?? "";
        });
        return AnsiConsole.Prompt(
            prompt
        );
    }
}