using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<UserData> UserDatas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(@"
            Server=localhost;
            Database=phonebookdbs;
            User Id=sa;
            Password=StrongP@ssword1;
            TrustServerCertificate=True;");
    }
}