using BartenderUI.Redis;

namespace BartenderUI.Util.Events
{
    class RefreshEvent
    {
        public static void Invoke()
        {
            RedisRepository.Publish("refresh", "refresh");
        }
    }
}
