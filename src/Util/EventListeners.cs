﻿using System.Windows.Forms;
using BartenderUI.Redis;
using BartenderUI.Util.Extensions;
using System.Text.RegularExpressions;
using BartenderUI.Util.HelperTypes;
using System;
using System.Threading;

namespace BartenderUI.Util
{
    class EventListeners
    {
        public static void Start(Form layout, GroupBox belso, GroupBox kulso, Label newOrderIndicator)
        {

            while (layout.IsHandleCreated && belso.IsHandleCreated && kulso.IsHandleCreated && newOrderIndicator.IsHandleCreated)
                Thread.Sleep(100);
            StartRefreshListener(layout, belso, kulso);
            StartNewOrderListener(layout, newOrderIndicator);
        }

        protected static void StartNewOrderListener(Form layout, Label newOrderIndicator)
        {
            var channel = RedisConnection.GetMultiplexer().GetSubscriber().Subscribe("new_order");
            channel.OnMessage(message =>
            {
                layout.Invoke(new MethodInvoker(delegate
                {
                    if (Regex.IsMatch(message.Message, @"^.+\|\d+\|\d+\|.+$"))
                    {
                        NewOrder newOrder = PublishedMessageConverter.StringToObject(message.Message);
                        if (RedisRepository.SIsMember("asztalok", newOrder.Table) && RedisRepository.HExists("menu", newOrder.Item)) 
                        {
                            OrderHelper.PushItemToRedis(Convert.ToInt32(newOrder.Table), newOrder.Invoice, newOrder.Item, Convert.ToInt32(newOrder.Quantity));
                            RedisRepository.LPush("new_orders", message.Message);
                            newOrderIndicator.WithHiddenValue(false);
                        }
                    }
                }));
            });
        }

        protected static void StartRefreshListener(Form layout, GroupBox belso, GroupBox kulso)
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
