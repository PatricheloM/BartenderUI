using System;
using System.Windows.Forms;
using BartenderUI.Util.Extensions;
using BartenderUI.Util.Factories;

namespace BartenderUI.Layout
{
    abstract class AbstractNewOrders : Form
    {
        protected DataGridView dataGridView;
        private DataGridViewTextBoxColumn itemColumn;
        private DataGridViewTextBoxColumn quantityColumn;
        private DataGridViewTextBoxColumn tableColumn;
        private DataGridViewTextBoxColumn invoiceColumn;
        private DataGridViewButtonColumn isDeliveredColumn;

        protected abstract void GridViewButtonClickEvent(object sender, DataGridViewCellEventArgs e);

        public void InitializeComponents()
        {
            itemColumn = DataGridViewColumnFactory.TextBoxColumn.Produce("itemColumn", "Tétel", true, 180);
            quantityColumn = DataGridViewColumnFactory.TextBoxColumn.Produce("quantityColumn", "Darab", true, 50);
            tableColumn = DataGridViewColumnFactory.TextBoxColumn.Produce("tableColumn", "Asztal", true, 50);
            invoiceColumn = DataGridViewColumnFactory.TextBoxColumn.Produce("invoiceColumn", "Számla", true, 120);
            isDeliveredColumn = DataGridViewColumnFactory.ButtonColumn.Produce("isDeliveredColumn", "Zárás", 50);

            dataGridView = new DataGridView()
                .WithAllowUserToResizeColumnsValue(false)
                .WithAllowUserToResizeRowsValue(false)
                .WithRowHeadersVisibleValue(false)
                .WithAllowUserToAddRowsValue(false)
                .WithColumnHeadersHeightSizeMode(DataGridViewColumnHeadersHeightSizeMode.AutoSize)
                .WithLocation(10, 10)
                .WithName("dataGridView")
                .WithScrollBars(ScrollBars.Vertical)
                .WithSize(450, 450)
                .AddCellContentClickEvent(GridViewButtonClickEvent)
                .AddColumns(itemColumn, quantityColumn, tableColumn, invoiceColumn, isDeliveredColumn);

            this
                .WithClientSize(470, 470)
                .WithFormBorderStyle(FormBorderStyle.FixedToolWindow)
                .WithName("Új rendelések")
                .WithText("Új rendelések")
                .WithShowIconValue(false)
                .WithShowInTaskbarValue(false)
                .AddAll(dataGridView);
        }
    }
}
