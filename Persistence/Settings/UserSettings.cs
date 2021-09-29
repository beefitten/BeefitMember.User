namespace Persistence.Settings
{
    public class UserSettings : IDatabaseSettings
    {
        public UserSettings()
        {
            CollectionName = "User";
            ConnectionString = "mongodb+srv://Beefit2121:Beefit123@beefitmemberuser.aole2.mongodb.net/test";
            DatabaseName = "BeefitMember";
        }
        public string CollectionName { get; }
        public string ConnectionString { get; }
        public string DatabaseName { get; }
    }
}