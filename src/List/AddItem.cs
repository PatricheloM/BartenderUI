using System;
using System.Windows.Forms;
using BartenderUI.Redis;
using BartenderUI.Util;
using BartenderUI.Util.Factories;
using StackExchange.Redis;

namespace BartenderUI.List
{
    class AddItem : AbstractAddItem
    {
        private int id;

        public AddItem(int id)
        {
            InitializeComponents();
            this.id = id;
        }

        private void PushItemToRedis(string invoice, string name, int quantity)
        {
            RedisRepository.SAdd("szamlak_" + id, invoice);
            RedisRepository.HIncrBy("szamla_" + invoice, name, quantity);
        }

        protected override void AddButtonClickEvent(object sender, EventArgs e)
        {
            try
            {
                if (nameBox.Text == null || nameBox.Text == "" || string.IsNullOrWhiteSpace(nameBox.Text) || invoiceBox.Text == null || invoiceBox.Text == "" || string.IsNullOrWhiteSpace(invoiceBox.Text) || Convert.ToInt32(quantityBox.Text) == 0)
                {
                    MessageBoxFactory.Produce(MessageBoxFactory.GetEmptyInputText(), MessageBoxFactory.GetEmptyInputTitle(), MessageBoxButtons.OK);
                }
                else
                {
                    PushItemToRedis(invoiceBox.Text, nameBox.Text, Convert.ToInt32(quantityBox.Text));
                    Close();
                }
            }
            catch (FormatException)
            {
                MessageBoxFactory.Produce(MessageBoxFactory.GetOnlyIntText(), MessageBoxFactory.GetOnlyIntTitle(), MessageBoxButtons.OK);
            }
        }

        protected override void BoxKeyUpEvent(object sender, KeyEventArgs e)
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
