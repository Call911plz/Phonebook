
using Microsoft.EntityFrameworkCore;

class CategoryDatabaseManager : DatabaseManagerBase
{
    public async Task CreateEntityAsync(Category category)
    {
        using var db = new DatabaseContext();
        db.Add(category);

        await db.SaveChangesAsync();
    }

    public new List<Category> GetAllEntity()
    {
        using var db = new DatabaseContext();
        return db.Categories.ToList();   
    }

    public async Task UpdateEntityAsync(Category updatedCategory)
    {
        using var db = new DatabaseContext();
        var categoryFromDB = await db.Categories
            .Where(category => category.Id == updatedCategory.Id)
            .FirstAsync();
        
        categoryFromDB.Name = updatedCategory.Name;

        await db.SaveChangesAsync();
    }

    public async Task DeleteEntityAsync(Category categoryToDelete)
    {
        using var db = new DatabaseContext();
        var categoryFromDB = await db.Categories
            .Where(category => category.Id == categoryToDelete.Id)
            .FirstAsync();

        db.Remove(categoryFromDB);

        await db.SaveChangesAsync();
    }
}