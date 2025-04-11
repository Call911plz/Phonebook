using System.Net;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;

namespace Phonebook;

class Program
{
    static async Task Main(string[] args)
    {
        // // Start program
        // MainMenuController mainMenuController = new();
        // await mainMenuController.StartAsync();    


        // Email sending testing
        using var db = new DatabaseContext();
        UserData currentUser = await db.UserDatas.FirstAsync();
        Contact contact = new Contact{
            
        };

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(currentUser.Email, currentUser.EmailPassword),
            EnableSsl = true,
        };

        
    }
}


/*

- [] Categories table user can use to add categories to contacts
    - when category updated, check for contact withs said category to update with
    - needs to check for unique
- [] Email sent using https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailmessage?view=net-9.0
- [] SMS sent using 
    https://stackoverflow.com/questions/31246531/can-i-send-sms-messages-from-a-c-sharp-application
    - prob use my phone as target
 */