using BartenderUI.Redis;
using BartenderUI.Util;
using BartenderUI.Util.Factories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BartenderUI.List
{
    class NewInvoice : AbstractNewInvoice
    {
        private int id;
        private string name;
        private int quantity;

        public NewInvoice(int id, string name, int quantity)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
            InitializeComponents();
        }

        protected override void AddButtonClickEvent(object sender, EventArgs e)
        {
            if (invoiceBox.Text == null || invoiceBox.Text == "" || string.IsNullOrWhiteSpace(invoiceBox.Text))
            {
                MessageBoxFactory.Produce(MessageBoxFactory.GetEmptyInputText(), MessageBoxFactory.GetEmptyInputTitle(), MessageBoxButtons.OK);
            }
            else if (RedisRepository.Keys("szamla_" + invoiceBox.Text).Count() != 0
                && MessageBoxFactory.Produce(MessageBoxFactory.GetInvoiceExistsErrorText(), MessageBoxFactory.GetInvoiceExistsErrorTitle(), MessageBoxButtons.YesNo) != MessageBoxFactory.GetPositiveResult()) 
            { 
            }
            else
            {
                OrderHelper.PushItemToRedis(id, invoiceBox.Text, name, quantity);
                Close();
            }
        }

        protected override void BoxKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // enter
            {
                AddButtonClickEvent(sender, e);
            }
        }

        protected override void UndoButtonClickEvent(object sender, EventArgs e)
        {
            Close();
        }
    }
}
