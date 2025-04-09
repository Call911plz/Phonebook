using Twilio;
using Twilio.Rest.Lookups.V2;
using Newtonsoft.Json;


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

        // ContactDatabaseManager contactDatabaseManager = new();
        // contactDatabaseManager.ViewAllEntity();

        var fuck = await GetPhoneNumberCarrier("6692319539");
        Console.WriteLine(fuck);
    }

    static async Task<string?> GetPhoneNumberCarrier(string number)
    {
        // Accessing phone carrier api
        TwilioClient.Init("", "");
        var phoneNumber = await PhoneNumberResource.FetchAsync
        (
            pathPhoneNumber: "4086096219", 
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


/*

- [] Categories table user can use to add categories to contacts
    - when category updated, check for contact withs said category to update with
    - needs to check for unique
- [] Email sent using https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailmessage?view=net-9.0
- [] SMS sent using 
    https://stackoverflow.com/questions/31246531/can-i-send-sms-messages-from-a-c-sharp-application
    - prob use my phone as target
 */