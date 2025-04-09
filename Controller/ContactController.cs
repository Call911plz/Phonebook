using Twilio;
using Twilio.Rest.Lookups.V2;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Spectre.Console;

class ContactController
{
    ContactDatabaseManager contactDatabaseManager = new();
    public async Task StartAsync()
    {
        MenuEnums.Contact userInput = DisplayMenu.Contact();
        switch (userInput)
        {
            case MenuEnums.Contact.ADDCONTACT:
                await AddContactAsync();
                break;
            case MenuEnums.Contact.DELETECONTACT:
                DeleteContactAsync();
                break;
            case MenuEnums.Contact.UPDATECONTACT:
                UpdateContactAsync();
                break;
            case MenuEnums.Contact.READCONTACT:
                ReadContact();
                break;
            case MenuEnums.Contact.BACK:
                break;
        }
    }

    private async Task AddContactAsync()
    {
        AnsiConsole.MarkupLine("[bold grey]Enter contact's information. Information can be left blank [/]");
        Contact contact = GetData.Contact();
        contact.ServiceProvider = await GetPhoneNumberCarrierAsync(contact.PhoneNumber);
        await contactDatabaseManager.CreateEntityAsync(contact);
    }

    private void DeleteContactAsync()
    {
        throw new NotImplementedException();
    }

    private void UpdateContactAsync()
    {
        throw new NotImplementedException();
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