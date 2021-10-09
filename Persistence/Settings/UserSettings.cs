namespace Persistence.Settings
{
    public class UserSettings : IDatabaseSettings
    {
        public UserSettings()
        {
            CollectionName = "User";
            ConnectionString = AppConfig.GetConnectionString();
            DatabaseName = "BeefitMember";
        }
        public string CollectionName { get; }
        public string ConnectionString { get; }
        public string DatabaseName { get; }
    }
}