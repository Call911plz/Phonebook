using Microsoft.Data.SqlClient;

class DatabaseModel
{
    private static string ConnectionString;
    public static void Start()
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = "localhost",
            UserID = "sa",
            Password = "<YourStrong@Passw0rd>",
            InitialCatalog = "FlashCardsProject",
            TrustServerCertificate = true
        };
        ConnectionString = builder.ConnectionString;
    }
}