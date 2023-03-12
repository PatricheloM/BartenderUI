using System;
using BartenderUI.Util.HelperTypes;

namespace BartenderUI.Util.Events
{
    class DoubleClickEvent
    {
        public static void TableDoubleClickEvent(object sender, EventArgs e)
        {
            Table table = sender as Table;
            List.List list = new List.List(table.Id);
            list.ShowDialog();
        }
    }
}
