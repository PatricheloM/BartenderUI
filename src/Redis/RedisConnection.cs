using StackExchange.Redis;
using BartenderUI.Util.Json.Settings;

namespace BartenderUI.Redis
{
    class RedisConnection
    {
        private static readonly string connAddr = SettingsRepository.GetSettings().RedisConnection;
        private static readonly string connPass =  ",password=" + SettingsRepository.GetSettings().RedisPassword;
        private static readonly ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(connAddr + connPass);

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

        public static IServer GetServer()
        {
            return GetMultiplexer().GetServer(connAddr);
        }
    }
}
