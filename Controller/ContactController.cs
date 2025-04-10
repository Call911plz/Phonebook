using Twilio;
using Twilio.Rest.Lookups.V2;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Spectre.Console;

class ContactController : ControllerBase
{
    ContactDatabaseManager contactDatabaseManager = new();
    protected override async Task<bool> HandleUserInput()
    {
        MenuEnums.Contact userInput = DisplayMenu.Contact();
        switch (userInput)
        {
            case MenuEnums.Contact.ADDCONTACT:
                await AddContactAsync();
                break;
            case MenuEnums.Contact.DELETECONTACT:
                await DeleteContactAsync();
                break;
            case MenuEnums.Contact.UPDATECONTACT:
                await UpdateContactAsync();
                break;
            case MenuEnums.Contact.READCONTACT:
                ReadContact();
                break;
            case MenuEnums.Contact.BACK:
                return true;
        }

        return false;
    }

    private async Task AddContactAsync()
    {
        AnsiConsole.MarkupLine("[bold grey]Enter contact's information. Information can be left blank [/]");
        Contact contact = GetData.NewContact();
        contact.ServiceProvider = await GetPhoneNumberCarrierAsync(contact.PhoneNumber);
        await contactDatabaseManager.CreateEntityAsync(contact);
    }

    private async Task DeleteContactAsync()
    {
        // Show old contacts
        var oldContacts = contactDatabaseManager.GetAllEntity();
        DisplayData.ContactTable(oldContacts);

        // Selecting contact to delete
        Contact contactToDelete = GetData.EntityFromList(oldContacts);

        // Send to DBManager to delete
        await contactDatabaseManager.DeleteEntityAsync(contactToDelete);
    }

    private async Task UpdateContactAsync()
    {
        // Show old contacts
        var oldContacts = contactDatabaseManager.GetAllEntity();
        DisplayData.ContactTable(oldContacts);

        // Selecting contact to update
        Contact oldContact = GetData.EntityFromList(oldContacts);

        // Updating contact with new information
        Contact newContact = GetData.NewContact(oldContact);
        if (oldContact.PhoneNumber != newContact.PhoneNumber)
            newContact.ServiceProvider = await GetPhoneNumberCarrierAsync(newContact.PhoneNumber);

        // Send to DBManager to update
        await contactDatabaseManager.UpdateEntityAsync(newContact);
    }

    private void ReadContact()
    {
        List<Contact> contacts = contactDatabaseManager.GetAllEntity();
        DisplayData.ContactTable(contacts);
    }

    static async Task<string?> GetPhoneNumberCarrierAsync(string? number)
    {
        // Accessing phone carrier api
        TwilioClient.Init("", "");
        var phoneNumber = await PhoneNumberResource.FetchAsync
        (
            pathPhoneNumber: number, 
            fields: "line_type_intelligence"
        );

        // Getting and checking for if carrier exists
        var obj = phoneNumber.LineTypeIntelligence;
        var objSeralizedJson = JsonConvert.SerializeObject(obj);
        var objDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(objSeralizedJson);

        if (objDict == null)
        {
            Console.WriteLine("Does not contain LineTypeIntelligence");
            return null;
        }
        if (objDict.TryGetValue("carrier_name", out var name))
            return name;

        Console.WriteLine("Unknown error in get phone number carrier");
        return null;
    }
}