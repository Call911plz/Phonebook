using System.Net;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;

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
