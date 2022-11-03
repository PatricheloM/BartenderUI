using BartenderUI.Util;
using BartenderUI.Util.HelperTypes;
using System.Collections.Generic;

namespace BartenderUI.Layout
{
    class NewOrders : AbstractNewOrders
    {
        public NewOrders(List<NewOrder> orders)
        {
            InitializeComponents();
            GridFiller.FillGrid(dataGridView, orders.ToArray());
        }
    }
}
