using System;
using System.IO;
using System.Windows.Forms;
using StackExchange.Redis;
using BartenderUI.Redis;
using BartenderUI.Util.Factories;
using System.Data;
using System.Collections.Generic;
using BartenderUI.Util;

namespace BartenderUI.Menu
{
    class AddItem : AbstractAddItem
    {
        public AddItem()
        {
            InitializeComponents();
        }

        private static void PushItemToRedis(string name, int price)
        {
            RedisRepository.HMSet("menu", new HashEntry(name, price));
        }

        public static void AddFromFile()
        {
            DataSet dataSet;

            try
            {
                dataSet = ExcelFileReader.GetDataSet();
            }
            catch (IOException)
            {
                MessageBoxFactory.Produce(MessageBoxFactory.GetFileInUseText(), MessageBoxFactory.GetFileInUseTitle(), MessageBoxButtons.OK);
                return;
            }


            Dictionary<string, int> items = new Dictionary<string, int>();

            int incorrectEntries = 0;

            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow item in table.Rows)
                {
                    try
                    {
                        if (!items.ContainsKey(item.ItemArray[0].ToString()) && (item.ItemArray[0].ToString() != null || item.ItemArray[0].ToString() != "" || string.IsNullOrWhiteSpace(item.ItemArray[0].ToString())))
                        {
                            items.Add(item.ItemArray[0].ToString(), Convert.ToInt32(item.ItemArray[1].ToString()));
                        }
                        else
                        {
                            incorrectEntries++;
                        }
                    }
                    catch (FormatException)
                    {
                        incorrectEntries++;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBoxFactory.Produce(MessageBoxFactory.GetColumnCountErrorText(), MessageBoxFactory.GetColumnCountErrorTitle(), MessageBoxButtons.OK);
                        return;
                    }
                }
            }

            foreach (string item in items.Keys)
            {
                PushItemToRedis(item, items[item]);
            }

            MessageBoxFactory.Produce(incorrectEntries == 0 ? MessageBoxFactory.GetAddedItemsWithoutErrorsText(items.Count) : MessageBoxFactory.GetAddedItemsWithErrorsText(items.Count, incorrectEntries), MessageBoxFactory.GetAddedItemsTitle(), MessageBoxButtons.OK);

        }

        protected override void AddButtonClickEvent(object sender, EventArgs e)
        {
            try
            {
                if (nameBox.Text == null || nameBox.Text == "" || string.IsNullOrWhiteSpace(nameBox.Text))
                {
                    MessageBoxFactory.Produce(MessageBoxFactory.GetEmptyInputText(), MessageBoxFactory.GetEmptyInputTitle(), MessageBoxButtons.OK);
                }
                else
                {
                    PushItemToRedis(nameBox.Text, Convert.ToInt32(priceBox.Text));
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
