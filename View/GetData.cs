using System.Net.Mail;
using Spectre.Console;

public static class GetData
{
    public static Contact NewContact(Contact? existingContact = null)
    {
        existingContact ??= Contact.Default;

        Contact contact = new()
        {
            Id = existingContact.Id, // will already be default if not set 
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
        return AnsiConsole.Prompt(
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

    public static Contact ContactFromList(List<Contact> contacts)
    {
        TextPrompt<int> textPrompt = new("[bold grey]Enter Id:[/]");
        textPrompt.AddChoices(contacts.Select(c => c.Id).ToList());
        textPrompt.ShowChoices(false);

        return contacts[AnsiConsole.Prompt(textPrompt) - 1];
    }
}