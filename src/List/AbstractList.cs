using System;
using System.Windows.Forms;
using BartenderUI.Util.Extensions;
using BartenderUI.Util.Factories;

namespace BartenderUI.List
{
    abstract class AbstractList : Form
    {
        protected DataGridView dataGridView;
        private DataGridViewTextBoxColumn nameColumn;
        private DataGridViewTextBoxColumn quantityColumn;
        private DataGridViewTextBoxColumn priceColumn;
        private DataGridViewTextBoxColumn invoiceColumn;

        private Button addItem;

        protected abstract void AddItemButtonClickEvent(object sender, EventArgs e);


        public void InitializeComponents()
        {
            nameColumn = DataGridViewColumnFactory.TextBoxColumn.Produce("nameColumn", "Tétel", true, 220);
            quantityColumn = DataGridViewColumnFactory.TextBoxColumn.Produce("quantityColumn", "Darabszám", true, 70);
            priceColumn = DataGridViewColumnFactory.TextBoxColumn.Produce("priceColumn", "Ár", true, 100);
            invoiceColumn = DataGridViewColumnFactory.TextBoxColumn.Produce("invoiceColumn", "Számla", true, 200);

            dataGridView = new DataGridView()
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

            addItem = new Button()
                .WithName("addItem")
                .WithText("Tétel hozzáadása")
                .WithSize(590, 45)
                .WithLocation(10, 555)
                .AddClickEvent(AddItemButtonClickEvent);

            this
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
