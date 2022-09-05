using System;
using System.Windows.Forms;
using BartenderUI.Util;
using BartenderUI.Util.Events;
using BartenderUI.Util.Factories;

namespace BartenderUI.Layout
{
    class Layout : AbstractLayout
    {
        public Layout()
        {
            InitializeComponents();

            EventListeners.Start(this, groupBoxBelso, groupBoxKulso, newOrderLabel);

            RefreshEvent.Invoke();
        }

        protected override void PluszBelsoButtonClickEvent(object sender, EventArgs e)
        {
            groupBoxBelso.AddAll(TableFactory.Produce(TablePlaceEnum.Belso));
        }

        protected override void PluszKulsoButtonClickEvent(object sender, EventArgs e)
        {
            groupBoxKulso.AddAll(TableFactory.Produce(TablePlaceEnum.Kulso));
        }

        protected override void ExitButtonClickEvent(object sender, EventArgs e)
        {
            if (MessageBoxFactory.Produce(MessageBoxFactory.GetExitText(), MessageBoxFactory.GetExitTitle(), MessageBoxButtons.YesNo) == MessageBoxFactory.GetPositiveResult()) Application.Exit();
        }

        protected override void MinimizeButtonClickEvent(object sender, EventArgs e)
        {
            GetInstance()
                .WithState(FormWindowState.Minimized);
        }

        protected override void ItallapButtonClickEvent(object sender, EventArgs e)
        {
            Menu.Menu menu = new Menu.Menu();
            menu.ShowDialog();
        }

        protected override void KifizetesButtonClickEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            // todo
            HideEvents.CallGenericEvent(sender, e);
        }
    }
}
