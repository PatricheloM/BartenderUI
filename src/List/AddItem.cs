using System;
using System.Collections.Generic;
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
            InitializeComponents(id);
            this.id = id;
        }

        protected override void AddButtonClickEvent(object sender, EventArgs e)
        {
            try
            {
                if (invoiceBox.Text == "<Új számla>")
                {
                    NewInvoice newInvoice = new NewInvoice(id, nameBox.Text, Convert.ToInt32(quantityBox.Value));
                    Close();
                    newInvoice.ShowDialog();
                }
                else if (nameBox.Text == null || nameBox.Text == "" || string.IsNullOrWhiteSpace(nameBox.Text) || invoiceBox.Text == null || invoiceBox.Text == "" || string.IsNullOrWhiteSpace(invoiceBox.Text) || Convert.ToInt32(quantityBox.Value) == 0)
                {
                    MessageBoxFactory.Produce(MessageBoxFactory.GetEmptyInputText(), MessageBoxFactory.GetEmptyInputTitle(), MessageBoxButtons.OK);
                }
                else
                {
                    HashEntry[] menu = RedisRepository.HGetAll("menu");
                    List<string> names = new List<string>();

                    foreach (HashEntry item in menu)
                    {
                        names.Add(item.Name);
                    }

                    if (Array.IndexOf(names.ToArray(), nameBox.Text) == -1)
                    {
                        MessageBoxFactory.Produce(MessageBoxFactory.GetItemNotFoundText(), MessageBoxFactory.GetItemNotFoundTitle(), MessageBoxButtons.OK);
                    }
                    else
                    {
                        OrderHelper.PushItemToRedis(id, invoiceBox.Text, nameBox.Text, Convert.ToInt32(quantityBox.Text));
                        Close();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBoxFactory.Produce(MessageBoxFactory.GetOnlyIntText(), MessageBoxFactory.GetOnlyIntTitle(), MessageBoxButtons.OK);
            }
        }

        protected override void UndoButtonClickEvent(object sender, EventArgs e)
        {
            Close();
        }
    }
}
