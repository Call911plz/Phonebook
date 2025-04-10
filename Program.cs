namespace Phonebook;

class Program
{
    static async Task Main(string[] args)
    {
        // Model testing
        CategoryDatabaseManager categoryDatabaseManager = new();

        // Create
        Category category = GetData.NewCategory();
        await categoryDatabaseManager.CreateEntityAsync(category);

        // Read
        List<Category> categories= categoryDatabaseManager.GetAllEntity();
        DisplayData.CategoryTable(categories);

        // Update
        Category categoryToUpdate = GetData.CategoryFromList(categories);
        Category updatedCategory = GetData.NewCategory(categoryToUpdate);
        await categoryDatabaseManager.UpdateEntityAsync(updatedCategory);

        categories= categoryDatabaseManager.GetAllEntity();
        DisplayData.CategoryTable(categories);
        // Delete
        Category categoryToDelete = GetData.CategoryFromList(categories);
        await categoryDatabaseManager.DeleteEntityAsync(categoryToDelete);

        categories= categoryDatabaseManager.GetAllEntity();
        DisplayData.CategoryTable(categories);

        // Controller testing
        // ContactController contactController = new();
        // await contactController.StartAsync();

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