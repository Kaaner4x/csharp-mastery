public class Database
{
    public readonly string _stringKey;

    // Değer çalışma zamanında dışarıdan alınarak atanıyor
    public Database(string serverName)
    {
        _stringKey = $"Server={serverName};Database=TestDb;";
    }
}