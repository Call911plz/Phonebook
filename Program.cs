namespace Phonebook;

class Program
{
    static async Task Main(string[] args)
    {
        // // Model testing
        // ContactDatabaseManager contactDatabaseManager = new();

        // // Show old contacts
        // var oldContacts = contactDatabaseManager.GetAllEntity();
        // DisplayData.ContactTable(oldContacts);

        // // Selecting contact to update
        // Contact oldContact = GetData.ContactFromList(oldContacts);

        // // Updating contact with new information
        // Contact newContact = GetData.NewContact(oldContact);

        // await contactDatabaseManager.UpdateEntityAsync(newContact);

        // var shit = contactDatabaseManager.GetAllEntity();
        // DisplayData.ContactTable(shit);

        // Controller testing
        ContactController contactController = new();
        await contactController.StartAsync();

        //// View testing
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