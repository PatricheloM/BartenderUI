using BartenderUI.Util.Factories;
using System;
using System.Windows.Forms;
using BartenderUI.Redis;

namespace BartenderUI.Menu
{
    class RemoveItem : AbstractRemoveItem
    {
        public RemoveItem()
        {
            InitializeComponents();
        }

        protected override void RemoveButtonClickEvent(object sender, EventArgs e)
        {
            try
            {
                if (nameBox.Text == null || nameBox.Text == "" || string.IsNullOrWhiteSpace(nameBox.Text))
                {
                    MessageBoxFactory.Produce(MessageBoxFactory.GetEmptyInputText(), MessageBoxFactory.GetEmptyInputTitle(), MessageBoxButtons.OK);
                }
                else
                {
                    Close();
                    if (!RedisRepository.HDel("menu", nameBox.Text))
                    {
                        MessageBoxFactory.Produce(MessageBoxFactory.GetItemNotFoundText(), MessageBoxFactory.GetItemNotFoundTitle(), MessageBoxButtons.OK);
                    }
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
                RemoveButtonClickEvent(sender, e);
            }
        }

        protected override void UndoButtonClickEvent(object sender, EventArgs e)
        {
            Close();
        }
    }
}
