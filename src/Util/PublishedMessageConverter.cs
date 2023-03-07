using BartenderUI.Util.HelperTypes;

namespace BartenderUI.Util
{
    class PublishedMessageConverter
    {
        public static NewOrder StringToObject(string msg)
        {
            string[] parts = msg.Split('|');
            return new NewOrder(parts[0], parts[1], parts[2], parts[3]);
        }

        public static string ObjectToString(NewOrder order)
        {
            return $"{order.Item}|{order.Quantity}|{order.Table}|{order.Invoice}";
        }
    }
}
