using System.Data.SqlClient;

namespace NKKDotNetCore.PizzaApi;

internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "DotNetCoreTrainingBatch4",
        UserID = "sa",
        Password = "sasa@123",
        TrustServerCertificate = true,
    };
}