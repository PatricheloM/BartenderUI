using System;
using StackExchange.Redis;
using BartenderUI.Redis;

namespace BartenderUI.Util
{
    class PriceCalculator
    {
        public static int CalculateByQuantity(string name, int quantity)
        {
            return Convert.ToInt32(RedisRepository.HGet("menu", name)) * quantity;
        }

        public static string Visualizer(string name, int quantity)
        {
            return CalculateByQuantity(name, quantity) == 0 ? "Nem található ár!" : CalculateByQuantity(name, quantity).ToString();
        }

        public static int CalculateFullInvoice(string invoice)
        {
            int final = 0;

            foreach (HashEntry entry in RedisRepository.HGetAll("szamla_" + invoice))
            {
                final +=  CalculateByQuantity(entry.Name, Convert.ToInt32(entry.Value));
            }

            return final;
        }

        public static string Visualizer(string invoice)
        {
            return CalculateFullInvoice(invoice) == 0 ? "Nem található végösszeg!" : CalculateFullInvoice(invoice).ToString();
        }

        public static int CalculateFullTable(int id)
        {
            int final = 0;

            foreach (string invoice in RedisRepository.SMembers("szamlak_" + id.ToString()))
            {
                final += CalculateFullInvoice(invoice);
            }

            return final;
        }

        public static string Visualizer(int id)
        {
            return CalculateFullTable(id) == 0 ? "Nem található végösszeg!" : CalculateFullTable(id).ToString();
        }
    }
}
