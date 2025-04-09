using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Phonebook;

class Program
{
    static async Task Main(string[] args)
    {
        using var db = new DatabaseContext();

        // db.Add(new Contact 
        // { 
        //     Name = "Hieu Truong",
        //     Email = "htruong6219@gmail.com",
        //     PhoneNumber = "4086096219",
        //     CategoryName = null,
        // });

        // await db.SaveChangesAsync();

        DatabaseManager dbManager = new();
        dbManager.ViewAllContacts();

        
    }
}


/*

- [] Categories table user can use to add categories to contacts
    - when category updated, check for contact withs said category to update with
    - needs to check for unique
- [] Email sent using https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailmessage?view=net-9.0
- [] SMS sent using https://stackoverflow.com/questions/31246531/can-i-send-sms-messages-from-a-c-sharp-application
    - prob use my phone as target
 */