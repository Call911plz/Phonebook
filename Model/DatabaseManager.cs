
using System.Reflection;

class DatabaseManagerBase
{
    // Create
    public virtual void CreateEntity() {}

    // Read
    public virtual List<Entity> GetAllEntity() { throw new NotImplementedException(); }

    // Update
    public virtual void UpdateEntity() {}

    // Delete
    public virtual void DeleteEntity() {}
}