using System;
using System.Windows.Forms;
using BartenderUI.Util;
using BartenderUI.Util.Events;
using BartenderUI.Util.Factories;
using BartenderUI.Redis;
using BartenderUI.Util.Extensions;

namespace BartenderUI.Layout
{
    class Layout : AbstractLayout
    {
        public Layout()
        {
            InitializeComponents();

            EventListeners.Start(this, groupBoxBelso, groupBoxKulso, newOrderLabel);

            if (RedisRepository.LLen("new_orders") != 0) newOrderLabel.WithHiddenValue(false); 
        }

        protected override void PluszBelsoButtonClickEvent(object sender, EventArgs e)
        {
            groupBoxBelso.AddAll(TableFactory.Produce(TablePlaceEnum.Belso));
            RefreshEvent.Invoke();
        }

        protected override void PluszKulsoButtonClickEvent(object sender, EventArgs e)
        {
            groupBoxKulso.AddAll(TableFactory.Produce(TablePlaceEnum.Kulso));
            RefreshEvent.Invoke();
        }

        protected override void ExitButtonClickEvent(object sender, EventArgs e)
        {
            if (MessageBoxFactory.Produce(MessageBoxFactory.GetExitText(), MessageBoxFactory.GetExitTitle(), MessageBoxButtons.YesNo) == MessageBoxFactory.GetPositiveResult()) Application.Exit();
        }

        protected override void MinimizeButtonClickEvent(object sender, EventArgs e)
        {
            this
                .WithState(FormWindowState.Minimized);
        }

        protected override void MenuButtonClickEvent(object sender, EventArgs e)
        {
            Menu.Menu menu = new Menu.Menu();
            menu.ShowDialog();
        }

        protected override void KifizetesButtonClickEvent(object sender, EventArgs e)
        {
            Payment.Payment payment = new Payment.Payment();
            payment.ShowDialog();
        }

        protected override void ResetButtonClickEvent(object sender, EventArgs e)
        {
            if (MessageBoxFactory.Produce(MessageBoxFactory.GetDeleteAllTableText(), MessageBoxFactory.GetDeleteAllTableTitle(), MessageBoxButtons.YesNo) == MessageBoxFactory.GetPositiveResult())
            {
                InvoiceDeleteHelper.DeleteAll();
            }
        }

        protected override void NewOrderLabelClickEvent(object sender, EventArgs e)
        {
            NewOrders newOrders = new NewOrders();
            newOrders.ShowDialog();
            if (RedisRepository.LLen("new_orders") == 0) HideEvents.CallGenericEvent(sender, e);
        }
    }
}
