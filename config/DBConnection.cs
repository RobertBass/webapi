using DotNetEnv;

namespace webapi.config;

public class DBConnection
{
    public static string GetConnectionInfo()
    {
        Env.Load();
        string? pg_user = Environment.GetEnvironmentVariable("PG_USER");
        string? pg_password = Environment.GetEnvironmentVariable("PG_PASSWORD");
        string? pg_host = Environment.GetEnvironmentVariable("PG_HOST");
        string? pg_port = Environment.GetEnvironmentVariable("PG_PORT");
        string? pg_database = Environment.GetEnvironmentVariable("PG_DATABASE");

        if (pg_user != null && pg_password != null && pg_host != null && pg_port != null && pg_database != null)
        {
            return $"User ID={pg_user};Password={pg_password};Host={pg_host};Port={pg_port};Database={pg_database};";
        }

        return "CONNECTION TO DB FAILED";
    }
}