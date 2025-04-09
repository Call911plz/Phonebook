using System.Net.Mail;
using Spectre.Console;

public static class GetData
{
    public static Contact Contact()
    {
        Contact contact = new()
        {
            Name = ContactName(),
            Email = ContactEmail(),
            PhoneNumber = ContactPhoneNumber(),
            CategoryName = ContactCategory(),
        };
        return contact;
    }
    static string? ContactName() 
    { 
        return AnsiConsole.Prompt(
            new TextPrompt<string?>("[bold grey]Enter contact's name:[/]")
                .AllowEmpty()
        ); 
    }
    static string? ContactEmail() 
    { 
        return AnsiConsole.Prompt(
            new TextPrompt<string?>("[bold grey]Enter contact's email:[/]")
                .AllowEmpty()
                .Validate( (email) => {
                    if (email == null)
                        return ValidationResult.Success();
                    if (!MailAddress.TryCreate(email, out var i))
                        return ValidationResult.Error("[bold red]Invalid email[/]");
                    return ValidationResult.Success();
                })
        ); 
    }

    static string? ContactPhoneNumber() 
    {
        var userInput = AnsiConsole.Prompt(
            new TextPrompt<string?>("[bold grey]Enter contact's phone number (###)-###-####:[/]")
                .AllowEmpty()
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

    static string? ContactCategory() 
    { 
        // TODO: implement selection/multi-selection when category implemented
        return null; 
    }
}