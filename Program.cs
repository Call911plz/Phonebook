using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json;


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
        // Calling from api
        var options = new RestClientOptions("https://lookups.twilio.com/v2/PhoneNumbers/") 
        {
            Authenticator = new HttpBasicAuthenticator(
                "", 
                ""
            )
        };
        var client = new RestClient(options);
        var request = new RestRequest($"{number}?Fields=line_type_intelligence", Method.Get);
        request.AddParameter("Field", "line_type_intelligence");
        var response = await client.ExecuteAsync(request);


        // Extracting line's carrier from api call's data
        if (response.IsSuccessful)
        {
            using var doc = JsonDocument.Parse(response.Content);
            var root = doc.RootElement;

            if (root.TryGetProperty("line_type_intelligence", out var lineTypeInfo))
                return lineTypeInfo.GetProperty("carrier_name").ToString();
            else
                Console.WriteLine("line_type_intelligence not found in the response.");
        }
        else
        {
            Console.WriteLine($"Request failed: {response.StatusCode}");
            Console.WriteLine(response.Content);
        }
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