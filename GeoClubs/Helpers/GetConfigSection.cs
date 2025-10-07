namespace GeoClubs.Helpers
{
    public static class GetConfigSection
    {
        public static IConfigurationSection GetConfigValue(string key)
        { 
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path);
            return configurationBuilder.Build().GetSection(key);
        }
    }
}
