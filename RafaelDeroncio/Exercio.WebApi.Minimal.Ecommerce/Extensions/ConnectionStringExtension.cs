using System.Data.Common;

namespace Exercio.WebApi.Minimal.Ecommerce.Extensions;

public static class ConnectionStringBuilderExtensions
{
    public static string GetConnectionString(this IConfiguration configuration, string name, bool configure)
    {
        if (configure)
        {
            string sqliteConnectionString = configuration.GetConnectionString(name);

            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            string appPath = Path.GetFullPath(Path.Combine(currentPath, "..", "..", ".."));

            string connectionStringWithAppPath = sqliteConnectionString.Replace("Data Source=", $"Data Source={appPath}{Path.DirectorySeparatorChar}");

            return connectionStringWithAppPath;
        }

        return configuration.GetConnectionString(name);
    }
}