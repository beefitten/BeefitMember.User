namespace Persistence.Settings
{
    public interface IDatabaseSettings
    {
        string CollectionName { get; }
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}