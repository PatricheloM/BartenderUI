using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BartenderUI.Util.Builders;
using BartenderUI.Util.Factories;

namespace BartenderUI.Layout
{
    class AbstractNewOrders : FormBuilder
    {
        protected DataGridViewBuilder dataGridView;
        private DataGridViewTextBoxColumnBuilder itemColumn;
        private DataGridViewTextBoxColumnBuilder quantityColumn;
        private DataGridViewTextBoxColumnBuilder tableColumn;
        private DataGridViewTextBoxColumnBuilder invoiceColumn;

        public void InitializeComponents()
        {
            itemColumn = DataGridViewColumnFactory.Produce("itemColumn", "Tétel", true, 180);
            quantityColumn = DataGridViewColumnFactory.Produce("quantityColumn", "Darabszám", true, 70);
            tableColumn = DataGridViewColumnFactory.Produce("tableColumn", "Asztal", true, 100);
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
                .WithSize(450, 450)
                .AddColumns(itemColumn, quantityColumn, tableColumn, invoiceColumn);

            GetInstance()
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
