using System.Windows.Forms;
using BartenderUI.Redis;
using BartenderUI.Util.Builders;
using BartenderUI.Util.Factories;

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
                    belso.Controls.Clear();
                    kulso.Controls.Clear();
                    LayoutFiller.FillLayout(belso, kulso);

                    newOrderIndicator.WithHiddenValue(false);

                    // maybe, depends on frontend and have to decide whether to interrupt the cashier when doing something else
                    // MessageBoxFactory.Produce(message.Message, MessageBoxFactory.GetNewOrderTitle(), MessageBoxButtons.OK);
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
                    belso.Controls.Clear();
                    kulso.Controls.Clear();
                    LayoutFiller.FillLayout(belso, kulso);
                }));
            });
        }
    }
}
