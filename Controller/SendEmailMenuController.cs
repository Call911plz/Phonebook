using System.Net;
using System.Net.Mail;

class SendEmailMenuController : MenuControllerBase
{
    UserDataManager userDataManager = new();
    UserData currentUser = new();
    protected override async Task OnReady()
    {
        var userDatas = userDataManager.GetAllEntity();
        if (userDatas.Count == 0)
        {
            currentUser = GetData.NewUserData();
            await userDataManager.CreateEntityAsync(currentUser);
        }
        else 
        {
            currentUser = GetData.EntityFromSelection(userDatas);
        }
    }

    protected override async Task<bool> HandleUserInput()
    {
        MenuEnums.SendEmail userInput = DisplayMenu.SendEmail();
        switch (userInput)
        {
            case MenuEnums.SendEmail.SENDEMAIL:
                SendEmail();
                break;
            case MenuEnums.SendEmail.ADDUSERDATA:
                await AddUserDataAsync();
                break;
            case MenuEnums.SendEmail.DELETEUSERDATA:
                await DeleteUserDataAsync();
                break;
            case MenuEnums.SendEmail.UPDATEUSERDATA:
                await UpdateUserDataAsync();
                break;
            case MenuEnums.SendEmail.BACK: 
                return true;
        }
        return false;
    }

    private void SendEmail()
    {
        using var db = new DatabaseContext();

        // Display contact to send an email to
        ContactDatabaseManager contactDatabaseManager = new();
        List<Contact> contacts = contactDatabaseManager.GetAllEntity();

        DisplayData.ContactTable(contacts);
        
        Contact contact = GetData.EntityFromList(contacts);

        // Send email
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(currentUser.Email, currentUser.EmailPassword),
            EnableSsl = true,
        };
        GetData.WriteEmail(out var subject, out var body);
        smtpClient.Send(currentUser.Email, contact.Email, subject, body);
    }

    private async Task AddUserDataAsync()
    {
        UserData newUser = GetData.NewUserData();
        await userDataManager.CreateEntityAsync(newUser);
    }

    private async Task DeleteUserDataAsync()
    {
        UserData userData = GetData.EntityFromSelection(userDataManager.GetAllEntity());
        await userDataManager.DeleteEntityAsync(userData);
    }

    private async Task UpdateUserDataAsync()
    {
        var userDatas = userDataManager.GetAllEntity();
        UserData userData = GetData.EntityFromSelection(userDatas);

        UserData newUserData = GetData.NewUserData(userData);

        await userDataManager.UpdateEntityAsync(newUserData);
    }
}