namespace Persistence.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public DatabaseSettings()
        {
            CollectionName = "Test";
            ConnectionString = "mongodb+srv://Beefit2121:Beefit123@beefitmemberuser.aole2.mongodb.net/test";
            DatabaseName = "TestDb";
        }
        public string CollectionName { get; }
        public string ConnectionString { get; }
        public string DatabaseName { get; }
    }
}