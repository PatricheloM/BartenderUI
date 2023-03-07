using BartenderUI.Redis;
using BartenderUI.Util;
using BartenderUI.Util.HelperTypes;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BartenderUI.Layout
{
    class NewOrders : AbstractNewOrders
    {
        public NewOrders()
        {
            InitializeComponents();
            GridFiller.FillGrid(dataGridView, NewOrderHelper.GetNewOrders().ToArray());
        }

        protected override void GridViewButtonClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                RedisRepository.LRem("new_orders", PublishedMessageConverter.ObjectToString(
                    new NewOrder(
                        dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString(),
                        dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString())));
                if (RedisRepository.LLen("new_orders") != 0) GridFiller.FillGrid(dataGridView, NewOrderHelper.GetNewOrders().ToArray());
                else Close();
            }
        }
    }
}
