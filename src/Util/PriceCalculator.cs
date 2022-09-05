using System;
using BartenderUI.Redis;

namespace BartenderUI.Util
{
    class PriceCalculator
    {
        public static string CalculateByQuantity(string name, int quantity)
        {
            return Convert.ToInt32(RedisRepository.HGet("menu", name)) * quantity == 0 ? "Nem található ár!" : (Convert.ToInt32(RedisRepository.HGet("menu", name)) * quantity).ToString();
        }

        public static int CalculateFullInvoice(string invoice)
        {
            throw new NotImplementedException();
        }
    }
}
