// Currently only using gmail as I currently only use gmail


using Microsoft.EntityFrameworkCore;

class EmailManager : DatabaseManagerBase
{
    public async Task CreateEntityAsync(UserData userData)
    {
        using var db = new DatabaseContext();
        db.Add(userData);

        await db.SaveChangesAsync();
    }

    public new List<UserData> GetAllEntity()
    {
        using var db = new DatabaseContext();
        return db.UserDatas.ToList();
    }

    public async Task UpdateEntityAsync(UserData userData)
    {
        using var db = new DatabaseContext();
        
        UserData userDataFromDB = await db.UserDatas
            .Where(data => data.Id == userData.Id)
            .FirstAsync();
        
        userDataFromDB.DisplayName = userData.DisplayName;
        userDataFromDB.Email = userData.Email;
        userDataFromDB.EmailPassword = userData.EmailPassword;

        await db.SaveChangesAsync();
    }

    public async Task DeleteEntityAsync(UserData userData)
    {
        using var db = new DatabaseContext();
        
        UserData userDataFromDB = await db.UserDatas
            .Where(data => data.Id == userData.Id)
            .FirstAsync();
        
        db.Remove(userDataFromDB);

        await db.SaveChangesAsync();
    }
}