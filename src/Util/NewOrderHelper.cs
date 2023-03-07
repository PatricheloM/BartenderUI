using BartenderUI.Redis;
using BartenderUI.Util.HelperTypes;
using System.Collections.Generic;

namespace BartenderUI.Util
{
    class NewOrderHelper
    {
        public static IEnumerable<NewOrder> GetNewOrders()
        {
            foreach (string order in RedisRepository.LRange("new_orders"))
            {
                yield return PublishedMessageConverter.StringToObject(order);
            }
        }
    }
}
