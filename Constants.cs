namespace Baro;


public static class Constants
{
    public const string DatabaseFilename = "Baro.db3";

    public const SQLite.SQLiteOpenFlags Flags =
        SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create |
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    public const string BackendURL = "http://10.0.2.2:8000/";
    public const string Secret = "da7487d5b61b12537a9f81bdaa06dc02a6cf6be6f80a197f0051b2934544a95a";
}