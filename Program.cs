using System.Net;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
    public static string Key = null;
    public static string PassWord = null;
}