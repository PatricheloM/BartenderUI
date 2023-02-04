using System.Windows.Forms;
using BartenderUI.Redis;
using BartenderUI.Util.Builders;
using System.Text.RegularExpressions;
using BartenderUI.Util.HelperTypes;
using System;
using StackExchange.Redis;
// using BartenderUI.Util.Factories;

namespace BartenderUI.Util
{
    class EventListeners
    {
        public static void Start(FormBuilder layout, GroupBoxBuilder belso, GroupBoxBuilder kulso, LabelBuilder newOrderIndicator)
        {
            StartRefreshListener(layout, belso, kulso);
            StartNewOrderListener(layout, belso, kulso, newOrderIndicator);
        }

        protected static void StartNewOrderListener(FormBuilder layout, GroupBoxBuilder belso, GroupBoxBuilder kulso, LabelBuilder newOrderIndicator)
        {
            var channel = RedisConnection.GetMultiplexer().GetSubscriber().Subscribe("new_order");
            channel.OnMessage(message =>
            {
                layout.Invoke(new MethodInvoker(delegate
                {
                    if (Regex.IsMatch(message.Message, @"^.+\|\d+\|\d+\|.+$"))
                    {
                        RedisRepository.LPush("new_orders", message.Message);
                        NewOrder newOrder = PublishedMessageConverter.Convert(message.Message);
                        OrderHelper.PushItemToRedis(Convert.ToInt32(newOrder.Table), newOrder.Invoice, newOrder.Item, Convert.ToInt32(newOrder.Quantity));
                        RedisRepository.HMSet("asztal_" + newOrder.Table, new HashEntry("state", SzabadFoglaltEnum.Foglalt.ToString()));
                        newOrderIndicator.WithHiddenValue(false);
                        belso.Clear();
                        kulso.Clear();
                        LayoutFiller.FillLayout(belso, kulso);
                    }
                }));
            });
        }

        protected static void StartRefreshListener(FormBuilder layout, GroupBoxBuilder belso, GroupBoxBuilder kulso)
        {
            var channel = RedisConnection.GetMultiplexer().GetSubscriber().Subscribe("refresh");
            channel.OnMessage(message =>
            {
                layout.Invoke(new MethodInvoker(delegate
                {
                    belso.Clear();
                    kulso.Clear();
                    LayoutFiller.FillLayout(belso, kulso);
                }));
            });
        }
    }
}
