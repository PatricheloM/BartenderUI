using BartenderUI.Util;
using BartenderUI.Util.Factories;
using BartenderUI.Util.HelperTypes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BartenderUI.Layout
{
    class NewOrders : AbstractNewOrders
    {
        public NewOrders(List<NewOrder> orders)
        {
            InitializeComponents();
            GridFiller.FillGrid(dataGridView, orders.ToArray());
        }

        protected override void GridViewButtonClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView) sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                throw new NotImplementedException();
            }
        }
    }
}
