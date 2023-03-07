using System;
using System.Windows.Forms;
using BartenderUI.Util.Extensions;

namespace BartenderUI.Util.Events
{
    class ClearTableEvent
    {
        public static void ClearTableEventForTableContextMenu(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            PictureBox table = menuItem.GetContextMenu().SourceControl as PictureBox;
            InvoiceDeleteHelper.DeleteInvoices(table.GetId());
        }
    }
}
