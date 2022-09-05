using BartenderUI.Redis;
using BartenderUI.Util.Events;
using StackExchange.Redis;

namespace BartenderUI.Util
{
    class InvoiceDeleteHelper
    {
        public static void DeleteTable(string id)
        {
            RedisRepository.SRem("asztalok", id);
            RedisRepository.Del("asztal_" + id);
            RedisRepository.Del("szamlak_" + id);
        }

        public static void DeleteInvoices(string id)
        {
            foreach (string invoice in RedisRepository.SMembers("szamlak_" + id))
            {
                RedisRepository.Del("szamla_" + invoice);
            }
            RedisRepository.Del("szamlak_" + id);
            RedisRepository.HMSet("asztal_" + id, new HashEntry("state", SzabadFoglaltEnum.Szabad.ToString()));
            RefreshEvent.Invoke();
        }

        public static void DeleteAll()
        {
            foreach (string tableId in RedisRepository.SMembers("asztalok"))
            {
                DeleteTable(tableId);
            }
            RedisRepository.Del("asztalok");
            RefreshEvent.Invoke();
        }
    }
}
