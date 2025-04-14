
class DatabaseManagerBase
{
    // Create
    public virtual Task CreateEntityAsync() { return Task.CompletedTask; }

    // Read
    public virtual List<Entity> GetAllEntity() { throw new NotImplementedException(); }

    // Update
    public virtual Task UpdateEntityAsync() { return Task.CompletedTask; }

    // Delete
    public virtual Task DeleteEntityAsync() { return Task.CompletedTask; }
}