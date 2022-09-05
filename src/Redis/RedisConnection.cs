using StackExchange.Redis;
using BartenderUI.Util.Json.Settings;

namespace BartenderUI.Redis
{
    class RedisConnection
    {
        private static readonly ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(SettingsRepository.GetSettings().RedisConnection + ",password=" + SettingsRepository.GetSettings().RedisPassword);

        private RedisConnection()
        {
        }

        public static IDatabase GetConnection()
        {            
            IDatabase db = connection.GetDatabase();
            return db;
        }

        public static ConnectionMultiplexer GetMultiplexer()
        {
            return connection;
        }
    }
}
