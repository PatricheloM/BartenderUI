using System;
using System.Windows.Forms;
using BartenderUI.Util.Builders;
using BartenderUI.Util.Factories;

namespace BartenderUI.List
{
    abstract class AbstractList : FormBuilder
    {
        protected DataGridViewBuilder dataGridView;
        private DataGridViewTextBoxColumnBuilder nameColumn;
        private DataGridViewTextBoxColumnBuilder quantityColumn;
        private DataGridViewTextBoxColumnBuilder priceColumn;
        private DataGridViewTextBoxColumnBuilder invoiceColumn;

        private ButtonBuilder addItem;
        private ButtonBuilder removeItem;

        protected abstract void ListClosingEvent(object sender, FormClosingEventArgs e);
        protected abstract void AddItemButtonClickEvent(object sender, EventArgs e);
        protected abstract void RemoveItemButtonClickEvent(object sender, EventArgs e);


        public void InitializeComponents()
        {
            nameColumn = DataGridViewColumnFactory.Produce("nameColumn", "Tétel", true, 220);
            quantityColumn = DataGridViewColumnFactory.Produce("quantityColumn", "Darabszám", true, 70);
            priceColumn = DataGridViewColumnFactory.Produce("priceColumn", "Ár", true, 100);
            invoiceColumn = DataGridViewColumnFactory.Produce("invoiceColumn", "Számla", true, 2000);

            dataGridView = new DataGridViewBuilder()
                .WithAllowUserToResizeColumnsValue(false)
                .WithAllowUserToResizeRowsValue(false)
                .WithRowHeadersVisibleValue(false)
                .WithAllowUserToAddRowsValue(false)
                .WithColumnHeadersHeightSizeMode(DataGridViewColumnHeadersHeightSizeMode.AutoSize)
                .WithLocation(10, 10)
                .WithName("dataGridView")
                .WithScrollBars(ScrollBars.Vertical)
                .WithSize(590, 490)
                .AddColumns(nameColumn, quantityColumn, priceColumn, invoiceColumn);

            addItem = new ButtonBuilder()
                .WithName("addItem")
                .WithText("Tétel hozzáadása")
                .WithSize(590, 45)
                .WithLocation(10, 510)
                .AddClickEvent(AddItemButtonClickEvent);

            removeItem = new ButtonBuilder()
                .WithName("removeItem")
                .WithText("Tétel eltávolítása")
                .WithSize(590, 45)
                .WithLocation(10, 560)
                .AddClickEvent(RemoveItemButtonClickEvent);

            GetInstance()
                .WithClientSize(610, 610)
                .WithFormBorderStyle(FormBorderStyle.FixedToolWindow)
                .WithName("List")
                .WithText("Számla lista")
                .WithShowIconValue(false)
                .WithShowInTaskbarValue(false)
                .AddAll(dataGridView, addItem, removeItem);
        }
    }
}
