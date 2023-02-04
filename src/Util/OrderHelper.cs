using BartenderUI.Redis;

namespace BartenderUI.Util
{
    class OrderHelper
    {
        public static void PushItemToRedis(int tableId, string invoice, string name, int quantity)
        {
            RedisRepository.SAdd("szamlak_" + tableId, invoice);
            RedisRepository.HIncrBy("szamla_" + invoice, name, quantity);
        }
    }
}
