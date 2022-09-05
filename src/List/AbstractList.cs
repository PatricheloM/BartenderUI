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

        protected abstract void ListClosingEvent(object sender, FormClosingEventArgs e);
        protected abstract void CellEndEditEvent(object sender, DataGridViewCellEventArgs e);
        protected abstract void EditingControlShowingEvent(object sender, DataGridViewEditingControlShowingEventArgs e);


        public void InitializeComponents()
        {
            nameColumn = DataGridViewColumnFactory.Produce("nameColumn", "Tétel", false, 220);
            quantityColumn = DataGridViewColumnFactory.Produce("quantityColumn", "Darabszám", true, 70);
            priceColumn = DataGridViewColumnFactory.Produce("priceColumn", "Ár", true, 100);
            invoiceColumn = DataGridViewColumnFactory.Produce("invoiceColumn", "Számla", true, 2000);

            dataGridView = new DataGridViewBuilder()
                .WithAllowUserToResizeColumnsValue(false)
                .WithAllowUserToResizeRowsValue(false)
                .WithRowHeadersVisibleValue(false)
                .WithColumnHeadersHeightSizeMode(DataGridViewColumnHeadersHeightSizeMode.AutoSize)
                .WithLocation(10, 10)
                .WithName("dataGridView")
                .WithScrollBars(ScrollBars.Vertical)
                .WithSize(590, 590)
                .AddCellEndEditEvent(CellEndEditEvent)
                .AddEditingControlShowingEvent(EditingControlShowingEvent)
                .AddColumns(nameColumn, quantityColumn, priceColumn, invoiceColumn);

            GetInstance()
                .WithClientSize(610, 610)
                .WithFormBorderStyle(FormBorderStyle.FixedToolWindow)
                .WithName("List")
                .WithText("Számla lista")
                .WithShowIconValue(false)
                .WithShowInTaskbarValue(false)
                .AddAll(dataGridView);
        }
    }
}
