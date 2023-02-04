using System;
using System.Windows.Forms;
using BartenderUI.Redis;
using BartenderUI.Util;
using BartenderUI.Util.Events;
using StackExchange.Redis;

namespace BartenderUI.List
{
    class List : AbstractList
    {
        private int id;

        public List(int id)
        {
            InitializeComponents();
            this.id = id;
            GridFiller.FillGrid(dataGridView, id);
        }

        protected override void AddItemButtonClickEvent(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem(id);
            addItem.ShowDialog();
            GridFiller.FillGrid(dataGridView, id);
        }

        protected override void RemoveItemButtonClickEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
