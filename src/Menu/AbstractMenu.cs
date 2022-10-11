using System;
using System.Windows.Forms;
using BartenderUI.Util.Builders;
using BartenderUI.Util.Factories;

namespace BartenderUI.Menu
{
    abstract class AbstractMenu : FormBuilder
    {
        protected DataGridViewBuilder dataGridView;

        private DataGridViewTextBoxColumnBuilder item;
        private DataGridViewTextBoxColumnBuilder price;

        private ButtonBuilder addItem;
        private ButtonBuilder addItemFromFile;
        private ButtonBuilder removeItem;

        protected abstract void AddItemButtonClickEvent(object sender, EventArgs e);
        protected abstract void AddItemFromFileButtonClickEvent(object sender, EventArgs e);
        protected abstract void RemoveItemButtonClickEvent(object sender, EventArgs e);

        protected void InitializeComponents()
        {
            item = DataGridViewColumnFactory.Produce("item", "Termék név", true, 420);
            price = DataGridViewColumnFactory.Produce("price", "Ár (Ft)", true, 160);

            dataGridView = new DataGridViewBuilder()
                .WithAllowUserToAddRowsValue(false)
                .WithAllowUserToResizeColumnsValue(false)
                .WithAllowUserToResizeRowsValue(false)
                .WithRowHeadersVisibleValue(false)
                .WithColumnHeadersHeightSizeMode(DataGridViewColumnHeadersHeightSizeMode.AutoSize)
                .WithLocation(10, 10)
                .WithSize(580, 670)
                .WithName("dataGridView")
                .WithReadOnlyValue(true)
                .WithScrollBars(ScrollBars.Vertical)
                .AddColumns(item, price);

            addItem = new ButtonBuilder()
                .WithName("addItem")
                .WithText("Tétel hozzáadása")
                .WithSize(580, 45)
                .WithLocation(10, 685)
                .AddClickEvent(AddItemButtonClickEvent);

            addItemFromFile = new ButtonBuilder()
                .WithName("addItemFromFile")
                .WithText("Tétel hozzáadása (fájlból)")
                .WithSize(580, 45)
                .WithLocation(10, 735)
                .AddClickEvent(AddItemFromFileButtonClickEvent);

            removeItem = new ButtonBuilder()
                .WithName("removeItem")
                .WithText("Tétel eltávolítása")
                .WithSize(580, 45)
                .WithLocation(10, 785)
                .AddClickEvent(RemoveItemButtonClickEvent);

            GetInstance()
                .WithClientSize(600, 835)
                .WithFormBorderStyle(FormBorderStyle.FixedToolWindow)
                .WithName("Menu")
                .WithText("Menü")
                .WithShowIconValue(false)
                .WithShowInTaskbarValue(false)
                .AddAll(dataGridView, addItem, addItemFromFile, removeItem);
        }
    }
}
