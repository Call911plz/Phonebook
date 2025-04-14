
class CategoryController : MenuControllerBase
{
    ContactDatabaseManager contactDatabaseManager = new();
    CategoryDatabaseManager categoryDatabaseManager = new();
    protected override async Task<bool> HandleUserInput()
    {
        MenuEnums.Category userInput = DisplayMenu.Category();
        switch (userInput)
        {
            case MenuEnums.Category.ADDCATEGORY:
                await AddCategoryAsync();
                break;
            case MenuEnums.Category.DELETECATEGORY:
                await DeleteCategoryAsync();
                break;
            case MenuEnums.Category.UPDATECATEGORY:
                await UpdateCategoryAsync();
                break;
            case MenuEnums.Category.READCATEGORY:
                ReadCategory();
                break;
            case MenuEnums.Category.BACK:
                return true;
        }
        return false;
    }

    // Create
    private async Task AddCategoryAsync()
    {
        Category category = GetData.NewCategory();
        await categoryDatabaseManager.CreateEntityAsync(category);
    }

    // Read
    private void ReadCategory()
    {
        List<Category> categories = categoryDatabaseManager.GetAllEntity();
        DisplayData.CategoryTable(categories);
    }

    // Update
    private async Task UpdateCategoryAsync()
    {
        // Show categories to user
        List<Category> categories= categoryDatabaseManager.GetAllEntity();
        DisplayData.CategoryTable(categories);

        // Select Id of category to update
        Category categoryToUpdate = GetData.EntityFromList(categories);

        // Update category information
        Category updatedCategory = GetData.NewCategory(categoryToUpdate);

        // Update contacts that had category
        List<Contact> contacts = await contactDatabaseManager.GetAllEntityBySearchAsync(
            contact => contact.CategoryName == categoryToUpdate.Name
        );
        foreach(Contact contact in contacts)
        {
            contact.CategoryName = updatedCategory.Name;
            await contactDatabaseManager.UpdateEntityAsync(contact);
        }

        // Send to ef
        await categoryDatabaseManager.UpdateEntityAsync(updatedCategory);
    }

    // Delete
    private async Task DeleteCategoryAsync()
    {
        // Show categories to user
        List<Category> categories= categoryDatabaseManager.GetAllEntity();
        DisplayData.CategoryTable(categories);

        // Select Id of category to delete
        Category categoryToDelete = GetData.EntityFromList(categories);

        // Delete contact's category that had old category
        List<Contact> contacts = await contactDatabaseManager.GetAllEntityBySearchAsync(
            contact => contact.CategoryName == categoryToDelete.Name
        );
        foreach(Contact contact in contacts)
        {
            contact.CategoryName = null;
            await contactDatabaseManager.UpdateEntityAsync(contact);
        }

        // Delete category with ef
        await categoryDatabaseManager.DeleteEntityAsync(categoryToDelete);
    }
}