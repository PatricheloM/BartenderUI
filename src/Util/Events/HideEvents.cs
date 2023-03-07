using System;
using System.Windows.Forms;
using BartenderUI.Util.Extensions;
using BartenderUI.Util.Factories;

namespace BartenderUI.Util.Events
{
    class HideEvents
    {
        public static void CallForTableContextMenuEvent(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            PictureBox table = menuItem.GetContextMenu().SourceControl as PictureBox;
            if (table.GetState() == SzabadFoglaltEnum.Foglalt)
            {
                MessageBoxFactory.Produce(MessageBoxFactory.GetNotEmptyTableText(), MessageBoxFactory.GetNotEmptyTableTitle(), MessageBoxButtons.OK);
            }
            else 
            {
                InvoiceDeleteHelper.DeleteTable(table.GetId().ToString());
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
