namespace Phonebook;

class Program
{
    static async Task Main(string[] args)
    {
        // Start program
        MainMenuController mainMenuController = new();
        await mainMenuController.StartAsync();
    }
}

public class TwilioAPI
{
    public static string Key;
    public static string PassWord;
}