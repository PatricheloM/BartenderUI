using System;
using System.IO;
using System.Windows.Forms;
using BartenderUI.Redis;
using BartenderUI.Util;


namespace BartenderUI.Menu
{
    class Menu : AbstractMenu
    {
        public Menu()
        {
            InitializeComponents();
            GridFiller.FillGrid(dataGridView, RedisRepository.HGetAll("menu"));
        }

        protected override void AddItemButtonClickEvent(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.ShowDialog();

            GridFiller.FillGrid(dataGridView, RedisRepository.HGetAll("menu"));
        }

        protected override void AddItemFromFileButtonClickEvent(object sender, EventArgs e)
        {
            AddItem.AddFromFile();
            
            GridFiller.FillGrid(dataGridView, RedisRepository.HGetAll("menu"));
        }

        protected override void RemoveItemButtonClickEvent(object sender, EventArgs e)
        {
            RemoveItem removeItem = new RemoveItem();
            removeItem.ShowDialog();

            GridFiller.FillGrid(dataGridView, RedisRepository.HGetAll("menu"));
        }
    }
}
