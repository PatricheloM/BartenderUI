using System;
using System.Windows.Forms;
using BartenderUI.Util.Factories;
using BartenderUI.Util.HelperTypes;

namespace BartenderUI.Util.Events
{
    class HideEvents
    {
        public static void CallForTableContextMenuEvent(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            Table table = menuItem.GetContextMenu().SourceControl as Table;
            if (table.State == SzabadFoglaltEnum.Foglalt)
            {
                MessageBoxFactory.Produce(MessageBoxFactory.GetNotEmptyTableText(), MessageBoxFactory.GetNotEmptyTableTitle(), MessageBoxButtons.OK);
            }
            else 
            {
                InvoiceDeleteHelper.DeleteTable(table.Id.ToString());
                table.Hide();
            }
        }

        public static void CallGenericEvent(object sender, EventArgs e)
        {
            Control control = sender as Control;
            control.Hide();
        }
    }
}
