using BartenderUI.Redis;
using BartenderUI.Util.Events;
using StackExchange.Redis;
using System.Windows.Forms;

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

        public static void DeleteInvoice(string invoice)
        {
            RedisRepository.Del("szamla_" + invoice);
            foreach (string table in RedisRepository.SMembers("asztalok"))
            {
                if (RedisRepository.SIsMember("szamlak_" + table, invoice))
                {
                    RedisRepository.SRem("szamlak_" + table, invoice);
                    if (!RedisRepository.Exists("szamlak_" + table))
                    {
                        RedisRepository.HMSet("asztal_" + table, new HashEntry("state", SzabadFoglaltEnum.Szabad.ToString()));
                    }
                    break;
                }
            }
            RefreshEvent.Invoke();
        }

        public static void DeleteInvoices(int id)
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
