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

        protected abstract void AddItemButtonClickEvent(object sender, EventArgs e);


        public void InitializeComponents()
        {
            nameColumn = DataGridViewColumnFactory.Produce("nameColumn", "Tétel", true, 220);
            quantityColumn = DataGridViewColumnFactory.Produce("quantityColumn", "Darabszám", true, 70);
            priceColumn = DataGridViewColumnFactory.Produce("priceColumn", "Ár", true, 100);
            invoiceColumn = DataGridViewColumnFactory.Produce("invoiceColumn", "Számla", true, 200);

            dataGridView = new DataGridViewBuilder()
                .WithAllowUserToResizeColumnsValue(false)
                .WithAllowUserToResizeRowsValue(false)
                .WithRowHeadersVisibleValue(false)
                .WithAllowUserToAddRowsValue(false)
                .WithColumnHeadersHeightSizeMode(DataGridViewColumnHeadersHeightSizeMode.AutoSize)
                .WithLocation(10, 10)
                .WithName("dataGridView")
                .WithScrollBars(ScrollBars.Vertical)
                .WithSize(590, 535)
                .AddColumns(nameColumn, quantityColumn, priceColumn, invoiceColumn);

            addItem = new ButtonBuilder()
                .WithName("addItem")
                .WithText("Tétel hozzáadása")
                .WithSize(590, 45)
                .WithLocation(10, 555)
                .AddClickEvent(AddItemButtonClickEvent);

            GetInstance()
                .WithClientSize(610, 610)
                .WithFormBorderStyle(FormBorderStyle.FixedToolWindow)
                .WithName("List")
                .WithText("Számla lista")
                .WithShowIconValue(false)
                .WithShowInTaskbarValue(false)
                .AddAll(dataGridView, addItem);
        }
    }
}
