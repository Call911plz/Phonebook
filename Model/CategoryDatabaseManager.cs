
class CategoryDatabaseManager : DatabaseManagerBase
{
    public override void CreateEntity()
    {
        base.CreateEntity();
    }
    
    public override void ViewAllEntity()
    {
        using var db = new DatabaseContext();

        foreach(Category category in db.Categories)
        {
            Console.WriteLine(category);
        }
    }

    public override void UpdateEntity()
    {
        base.UpdateEntity();
    }

    public override void DeleteEntity()
    {
        base.DeleteEntity();
    }
}